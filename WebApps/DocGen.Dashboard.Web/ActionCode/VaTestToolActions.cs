using log4net;
using LPA.Dashboard.Web.Code;
using LPA.Dashboard.Web.Properties;
using LPA.Dashboard.Web.ViewModels;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WOW.IllustrationMgmntTool.Common.Code;
using WOW.IllustrationMgmntTool.Common.Models.VaTestTool;

namespace LPA.Dashboard.Web.ActionCode
{
    /// <summary>
    /// Va Test Tool Actions
    /// </summary>
    internal class VaTestToolActions
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(VaTestToolActions));

        /// <summary>
        /// Process upload Excel
        /// </summary>
        /// <param name="httpContent"></param>
        /// <exception cref="HttpResponseException"></exception>
        internal void ProcessUploadExcel(HttpContent httpContent)
        {
            if (log.IsInfoEnabled) log.Info("ProcessUploadExcel called.");

            if (!httpContent.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var today = DateTime.Now;
            var yearMonth = today.Year.ToString() + "-" + today.Month.ToString().PadLeft(2, '0');
            var excelFileDestinationFolder = Path.Combine(Settings.Default.IllustrationExcelFileDirectory, yearMonth);

            Utilities.CreateDirectory(excelFileDestinationFolder);

            var fileName = string.Empty;
            var provider = new MultipartFileStreamProvider(excelFileDestinationFolder);
            var task = httpContent.ReadAsMultipartAsync(provider).
                ContinueWith(_ =>
                {
                    var fileContent = provider.Contents.SingleOrDefault();

                    if (fileContent != null)
                    {
                        fileName = fileContent.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
                    }
                    foreach (MultipartFileData item in provider.FileData)
                    {
                        try
                        {
                            var fileDest = Path.Combine(excelFileDestinationFolder, fileName);

                            Utilities.DeleteFile(fileDest);

                            string name = item.Headers.ContentDisposition.FileName.Replace("\"", "");

                            Utilities.CopyFile(item.LocalFileName, fileDest);
                        }
                        catch (Exception ex)
                        {
                            string message = ex.Message;
                        }
                    }

                    return new HttpResponseMessage(HttpStatusCode.Created);
                });
        }

        /// <summary>
        /// Display Excel files view model
        /// </summary>
        /// <returns>DisplayExcelFilesViewModel</returns>
        internal DisplayExcelFilesViewModel ProcessDisplayExcelFiles()
        {
            if (log.IsInfoEnabled) log.Info("ProcessDisplayExcelFiles called.");

            DisplayExcelFilesViewModel displayExcelFilesViewModel = new DisplayExcelFilesViewModel();

            var excelFilesLocation = Settings.Default.IllustrationExcelFileDirectory;

            foreach (var excelFilePath in Directory.GetFiles(excelFilesLocation, "*", SearchOption.AllDirectories))
            {
                ExcelFile excelFile = new ExcelFile();
                var zipFilePathParts = excelFilePath.Split(new[] { '\\' });
                excelFile.FileName = zipFilePathParts[zipFilePathParts.Length - 1];
                excelFile.FilePath = excelFilePath.Replace("\\", "\\\\");

                displayExcelFilesViewModel.ExcelFileInfoList.Add(excelFile);
            }

            return displayExcelFilesViewModel;
        }

        /// <summary>
        /// Generate SQL
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <exception cref="Exception"></exception>
        public void GenerateSql(FileInfo fileInfo)
        {
            if (log.IsInfoEnabled) log.Info($"GenerateSql called with file: {fileInfo.Name}.");

            var workSheetCounter = 0;
            var workSheetName = string.Empty;

            var fileName = fileInfo.Name;
            var fileNameParts = fileName.Split(new[] { '.' });
            var fileExtension = fileNameParts[fileNameParts.Length - 1].ToLower();

            if (fileExtension != "xlsx" && fileExtension != "xls" && fileExtension != "xlsb" && fileExtension != "xlsm")
            {
                throw new Exception("File is not valid excel file");
            }

            try
            {
                using (var excelPackage = new ExcelPackage(fileInfo))
                {
                    foreach (var workSheet in excelPackage.Workbook.Worksheets)
                    {
                        workSheetCounter++;
                        workSheetName = workSheet.Name.ToUpper();

                        switch (workSheetName)
                        {
                            case "VA UVS":
                                GenerateVaUnitUpdateSql(workSheetCounter, fileInfo);
                                break;
                            case "MESSAGECENTER":
                                GenerateMessageCenterSql(workSheetCounter, fileInfo);
                                break;
                            case "VA EXPENSES":
                                GenerateVaExpenseSql(workSheetCounter, fileInfo);
                                break;
                            case "VA EXPENSE - MIN&MAX":
                                GenerateExpenseMinMaxSql(workSheetCounter, fileInfo);
                                break;
                            case "IUL-RATEDATA":
                                GenerateIULRateDataSql(workSheetCounter, fileInfo);
                                break;
                            case "IUL-NAMEDVALUE":
                                GenerateIULNamedValueSql(workSheetCounter, fileInfo);
                                break;
                            case "IUL-PLANCOMMONDATA":
                                GenerateIULPlanCommonDataSql(workSheetCounter, fileInfo);
                                break;
                            case "MIR-PLANBAND":
                                GenerateMirPlanBandSql(workSheetCounter, fileInfo);
                                break;
                            case "MIR-RATEDATA":
                                GenerateMIRRateDataSql(workSheetCounter, fileInfo);
                                break;
                            case "MIR-PLANCOMMONDATA":
                                GenerateMIRPlanCommonDataSql(workSheetCounter, fileInfo);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error($"Failed to process worksheet: {workSheetName}. {ex.Message}");

                throw new Exception($"Failed to process worksheet: {workSheetName}. {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Generate MIR Plan Bank SQL
        /// </summary>
        /// <param name="workSheetCounter"></param>
        /// <param name="fileInfo"></param>
        /// <exception cref="Exception"></exception>
        public void GenerateMirPlanBandSql(int workSheetCounter, FileInfo fileInfo)
        {
            if (log.IsInfoEnabled) log.Info($"GenerateMirPlanBandSql called with workSheetNumber: {workSheetCounter} in file: {fileInfo.Name}.");

            try
            {
                using (var excelPaclage = new ExcelPackage(fileInfo))
                {
                    var workSheet = excelPaclage.Workbook.Worksheets[workSheetCounter];
                    const bool hasHeader = false;
                    bool hasProductIdColumn = false;
                    bool hasBandColumn = false;
                    bool hasRate1Column = false;
                    int productIdLocation = 0;
                    int bandLocation = 0;
                    int rate1Location = 0;
                    double rate1 = 0;
                    int productIdCode = 0;
                    int band = 0;
                    var updateSqlFolder = Settings.Default.IllustrationSqlFileDirectory;
                    int productIdColumn = 0;
                    int bandColumn = 0;
                    int rate1Column = 0;
                    var today = DateTime.Now;
                    var yearMonth = today.Year.ToString() + "-" + today.Month.ToString().PadLeft(2, '0');
                    var updateSqlDirectory = Path.Combine(updateSqlFolder, yearMonth);
                    var headerRow = 0;
                    int planBandId = 0;

                    if (!Directory.Exists(updateSqlDirectory))
                    {
                        Directory.CreateDirectory(updateSqlDirectory);
                    }

                    var excelFilePathParts = fileInfo.FullName.Split(new[] { '\\' });
                    var fileName = excelFilePathParts[excelFilePathParts.Length - 1];
                    var fileNameParts = fileName.Split(new[] { '.' });
                    var fileNameNoExt = fileNameParts[0];
                    var sqlFileName = fileNameNoExt + "_MirPlanBand_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmm") + ".Sql";
                    var updateSqlPath = Path.Combine(updateSqlDirectory, sqlFileName);

                    Utilities.DeleteDirectory(updateSqlPath);

                    using (StreamWriter sw = File.CreateText(updateSqlPath))
                    {
                        sw.WriteLine("--Start changes for table PlanBand");
                    }

                    for (int i = workSheet.Dimension.Start.Row; i <= workSheet.Dimension.End.Row; i++)
                    {
                        object cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue != null && !hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (workSheet.Cells[i, j].Value != null)
                                {
                                    if (!hasProductIdColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.ProductIdHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        headerRow = i;
                                        productIdColumn = j;
                                        hasProductIdColumn = true;
                                    }

                                    if (!hasBandColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.BandHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        bandColumn = j;
                                        hasBandColumn = true;
                                    }

                                    if (!hasRate1Column && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.Rate1Header, StringComparison.OrdinalIgnoreCase))
                                    {
                                        rate1Column = j;
                                        hasRate1Column = true;
                                    }
                                }
                            }

                            if (hasBandColumn && hasRate1Column && hasProductIdColumn)
                            {
                                break;
                            }
                        }
                    }

                    if (!hasProductIdColumn || !hasRate1Column || !hasBandColumn)
                    {
                        // Did not find one of the headers, need to kill the run and report to the user which one we didn't find
                        List<string> missingHeaders = new List<string>();
                        StringBuilder sbMissingHeaders = new StringBuilder();
                        var headerCount = 0;

                        if (!hasProductIdColumn)
                        {
                            missingHeaders.Add(Settings.Default.ProductIdHeader);
                        }

                        if (!hasBandColumn)
                        {
                            missingHeaders.Add(Settings.Default.BandHeader);
                        }

                        if (!hasRate1Column)
                        {
                            missingHeaders.Add(Settings.Default.Rate1Header);
                        }

                        foreach (var missingHeader in missingHeaders)
                        {
                            headerCount++;
                            sbMissingHeaders.Append(missingHeader);
                            if (missingHeaders.Count > 1 && headerCount < missingHeaders.Count)
                            {
                                sbMissingHeaders.Append(" ,");
                            }
                        }

                        throw new Exception("Missing header(s): " + sbMissingHeaders);
                    }

                    for (int i = headerRow + 1; i <= workSheet.Dimension.End.Row; i++)
                    {
                        var cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue == null)
                        {
                            break;
                        }
                        if (!hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (j == productIdColumn)
                                {
                                    productIdLocation = j;
                                }

                                if (j == bandColumn)
                                {
                                    bandLocation = j;
                                }

                                if (j == rate1Column)
                                {
                                    rate1Location = j;
                                }
                            }
                        }

                        band = Convert.ToInt32(workSheet.Cells[i, bandLocation].Value);
                        rate1 = Convert.ToDouble(workSheet.Cells[i, rate1Location].Value);
                        productIdCode = Convert.ToInt32(workSheet.Cells[i, productIdLocation].Value);

                        PlanBandUtils planBandUtils = new PlanBandUtils();

                        planBandId = planBandUtils.GetPlanBandId(productIdCode, band);

                        using (StreamWriter sw = File.AppendText(updateSqlPath))
                        {
                            sw.WriteLine("UPDATE [PlanBand] SET");
                            sw.WriteLine("[ProductId]=" + productIdCode + ",");
                            sw.WriteLine("[Band]=" + band + ",");
                            sw.WriteLine("[Rate1]=" + rate1);
                            sw.WriteLine("WHERE [PlanBandID]=" + planBandId);
                            sw.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Unable to complete the generation of the MIR Plan Band Update SQL Script.", ex);

                throw new Exception("Unable to complete the generation of the MIR Plan Band Update SQL Script.", ex);
            }
        }

        /// <summary>
        /// Generate Message Center SQL
        /// </summary>
        /// <param name="workSheetCounter"></param>
        /// <param name="fileInfo"></param>
        /// <exception cref="Exception"></exception>
        //Not finished need to know where ReleaseNoteTitle comes from
        public void GenerateMessageCenterSql(int workSheetCounter, FileInfo fileInfo)
        {
            if (log.IsInfoEnabled) log.Info($"GenerateMessageCenterSql called with workSheetNumber: {workSheetCounter} in file: {fileInfo.Name}.");

            try
            {
                using (var excelPaclage = new ExcelPackage(fileInfo))
                {
                    var workSheet = excelPaclage.Workbook.Worksheets[workSheetCounter];
                    const bool hasHeader = false;
                    bool hasStartDateColumn = false;
                    bool hasEndDateColumn = false;
                    bool hasMessageColumn = false;
                    bool hasReleaseNoteTitle = false;
                    int releaseNoteTitleLocation = 0;
                    int startDateLocation = 0;
                    int endDateLocation = 0;
                    int messageLocation = 0;
                    DateTime startDate = DateTime.Today;
                    DateTime endDate = DateTime.Today;
                    string releaseNoteId = Settings.Default.ReleaseNoteId;
                    string releaseNoteTitle = string.Empty;
                    string message = string.Empty;
                    var updateSqlFolder = Settings.Default.IllustrationSqlFileDirectory;
                    int releaseNoteTitleColumn = 0;
                    int startDateColumn = 0;
                    int endDateColumn = 0;
                    int messageColumn = 0;
                    var today = DateTime.Now;
                    var yearMonth = today.Year.ToString() + "-" + today.Month.ToString().PadLeft(2, '0');
                    var updateSqlDirectory = Path.Combine(updateSqlFolder, yearMonth);
                    var headerRow = 0;

                    if (!Directory.Exists(updateSqlDirectory))
                    {
                        Directory.CreateDirectory(updateSqlDirectory);
                    }

                    var excelFilePathParts = fileInfo.FullName.Split(new[] { '\\' });
                    var fileName = excelFilePathParts[excelFilePathParts.Length - 1];
                    var fileNameParts = fileName.Split(new[] { '.' });
                    var fileNameNoExt = fileNameParts[0];
                    var sqlFileName = fileNameNoExt + "_MessageCenter_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + ".Sql";
                    var updateSqlPath = Path.Combine(updateSqlDirectory, sqlFileName);

                    Utilities.DeleteDirectory(updateSqlPath);

                    using (StreamWriter sw = File.CreateText(updateSqlPath))
                    {
                        sw.WriteLine("--Start changes for table RateData");
                    }

                    for (int i = workSheet.Dimension.Start.Row; i <= workSheet.Dimension.End.Row; i++)
                    {
                        object cellValue = workSheet.Cells[1, 1].Value;

                        if (cellValue != null && !hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (workSheet.Cells[i, j].Value != null)
                                {
                                    if (!hasStartDateColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.StartDateHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        headerRow = i;
                                        startDateColumn = j;
                                        hasStartDateColumn = true;
                                    }

                                    if (!hasReleaseNoteTitle && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.ReleaseNoteTitleHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        releaseNoteTitleColumn = j;
                                        hasReleaseNoteTitle = true;
                                    }

                                    if (!hasEndDateColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.EndDateHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        headerRow = i;
                                        endDateColumn = j;
                                        hasEndDateColumn = true;
                                    }

                                    if (!hasMessageColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.MessageHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        messageColumn = j;
                                        hasMessageColumn = true;
                                    }
                                }
                            }
                        }
                    }

                    if (!hasStartDateColumn || !hasMessageColumn || !hasEndDateColumn || !hasReleaseNoteTitle)
                    {
                        // Did not find one of the headers, need to kill the run and report to the user which one we didn't find
                        List<string> missingHeaders = new List<string>();
                        StringBuilder sbMissingHeaders = new StringBuilder();
                        var headerCount = 0;

                        if (!hasStartDateColumn)
                        {
                            missingHeaders.Add(Settings.Default.StartDateHeader);
                        }

                        if (!hasReleaseNoteTitle)
                        {
                            missingHeaders.Add(Settings.Default.ReleaseNoteTitleHeader);
                        }

                        if (!hasEndDateColumn)
                        {
                            missingHeaders.Add(Settings.Default.EndDateHeader);
                        }

                        if (!hasMessageColumn)
                        {
                            missingHeaders.Add(Settings.Default.MessageHeader);
                        }

                        foreach (var missingHeader in missingHeaders)
                        {
                            headerCount++;
                            sbMissingHeaders.Append(missingHeader);
                            if (missingHeaders.Count > 1 && headerCount < missingHeaders.Count)
                            {
                                sbMissingHeaders.Append(", ");
                            }
                        }

                        throw new Exception($"Missing header(s): {sbMissingHeaders}");
                    }

                    for (int i = headerRow + 1; i <= workSheet.Dimension.End.Row; i++)
                    {
                        var cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue == null)
                        {
                            break;
                        }
                        if (!hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (j == startDateColumn)
                                {
                                    startDateLocation = j;
                                }

                                if (j == endDateColumn)
                                {
                                    endDateLocation = j;
                                }

                                if (j == releaseNoteTitleColumn)
                                {
                                    releaseNoteTitleLocation = j;
                                }

                                if (j == messageColumn)
                                {
                                    messageLocation = j;
                                }
                            }
                        }

                        startDate = Convert.ToDateTime(workSheet.Cells[i, startDateLocation].Value);
                        endDate = Convert.ToDateTime(workSheet.Cells[i, endDateLocation].Value);
                        message = Convert.ToString(workSheet.Cells[i, messageLocation].Value);
                        releaseNoteTitle = Convert.ToString(workSheet.Cells[i, releaseNoteTitleLocation].Value);

                        using (StreamWriter sw = File.AppendText(updateSqlPath))
                        {
                            sw.WriteLine("Delete From [ReleaseNote] where [ReleaseNoteId] = '" + releaseNoteId + "'");
                            sw.WriteLine("INSERT INTO [ReleaseNote] ([ReleaseNoteID],[ReleaseNoteType],[ReleaseNoteTitle],[ReleaseNoteMessage]) ");
                            sw.WriteLine("VALUES ('" + Settings.Default.ReleaseNoteId + "',1, '" + releaseNoteTitle + "', '" + message + "');");
                            sw.WriteLine();
                            sw.WriteLine("Delete from[ReleaseNoteExtendedInformation] where[ReleaseNoteExtendedInformationID] = '" + releaseNoteId + "'");
                            sw.WriteLine("INSERT INTO [ReleaseNoteExtendedInformation] ([ReleaseNoteExtendedInformationID],[ReleaseNoteID],[StartDate],[EndDate],[Priority],[PDFFileName])");
                            sw.WriteLine("VALUES ('" + releaseNoteId + "', '" + releaseNoteId + "', '" + startDate + "', '" + endDate + "', 1,'')");
                            sw.WriteLine();
                            sw.WriteLine("Delete from [Component] where [ComponentID] = 10000");
                            sw.WriteLine("INSERT INTO [Component] ([ComponentID],[TypeID],[ComponentName],[ExternalID],[Token])");
                            sw.WriteLine("VALUES (1000, 5, 'Release note" + DateTime.Now.ToShortDateString() + "', '" + releaseNoteId + "', 'Release Note')");
                            sw.WriteLine();
                            sw.WriteLine("Delete from [DChannelComponent] where [DChannelComponentID] in (10000,10001, 10002)");
                            sw.WriteLine("INSERT INTO [DChannelComponent] ([DChannelComponentID],[DChannelID],[ComponentID],[Authorization])");
                            sw.WriteLine("VALUES(10000, 0, 10000, 2), (10001,10,10000,2), (10002,12,10000,2)");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error($"Unable to complete the generation of the Message Center SQL Scripts. {ex.Message}.", ex);

                throw new Exception($"Unable to complete the generation of the Message Center SQL Scripts. {ex.Message}.", ex);
            }
        }

        /// <summary>
        /// Generate IUL Rate Data SQL
        /// </summary>
        /// <param name="workSheetCounter"></param>
        /// <param name="fileInfo"></param>
        /// <exception cref="Exception"></exception>
        public void GenerateIULRateDataSql(int workSheetCounter, FileInfo fileInfo)
        {
            if (log.IsInfoEnabled) log.Info($"GenerateIULRateDataSql called with workSheetNumber: {workSheetCounter} in file: {fileInfo.Name}.");

            try
            {
                using (var excelPaclage = new ExcelPackage(fileInfo))
                {
                    var workSheet = excelPaclage.Workbook.Worksheets[workSheetCounter];
                    const bool hasHeader = false;
                    bool hasRateDataIDColumn = false;
                    bool hasRateCodeColumn = false;
                    bool hasRate1Column = false;
                    int rateDataIDLocation = 0;
                    int rateCodeLocation = 0;
                    int rate1Location = 0;
                    int rateDataID = 0;
                    double rate1 = 0;
                    int rateCode = 0;
                    var updateSqlFolder = Settings.Default.IllustrationSqlFileDirectory;
                    int rateDataIDColumn = 0;
                    int rateCodeColumn = 0;
                    int rate1Column = 0;
                    var today = DateTime.Now;
                    var yearMonth = today.Year.ToString() + "-" + today.Month.ToString().PadLeft(2, '0');
                    var updateSqlDirectory = Path.Combine(updateSqlFolder, yearMonth);
                    var headerRow = 0;

                    if (!Directory.Exists(updateSqlDirectory))
                    {
                        Directory.CreateDirectory(updateSqlDirectory);
                    }

                    var excelFilePathParts = fileInfo.FullName.Split(new[] { '\\' });
                    var fileName = excelFilePathParts[excelFilePathParts.Length - 1];
                    var fileNameParts = fileName.Split(new[] { '.' });
                    var fileNameNoExt = fileNameParts[0];
                    var sqlFileName = fileNameNoExt + "_IULRateData_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + ".Sql";
                    var updateSqlPath = Path.Combine(updateSqlDirectory, sqlFileName);

                    Utilities.DeleteDirectory(updateSqlPath);

                    using (StreamWriter sw = File.CreateText(updateSqlPath))
                    {
                        sw.WriteLine("--Start changes for table RateData");
                    }

                    for (int i = workSheet.Dimension.Start.Row; i <= workSheet.Dimension.End.Row; i++)
                    {
                        object cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue != null && !hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (workSheet.Cells[i, j].Value != null)
                                {
                                    if (!hasRateCodeColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.RateCodeHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        headerRow = i;
                                        rateCodeColumn = j;
                                        hasRateCodeColumn = true;
                                    }

                                    if (!hasRateDataIDColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.RateDataIdHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        rateDataIDColumn = j;
                                        hasRateDataIDColumn = true;
                                    }

                                    if (!hasRate1Column && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.Rate1Header, StringComparison.OrdinalIgnoreCase))
                                    {
                                        rate1Column = j;
                                        hasRate1Column = true;
                                    }
                                }
                            }
                        }
                    }

                    if (!hasRateCodeColumn || !hasRate1Column || !hasRateDataIDColumn)
                    {
                        // Did not find one of the headers, need to kill the run and report to the user which one we didn't find
                        List<string> missingHeaders = new List<string>();
                        StringBuilder sbMissingHeaders = new StringBuilder();
                        var headerCount = 0;

                        if (!hasRateCodeColumn)
                        {
                            missingHeaders.Add(Settings.Default.RateCodeHeader);
                        }

                        if (!hasRateDataIDColumn)
                        {
                            missingHeaders.Add(Settings.Default.RateDataIdHeader);
                        }

                        if (!hasRate1Column)
                        {
                            missingHeaders.Add(Settings.Default.Rate1Header);
                        }

                        foreach (var missingHeader in missingHeaders)
                        {
                            headerCount++;
                            sbMissingHeaders.Append(missingHeader);
                            if (missingHeaders.Count > 1 && headerCount < missingHeaders.Count)
                            {
                                sbMissingHeaders.Append(", ");
                            }
                        }

                        throw new Exception("Missing header(s): " + sbMissingHeaders);
                    }

                    for (int i = headerRow + 1; i <= workSheet.Dimension.End.Row; i++)
                    {
                        var cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue == null)
                        {
                            break;
                        }
                        if (!hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (j == rateCodeColumn)
                                {
                                    rateCodeLocation = j;
                                }

                                if (j == rateDataIDColumn)
                                {
                                    rateDataIDLocation = j;
                                }

                                if (j == rate1Column)
                                {
                                    rate1Location = j;
                                }
                            }
                        }

                        rate1 = Convert.ToDouble(workSheet.Cells[i, rate1Location].Value);
                        rateCode = Convert.ToInt32(workSheet.Cells[i, rateCodeLocation].Value);
                        rateDataID = Convert.ToInt32(workSheet.Cells[i, rateDataIDLocation].Value);

                        using (StreamWriter sw = File.AppendText(updateSqlPath))
                        {
                            sw.WriteLine("UPDATE [RateData] SET");
                            sw.WriteLine("[RateCode]=" + rateCode + ",");
                            sw.WriteLine("[Rate1]=" + rate1);
                            sw.WriteLine("WHERE [RateDataID]=" + rateDataID);
                            sw.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Unable to complete the generation of the IUL Rate Data Update SQL Script.", ex);

                throw new Exception("Unable to complete the generation of the IUL Rate Data Update SQL Script.", ex);
            }
        }

        /// <summary>
        /// Generate Expense Minimum Maximum SQL
        /// </summary>
        /// <param name="workSheetCounter"></param>
        /// <param name="fileInfo"></param>
        /// <exception cref="Exception"></exception>
        public void GenerateExpenseMinMaxSql(int workSheetCounter, FileInfo fileInfo)
        {
            if (log.IsInfoEnabled) log.Info($"GenerateExpenseMinMaxSql called with workSheetNumber: {workSheetCounter} in file: {fileInfo.Name}.");

            try
            {
                using (var excelPaclage = new ExcelPackage(fileInfo))
                {
                    var workSheet = excelPaclage.Workbook.Worksheets[workSheetCounter];
                    const bool hasHeader = false;
                    bool hasNamedValueIDColumn = false;
                    bool hasFieldValueColumn = false;
                    int namedValueIdLocation = 0;
                    int fieldValueLocation = 0;
                    double fieldValue = 0;
                    int namedValueId = 0;
                    var updateSqlFolder = Settings.Default.IllustrationSqlFileDirectory;
                    int namedValueIdColumn = 0;
                    int fieldValueColumn = 0;
                    var today = DateTime.Now;
                    var yearMonth = today.Year.ToString() + "-" + today.Month.ToString().PadLeft(2, '0');
                    var updateSqlDirectory = Path.Combine(updateSqlFolder, yearMonth);
                    var headerRow = 0;

                    if (!Directory.Exists(updateSqlDirectory))
                    {
                        Directory.CreateDirectory(updateSqlDirectory);
                    }

                    var excelFilePathParts = fileInfo.FullName.Split(new[] { '\\' });
                    var fileName = excelFilePathParts[excelFilePathParts.Length - 1];
                    var fileNameParts = fileName.Split(new[] { '.' });
                    var fileNameNoExt = fileNameParts[0];
                    var sqlFileName = fileNameNoExt + "_ExpenseMinMax_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + ".Sql";
                    var updateSqlPath = Path.Combine(updateSqlDirectory, sqlFileName);

                    Utilities.DeleteDirectory(updateSqlPath);

                    using (StreamWriter sw = File.CreateText(updateSqlPath))
                    {
                        sw.WriteLine("--Start changes for table NamedValue");
                    }

                    for (int i = workSheet.Dimension.Start.Row; i <= workSheet.Dimension.End.Row; i++)
                    {
                        object cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue != null && !hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (workSheet.Cells[i, j].Value != null)
                                {
                                    if (!hasNamedValueIDColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.NamedValueIdHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        headerRow = i;
                                        namedValueIdColumn = j;
                                        hasNamedValueIDColumn = true;
                                    }

                                    if (!hasFieldValueColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.FieldValueHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        fieldValueColumn = j;
                                        hasFieldValueColumn = true;
                                    }
                                }
                            }
                        }
                    }

                    if (!hasNamedValueIDColumn || !hasFieldValueColumn)
                    {
                        // Did not find one of the headers, need to kill the run and report to the user which one we didn't find
                        List<string> missingHeaders = new List<string>();
                        StringBuilder sbMissingHeaders = new StringBuilder();
                        var headerCount = 0;

                        if (!hasNamedValueIDColumn)
                        {
                            missingHeaders.Add(Settings.Default.NamedValueIdHeader);
                        }

                        if (!hasFieldValueColumn)
                        {
                            missingHeaders.Add(Settings.Default.FieldValueHeader);
                        }

                        foreach (var missingHeader in missingHeaders)
                        {
                            headerCount++;
                            sbMissingHeaders.Append(missingHeader);
                            if (missingHeaders.Count > 1 && headerCount < missingHeaders.Count)
                            {
                                sbMissingHeaders.Append(", ");
                            }
                        }

                        throw new Exception("Missing header(s): " + sbMissingHeaders);
                    }

                    for (int i = headerRow + 1; i <= workSheet.Dimension.End.Row; i++)
                    {
                        var cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue == null)
                        {
                            break;
                        }
                        if (!hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (j == namedValueIdColumn)
                                {
                                    namedValueIdLocation = j;
                                }

                                if (j == fieldValueColumn)
                                {
                                    fieldValueLocation = j;
                                }
                            }
                        }

                        fieldValue = Convert.ToDouble(workSheet.Cells[i, fieldValueLocation].Value);
                        namedValueId = Convert.ToInt32(workSheet.Cells[i, namedValueIdLocation].Value);

                        using (StreamWriter sw = File.AppendText(updateSqlPath))
                        {
                            sw.WriteLine("UPDATE [NamedValue] SET");
                            sw.WriteLine("[FieldValue]=" + fieldValue);
                            sw.WriteLine("WHERE [NamedValueID]=" + namedValueId);
                            sw.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Unable to complete the generation of the VA Expense Min & Max Update SQL Script.", ex);

                throw new Exception("Unable to complete the generation of the VA Expense Min & Max Update SQL Script.", ex);
            }
        }

        /// <summary>
        /// Generate IUL Names Value SQL
        /// </summary>
        /// <param name="workSheetCounter"></param>
        /// <param name="fileInfo"></param>
        /// <exception cref="Exception"></exception>
        public void GenerateIULNamedValueSql(int workSheetCounter, FileInfo fileInfo)
        {
            if (log.IsInfoEnabled) log.Info($"GenerateIULNamedValueSql called with workSheetNumber: {workSheetCounter} in file: {fileInfo.Name}.");

            try
            {
                using (var excelPaclage = new ExcelPackage(fileInfo))
                {
                    var workSheet = excelPaclage.Workbook.Worksheets[workSheetCounter];
                    const bool hasHeader = false;
                    bool hasNamedValueIDColumn = false;
                    bool hasFieldValueColumn = false;
                    int namedValueIdLocation = 0;
                    int fieldValueLocation = 0;
                    double fieldValueValue = 0;
                    int namedValueId = 0;
                    var updateSqlFolder = Settings.Default.IllustrationSqlFileDirectory;
                    int namedValueIdColumn = 0;
                    int fieldValueColumn = 0;
                    var today = DateTime.Now;
                    var yearMonth = today.Year.ToString() + "-" + today.Month.ToString().PadLeft(2, '0');
                    var updateSqlDirectory = Path.Combine(updateSqlFolder, yearMonth);
                    var headerRow = 0;

                    if (!Directory.Exists(updateSqlDirectory))
                    {
                        Directory.CreateDirectory(updateSqlDirectory);
                    }

                    var excelFilePathParts = fileInfo.FullName.Split(new[] { '\\' });
                    var fileName = excelFilePathParts[excelFilePathParts.Length - 1];
                    var fileNameParts = fileName.Split(new[] { '.' });
                    var fileNameNoExt = fileNameParts[0];
                    var sqlFileName = fileNameNoExt + "_IULNamedValue_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + ".Sql";
                    var updateSqlPath = Path.Combine(updateSqlDirectory, sqlFileName);

                    Utilities.DeleteDirectory(updateSqlPath);

                    using (StreamWriter sw = File.CreateText(updateSqlPath))
                    {
                        sw.WriteLine("--Start changes for table NamedValue");
                    }

                    for (int i = workSheet.Dimension.Start.Row; i <= workSheet.Dimension.End.Row; i++)
                    {
                        object cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue != null && !hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (workSheet.Cells[i, j].Value != null)
                                {
                                    if (!hasNamedValueIDColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.NamedValueIdHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        headerRow = i;
                                        namedValueIdColumn = j;
                                        hasNamedValueIDColumn = true;
                                    }

                                    if (!hasFieldValueColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.FieldValueHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        fieldValueColumn = j;
                                        hasFieldValueColumn = true;
                                    }
                                }
                            }
                        }
                    }

                    if (!hasNamedValueIDColumn || !hasFieldValueColumn)
                    {
                        // Did not find one of the headers, need to kill the run and report to the user which one we didn't find
                        List<string> missingHeaders = new List<string>();
                        StringBuilder sbMissingHeaders = new StringBuilder();
                        var headerCount = 0;

                        if (!hasNamedValueIDColumn)
                        {
                            missingHeaders.Add(Settings.Default.NamedValueIdHeader);
                        }

                        if (!hasFieldValueColumn)
                        {
                            missingHeaders.Add(Settings.Default.FieldValueHeader);
                        }

                        foreach (var missingHeader in missingHeaders)
                        {
                            headerCount++;
                            sbMissingHeaders.Append(missingHeader);
                            if (missingHeaders.Count > 1 && headerCount < missingHeaders.Count)
                            {
                                sbMissingHeaders.Append(", ");
                            }
                        }

                        throw new Exception("Missing header(s): " + sbMissingHeaders);
                    }

                    for (int i = headerRow + 1; i <= workSheet.Dimension.End.Row; i++)
                    {
                        var cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue == null)
                        {
                            break;
                        }
                        if (!hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (j == namedValueIdColumn)
                                {
                                    namedValueIdLocation = j;
                                }

                                if (j == fieldValueColumn)
                                {
                                    fieldValueLocation = j;
                                }
                            }
                        }

                        fieldValueValue = Convert.ToDouble(workSheet.Cells[i, fieldValueLocation].Value);
                        namedValueId = Convert.ToInt32(workSheet.Cells[i, namedValueIdLocation].Value);

                        using (StreamWriter sw = File.AppendText(updateSqlPath))
                        {
                            sw.WriteLine("UPDATE [NamedValue] SET");
                            sw.WriteLine("[FieldValue]=" + fieldValueValue);
                            sw.WriteLine("WHERE [NamedValueID]=" + namedValueId);
                            sw.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Unable to complete the generation of the IUL Named Value Update SQL Script.", ex);

                throw new Exception("Unable to complete the generation of the IUL Named Value Update SQL Script.", ex);
            }
        }

        /// <summary>
        /// Generate IUL Plan Common Data SQL
        /// </summary>
        /// <param name="workSheetCounter"></param>
        /// <param name="fileInfo"></param>
        /// <exception cref="Exception"></exception>
        public void GenerateIULPlanCommonDataSql(int workSheetCounter, FileInfo fileInfo)
        {
            if (log.IsInfoEnabled) log.Info($"GenerateIULPlanCommonDataSql called with workSheetNumber: {workSheetCounter} in file: {fileInfo.Name}.");

            try
            {
                using (var excelPaclage = new ExcelPackage(fileInfo))
                {
                    var workSheet = excelPaclage.Workbook.Worksheets[workSheetCounter];
                    const bool hasHeader = false;
                    bool hasPlanCommonIDColumn = false;
                    bool hasGuarRateColumn = false;
                    int planCommonIdLocation = 0;
                    int guarRateLocation = 0;
                    double guarRateValue = 0;
                    int planCommonId = 0;
                    var updateSqlFolder = Settings.Default.IllustrationSqlFileDirectory;
                    int planCommonIdColumn = 0;
                    int guarRateColumn = 0;
                    var today = DateTime.Now;
                    var yearMonth = today.Year.ToString() + "-" + today.Month.ToString().PadLeft(2, '0');
                    var updateSqlDirectory = Path.Combine(updateSqlFolder, yearMonth);
                    var headerRow = 0;

                    if (!Directory.Exists(updateSqlDirectory))
                    {
                        Directory.CreateDirectory(updateSqlDirectory);
                    }

                    var excelFilePathParts = fileInfo.FullName.Split(new[] { '\\' });
                    var fileName = excelFilePathParts[excelFilePathParts.Length - 1];
                    var fileNameParts = fileName.Split(new[] { '.' });
                    var fileNameNoExt = fileNameParts[0];
                    var sqlFileName = fileNameNoExt + "_IULPlanCommonData_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + ".Sql";
                    var updateSqlPath = Path.Combine(updateSqlDirectory, sqlFileName);

                    Utilities.DeleteDirectory(updateSqlPath);

                    using (StreamWriter sw = File.CreateText(updateSqlPath))
                    {
                        sw.WriteLine("--Start changes for table PlanCommonData");
                    }

                    for (int i = workSheet.Dimension.Start.Row; i <= workSheet.Dimension.End.Row; i++)
                    {
                        object cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue != null && !hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (workSheet.Cells[i, j].Value != null)
                                {
                                    if (!hasPlanCommonIDColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.PlanCommonIDHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        headerRow = i;
                                        planCommonIdColumn = j;
                                        hasPlanCommonIDColumn = true;
                                    }

                                    if (!hasGuarRateColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.GuarRateHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        guarRateColumn = j;
                                        hasGuarRateColumn = true;
                                    }
                                }
                            }
                        }
                    }

                    if (!hasPlanCommonIDColumn || !hasGuarRateColumn)
                    {
                        // Did not find one of the headers, need to kill the run and report to the user which one we didn't find
                        List<string> missingHeaders = new List<string>();
                        StringBuilder sbMissingHeaders = new StringBuilder();
                        var headerCount = 0;

                        if (!hasPlanCommonIDColumn)
                        {
                            missingHeaders.Add(Settings.Default.PlanCommonIDHeader);
                        }

                        if (!hasGuarRateColumn)
                        {
                            missingHeaders.Add(Settings.Default.GuarRateHeader);
                        }

                        foreach (var missingHeader in missingHeaders)
                        {
                            headerCount++;
                            sbMissingHeaders.Append(missingHeader);
                            if (missingHeaders.Count > 1 && headerCount < missingHeaders.Count)
                            {
                                sbMissingHeaders.Append(", ");
                            }
                        }

                        throw new Exception("Missing header(s): " + sbMissingHeaders);
                    }

                    for (int i = headerRow + 1; i <= workSheet.Dimension.End.Row; i++)
                    {
                        var cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue == null)
                        {
                            break;
                        }
                        if (!hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (j == planCommonIdColumn)
                                {
                                    planCommonIdLocation = j;
                                }

                                if (j == guarRateColumn)
                                {
                                    guarRateLocation = j;
                                }
                            }
                        }

                        guarRateValue = Convert.ToDouble(workSheet.Cells[i, guarRateLocation].Value);
                        planCommonId = Convert.ToInt32(workSheet.Cells[i, planCommonIdLocation].Value);

                        using (StreamWriter sw = File.AppendText(updateSqlPath))
                        {
                            sw.WriteLine("UPDATE [PlanCommonData] SET");
                            sw.WriteLine("[GuarRate]=" + guarRateValue);
                            sw.WriteLine("WHERE [PlanCommonID]=" + planCommonId);
                            sw.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Unable to complete the generation of the IUL Plan Common Data SQL Script.", ex);

                throw new Exception("Unable to complete the generation of the IUL Plan Common Data SQL Script.", ex);
            }
        }

        /// <summary>
        /// Generate Va Expense SQL
        /// </summary>
        /// <param name="workSheetCounter"></param>
        /// <param name="fileInfo"></param>
        /// <exception cref="Exception"></exception>
        public void GenerateVaExpenseSql(int workSheetCounter, FileInfo fileInfo)
        {
            if (log.IsInfoEnabled) log.Info($"GenerateVaExpenseSql called with workSheetNumber: {workSheetCounter} in file: {fileInfo.Name}.");

            try
            {
                using (var excelPaclage = new ExcelPackage(fileInfo))
                {
                    var workSheet = excelPaclage.Workbook.Worksheets[workSheetCounter];
                    const bool hasHeader = false;
                    bool hasFundCodeColumn = false;
                    bool hasFundExpensePctColumn = false;
                    int fundCodeLocation = 0;
                    int fundExpensePctLocation = 0;
                    double fundExpensePct = 0;
                    int fundCode = 0;
                    var updateSqlFolder = Settings.Default.IllustrationSqlFileDirectory;
                    int fundCodeColumn = 0;
                    int fundExpensePctColumn = 0;
                    var today = DateTime.Now;
                    var yearMonth = today.Year.ToString() + "-" + today.Month.ToString().PadLeft(2, '0');
                    var updateSqlDirectory = Path.Combine(updateSqlFolder, yearMonth);
                    var headerRow = 0;

                    if (!Directory.Exists(updateSqlDirectory))
                    {
                        Directory.CreateDirectory(updateSqlDirectory);
                    }

                    var excelFilePathParts = fileInfo.FullName.Split(new[] { '\\' });
                    var fileName = excelFilePathParts[excelFilePathParts.Length - 1];
                    var fileNameParts = fileName.Split(new[] { '.' });
                    var fileNameNoExt = fileNameParts[0];
                    var sqlFileName = fileNameNoExt + "_VaExpense_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + ".Sql";
                    var updateSqlPath = Path.Combine(updateSqlDirectory, sqlFileName);

                    Utilities.DeleteDirectory(updateSqlPath);

                    using (StreamWriter sw = File.CreateText(updateSqlPath))
                    {
                        sw.WriteLine("--Start changes for table FundData");
                    }

                    for (int i = workSheet.Dimension.Start.Row; i <= workSheet.Dimension.End.Row; i++)
                    {
                        object cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue != null && !hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (workSheet.Cells[i, j].Value != null)
                                {
                                    if (!hasFundCodeColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.FundCodeHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        headerRow = i;
                                        fundCodeColumn = j;
                                        hasFundCodeColumn = true;
                                    }

                                    if (!hasFundExpensePctColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.FundExpensePctHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        fundExpensePctColumn = j;
                                        hasFundExpensePctColumn = true;
                                    }
                                }
                            }
                        }
                    }

                    if (!hasFundCodeColumn || !hasFundExpensePctColumn)
                    {
                        // Did not find one of the headers, need to kill the run and report to the user which one we didn't find
                        List<string> missingHeaders = new List<string>();
                        StringBuilder sbMissingHeaders = new StringBuilder();
                        var headerCount = 0;

                        if (!hasFundCodeColumn)
                        {
                            missingHeaders.Add(Settings.Default.FundCodeHeader);
                        }

                        if (!hasFundExpensePctColumn)
                        {
                            missingHeaders.Add(Settings.Default.FundExpensePctHeader);
                        }

                        foreach (var missingHeader in missingHeaders)
                        {
                            headerCount++;
                            sbMissingHeaders.Append(missingHeader);
                            if (missingHeaders.Count > 1 && headerCount < missingHeaders.Count)
                            {
                                sbMissingHeaders.Append(", ");
                            }
                        }

                        throw new Exception("Missing header(s): " + sbMissingHeaders);
                    }

                    for (int i = headerRow + 1; i <= workSheet.Dimension.End.Row; i++)
                    {
                        var cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue == null)
                        {
                            break;
                        }
                        if (!hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (j == fundCodeColumn)
                                {
                                    fundCodeLocation = j;
                                }

                                if (j == fundExpensePctColumn)
                                {
                                    fundExpensePctLocation = j;
                                }
                            }
                        }

                        fundExpensePct = Convert.ToDouble(workSheet.Cells[i, fundExpensePctLocation].Value);
                        fundCode = Convert.ToInt32(workSheet.Cells[i, fundCodeLocation].Value);

                        using (StreamWriter sw = File.AppendText(updateSqlPath))
                        {
                            sw.WriteLine("UPDATE [FundData] SET");
                            sw.WriteLine("[FundCode]=" + fundCode + ",");
                            sw.WriteLine("[FundExpensePct]=" + fundExpensePct);
                            sw.WriteLine("WHERE [FundCode]=" + fundCode);
                            sw.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Unable to complete the generation of the VA Expense Update SQL Script.", ex);

                throw new Exception("Unable to complete the generation of the VA Expense Update SQL Script.", ex);
            }
        }

        /// <summary>
        /// Generate VA Unit Update SQL
        /// </summary>
        /// <param name="workSheetCounter"></param>
        /// <param name="fileInfo"></param>
        /// <exception cref="Exception"></exception>
        public void GenerateVaUnitUpdateSql(int workSheetCounter, FileInfo fileInfo)
        {
            if (log.IsInfoEnabled) log.Info($"GenerateVaUnitUpdateSql called with workSheetNumber: {workSheetCounter} in file: {fileInfo.Name}.");

            RateDataUtils rateDataUtils = new RateDataUtils();

            try
            {
                using (var excelPaclage = new ExcelPackage(fileInfo))
                {
                    var workSheet = excelPaclage.Workbook.Worksheets[workSheetCounter];
                    const bool hasHeader = false;
                    bool hasRateCodeColumn = false;
                    bool hasBandColumn = false;
                    bool hasRateColumn = false;
                    bool hasAgeColumn = false;
                    bool hasYearColumn = false;
                    int rateCodeLocation = 0;
                    int bandLocation = 0;
                    int rateLocation = 0;
                    int ageLocation = 0;
                    int yearLocation = 0;
                    double rate = 0;
                    int rateCode = 0;
                    int band = 0;
                    int age = 0;
                    int year = 0;
                    var updateSqlFolder = Settings.Default.IllustrationSqlFileDirectory;
                    int rateDataID = 0;
                    string rateNumber = string.Empty;
                    int rateColumn = 0;
                    int rateCodeColumn = 0;
                    int bandColumn = 0;
                    int ageColumn = 0;
                    int yearColumn = 0;
                    int yearEndNum = 0;
                    var today = DateTime.Now;
                    var yearMonth = today.Year.ToString() + "-" + today.Month.ToString().PadLeft(2, '0');
                    var updateSqlDirectory = Path.Combine(updateSqlFolder, yearMonth);
                    var headerRow = 0;

                    if (!Directory.Exists(updateSqlDirectory))
                    {
                        Directory.CreateDirectory(updateSqlDirectory);
                    }

                    var excelFilePathParts = fileInfo.FullName.Split(new[] { '\\' });
                    var fileName = excelFilePathParts[excelFilePathParts.Length - 1];
                    var fileNameParts = fileName.Split(new[] { '.' });
                    var fileNameNoExt = fileNameParts[0];
                    var sqlFileName = fileNameNoExt + "_VaUnit_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + ".Sql";
                    var updateSqlPath = Path.Combine(updateSqlDirectory, sqlFileName);

                    Utilities.DeleteDirectory(updateSqlPath);

                    using (StreamWriter sw = File.CreateText(updateSqlPath))
                    {
                        sw.WriteLine("--Start changes for table RateData");
                    }

                    for (int i = workSheet.Dimension.Start.Row; i <= workSheet.Dimension.End.Row; i++)
                    {
                        object cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue != null && !hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (workSheet.Cells[i, j].Value != null)
                                {
                                    if (!hasRateCodeColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.RateCodeHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        headerRow = i;
                                        rateCodeColumn = j;
                                        hasRateCodeColumn = true;
                                    }

                                    if (!hasBandColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.BandHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        bandColumn = j;
                                        hasBandColumn = true;
                                    }

                                    if (!hasRateColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.RateHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        rateColumn = j;
                                        hasRateColumn = true;
                                    }

                                    if (!hasAgeColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.AgeHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        ageColumn = j;
                                        hasAgeColumn = true;
                                    }

                                    if (!hasYearColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.YearHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        yearColumn = j;
                                        hasYearColumn = true;
                                    }
                                }
                            }
                        }
                    }

                    if (!hasRateColumn || !hasBandColumn || !hasRateCodeColumn || !hasYearColumn || !hasAgeColumn)
                    {
                        // Did not find one of the headers, need to kill the run and report to the user which one we didn't find
                        List<string> missingHeaders = new List<string>();
                        StringBuilder sbMissingHeaders = new StringBuilder();
                        var headerCount = 0;

                        if (!hasRateColumn)
                        {
                            missingHeaders.Add(Settings.Default.RateHeader);
                        }

                        if (!hasRateCodeColumn)
                        {
                            missingHeaders.Add(Settings.Default.RateCodeHeader);
                        }

                        if (!hasBandColumn)
                        {
                            missingHeaders.Add(Settings.Default.BandHeader);
                        }

                        if (!hasAgeColumn)
                        {
                            missingHeaders.Add(Settings.Default.AgeHeader);
                        }

                        if (!hasYearColumn)
                        {
                            missingHeaders.Add(Settings.Default.YearHeader);
                        }

                        foreach (var missingHeader in missingHeaders)
                        {
                            headerCount++;
                            sbMissingHeaders.Append(missingHeader);
                            if (missingHeaders.Count > 1 && headerCount < missingHeaders.Count)
                            {
                                sbMissingHeaders.Append(", ");
                            }
                        }

                        throw new Exception("Missing header(s): " + sbMissingHeaders);
                    }

                    for (int i = headerRow + 1; i <= workSheet.Dimension.End.Row; i++)
                    {
                        var cellValue = workSheet.Cells[i, 2].Value;

                        if (cellValue == null)
                        {
                            break;
                        }
                        if (!hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (j == rateCodeColumn)
                                {
                                    rateCodeLocation = j;
                                }

                                if (j == bandColumn)
                                {
                                    bandLocation = j;
                                }

                                if (j == rateColumn)
                                {
                                    rateLocation = j;
                                }

                                if (j == ageColumn)
                                {
                                    ageLocation = j;
                                }

                                if (j == yearColumn)
                                {
                                    yearLocation = j;
                                }
                            }
                        }

                        rate = Convert.ToDouble(workSheet.Cells[i, rateLocation].Value);
                        band = Convert.ToInt32(workSheet.Cells[i, bandLocation].Value);
                        rateCode = Convert.ToInt32(workSheet.Cells[i, rateCodeLocation].Value);
                        age = Convert.ToInt32(workSheet.Cells[i, ageLocation].Value);
                        year = Convert.ToInt32(workSheet.Cells[i, yearLocation].Value);

                        rateDataID = rateDataUtils.GetRateDataId(rateCode, band, age);

                        yearEndNum = (year % 10);

                        switch (yearEndNum)
                        {
                            case 0:
                                rateNumber = "Rate1";
                                break;

                            case 1:
                                rateNumber = "Rate2";
                                break;

                            case 2:
                                rateNumber = "Rate3";
                                break;

                            case 3:
                                rateNumber = "Rate4";
                                break;

                            case 4:
                                rateNumber = "Rate5";
                                break;

                            case 5:
                                rateNumber = "Rate6";
                                break;

                            case 6:
                                rateNumber = "Rate7";
                                break;

                            case 7:
                                rateNumber = "Rate8";
                                break;

                            case 8:
                                rateNumber = "Rate9";
                                break;

                            case 9:
                                rateNumber = "Rate10";
                                break;
                        }

                        using (StreamWriter sw = File.AppendText(updateSqlPath))
                        {
                            sw.WriteLine("UPDATE [RateData] SET");
                            sw.WriteLine("[RateDataId]=" + rateDataID + ",");
                            sw.WriteLine("[RateCode]=" + rateCode + ",");
                            sw.WriteLine("[Age]=" + age + ",");
                            sw.WriteLine("[Band]=" + band + ",");
                            sw.WriteLine("[" + rateNumber + "]=" + rate);
                            sw.WriteLine("WHERE [RateDataID]=" + rateDataID);
                            sw.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Unable to complete the generation of the VA Unit Update SQL Script.", ex);

                throw new Exception("Unable to complete the generation of the VA Unit Update SQL Script.", ex);
            }
        }

        /// <summary>
        /// Generate MIR Plan Common Data SQL
        /// </summary>
        /// <param name="workSheetCounter"></param>
        /// <param name="fileInfo"></param>
        /// <exception cref="Exception"></exception>
        public void GenerateMIRPlanCommonDataSql(int workSheetCounter, FileInfo fileInfo)
        {
            if (log.IsInfoEnabled) log.Info($"GenerateMIRPlanCommonDataSql called with workSheetNumber: {workSheetCounter} in file: {fileInfo.Name}.");

            try
            {
                using (var excelPaclage = new ExcelPackage(fileInfo))
                {
                    var workSheet = excelPaclage.Workbook.Worksheets[workSheetCounter];
                    const bool hasHeader = false;
                    bool hasPlanCommonIDColumn = false;
                    bool hasGuarRateColumn = false;
                    bool hasInitGuarRateColumn = false;
                    int planCommonIdLocation = 0;
                    int guarRateLocation = 0;
                    int initGuarRateLocation = 0;
                    double guarRateValue = 0;
                    double initGuarRateValue = 0;
                    int planCommonId = 0;
                    var updateSqlFolder = Settings.Default.IllustrationSqlFileDirectory;
                    int planCommonIdColumn = 0;
                    int guarRateColumn = 0;
                    int initGuarRateColumn = 0;
                    var today = DateTime.Now;
                    var yearMonth = today.Year.ToString() + "-" + today.Month.ToString().PadLeft(2, '0');
                    var updateSqlDirectory = Path.Combine(updateSqlFolder, yearMonth);
                    var headerRow = 0;

                    if (!Directory.Exists(updateSqlDirectory))
                    {
                        Directory.CreateDirectory(updateSqlDirectory);
                    }

                    var excelFilePathParts = fileInfo.FullName.Split(new[] { '\\' });
                    var fileName = excelFilePathParts[excelFilePathParts.Length - 1];
                    var fileNameParts = fileName.Split(new[] { '.' });
                    var fileNameNoExt = fileNameParts[0];
                    var sqlFileName = fileNameNoExt + "_MIRPlanCommonData_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + ".Sql";
                    var updateSqlPath = Path.Combine(updateSqlDirectory, sqlFileName);

                    Utilities.DeleteDirectory(updateSqlPath);

                    using (StreamWriter sw = File.CreateText(updateSqlPath))
                    {
                        sw.WriteLine("--Start changes for table PlanCommonData");
                    }

                    for (int i = workSheet.Dimension.Start.Row; i <= workSheet.Dimension.End.Row; i++)
                    {
                        object cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue != null && !hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (workSheet.Cells[i, j].Value != null)
                                {
                                    if (!hasPlanCommonIDColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.PlanCommonIDHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        headerRow = i;
                                        planCommonIdColumn = j;
                                        hasPlanCommonIDColumn = true;
                                    }

                                    if (!hasGuarRateColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.GuarRateHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        guarRateColumn = j;
                                        hasGuarRateColumn = true;
                                    }

                                    if (!hasInitGuarRateColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.InitGuarRateHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        initGuarRateColumn = j;
                                        hasInitGuarRateColumn = true;
                                    }
                                }
                            }
                        }
                    }

                    if (!hasPlanCommonIDColumn || !hasGuarRateColumn || !hasInitGuarRateColumn)
                    {
                        // Did not find one of the headers, need to kill the run and report to the user which one we didn't find
                        List<string> missingHeaders = new List<string>();
                        StringBuilder sbMissingHeaders = new StringBuilder();
                        var headerCount = 0;

                        if (!hasPlanCommonIDColumn)
                        {
                            missingHeaders.Add(Settings.Default.PlanCommonIDHeader);
                        }

                        if (!hasGuarRateColumn)
                        {
                            missingHeaders.Add(Settings.Default.GuarRateHeader);
                        }

                        if (!hasInitGuarRateColumn)
                        {
                            missingHeaders.Add(Settings.Default.InitGuarRateHeader);
                        }

                        foreach (var missingHeader in missingHeaders)
                        {
                            headerCount++;
                            sbMissingHeaders.Append(missingHeader);
                            if (missingHeaders.Count > 1 && headerCount < missingHeaders.Count)
                            {
                                sbMissingHeaders.Append(", ");
                            }
                        }

                        throw new Exception("Missing header(s): " + sbMissingHeaders);
                    }

                    for (int i = headerRow + 1; i <= workSheet.Dimension.End.Row; i++)
                    {
                        var cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue == null)
                        {
                            break;
                        }
                        if (!hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (j == planCommonIdColumn)
                                {
                                    planCommonIdLocation = j;
                                }

                                if (j == guarRateColumn)
                                {
                                    guarRateLocation = j;
                                }

                                if (j == initGuarRateColumn)
                                {
                                    initGuarRateLocation = j;
                                }
                            }
                        }

                        guarRateValue = Convert.ToDouble(workSheet.Cells[i, guarRateLocation].Value);
                        planCommonId = Convert.ToInt32(workSheet.Cells[i, planCommonIdLocation].Value);
                        initGuarRateValue = Convert.ToDouble(workSheet.Cells[i, initGuarRateLocation].Value);

                        using (StreamWriter sw = File.AppendText(updateSqlPath))
                        {
                            sw.WriteLine("UPDATE [PlanCommonData] SET");
                            sw.WriteLine("[GuarRate]=" + guarRateValue + ",");
                            sw.WriteLine("[InitGuarRate]=" + initGuarRateValue);
                            sw.WriteLine("WHERE [PlanCommonID]=" + planCommonId);
                            sw.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Unable to complete the generation of the MIR Plan Common Data SQL Script.", ex);

                throw new Exception("Unable to complete the generation of the MIR Plan Common Data SQL Script.", ex);
            }
        }

        /// <summary>
        /// Generate MIR Rate Data SQL
        /// </summary>
        /// <param name="workSheetCounter"></param>
        /// <param name="fileInfo"></param>
        /// <exception cref="Exception"></exception>
        public void GenerateMIRRateDataSql(int workSheetCounter, FileInfo fileInfo)
        {
            if (log.IsInfoEnabled) log.Info($"GenerateMIRRateDataSql called with workSheetNumber: {workSheetCounter} in file: {fileInfo.Name}.");

            try
            {
                using (var excelPaclage = new ExcelPackage(fileInfo))
                {
                    var workSheet = excelPaclage.Workbook.Worksheets[workSheetCounter];
                    const bool hasHeader = false;
                    bool hasRateDataIDColumn = false;
                    bool hasRate1Column = false;
                    bool hasRateCodeColumn = false;
                    int rateDataIdLocation = 0;
                    int rate1Location = 0;
                    int rateCodeLocation = 0;
                    double rate1Value = 0;
                    int rateCodeValue = 0;
                    int rateDataId = 0;
                    var updateSqlFolder = Settings.Default.IllustrationSqlFileDirectory;
                    int rateDataIdColumn = 0;
                    int rate1Column = 0;
                    int rateCodeColumn = 0;
                    var today = DateTime.Now;
                    var yearMonth = today.Year.ToString() + "-" + today.Month.ToString().PadLeft(2, '0');
                    var updateSqlDirectory = Path.Combine(updateSqlFolder, yearMonth);
                    var headerRow = 0;

                    if (!Directory.Exists(updateSqlDirectory))
                    {
                        Directory.CreateDirectory(updateSqlDirectory);
                    }

                    var excelFilePathParts = fileInfo.FullName.Split(new[] { '\\' });
                    var fileName = excelFilePathParts[excelFilePathParts.Length - 1];
                    var fileNameParts = fileName.Split(new[] { '.' });
                    var fileNameNoExt = fileNameParts[0];
                    var sqlFileName = fileNameNoExt + "_MIRRateData_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + ".Sql";
                    var updateSqlPath = Path.Combine(updateSqlDirectory, sqlFileName);

                    Utilities.DeleteDirectory(updateSqlPath);

                    using (StreamWriter sw = File.CreateText(updateSqlPath))
                    {
                        sw.WriteLine("--Start changes for table RateData");
                    }

                    for (int i = workSheet.Dimension.Start.Row; i <= workSheet.Dimension.End.Row; i++)
                    {
                        object cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue != null && !hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (workSheet.Cells[i, j].Value != null)
                                {
                                    if (!hasRateDataIDColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.RateDataIdHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        headerRow = i;
                                        rateDataIdColumn = j;
                                        hasRateDataIDColumn = true;
                                    }

                                    if (!hasRate1Column && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.Rate1Header, StringComparison.OrdinalIgnoreCase))
                                    {
                                        rate1Column = j;
                                        hasRate1Column = true;
                                    }

                                    if (!hasRateCodeColumn && string.Equals(workSheet.Cells[i, j].Value.ToString(), Settings.Default.RateCodeHeader, StringComparison.OrdinalIgnoreCase))
                                    {
                                        rateCodeColumn = j;
                                        hasRateCodeColumn = true;
                                    }
                                }
                            }
                        }
                    }

                    if (!hasRateDataIDColumn || !hasRate1Column || !hasRateCodeColumn)
                    {
                        // Did not find one of the headers, need to kill the run and report to the user which one we didn't find
                        List<string> missingHeaders = new List<string>();
                        StringBuilder sbMissingHeaders = new StringBuilder();
                        var headerCount = 0;

                        if (!hasRateDataIDColumn)
                        {
                            missingHeaders.Add(Settings.Default.RateDataIdHeader);
                        }

                        if (!hasRate1Column)
                        {
                            missingHeaders.Add(Settings.Default.Rate1Header);
                        }

                        if (!hasRateCodeColumn)
                        {
                            missingHeaders.Add(Settings.Default.RateCodeHeader);
                        }

                        foreach (var missingHeader in missingHeaders)
                        {
                            headerCount++;
                            sbMissingHeaders.Append(missingHeader);
                            if (missingHeaders.Count > 1 && headerCount < missingHeaders.Count)
                            {
                                sbMissingHeaders.Append(", ");
                            }
                        }

                        throw new Exception("Missing header(s): " + sbMissingHeaders);
                    }

                    for (int i = headerRow + 1; i <= workSheet.Dimension.End.Row; i++)
                    {
                        var cellValue = workSheet.Cells[i, 1].Value;

                        if (cellValue == null)
                        {
                            break;
                        }
                        if (!hasHeader)
                        {
                            for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                            {
                                if (j == rateDataIdColumn)
                                {
                                    rateDataIdLocation = j;
                                }

                                if (j == rate1Column)
                                {
                                    rate1Location = j;
                                }

                                if (j == rateCodeColumn)
                                {
                                    rateCodeLocation = j;
                                }
                            }
                        }

                        rate1Value = Convert.ToDouble(workSheet.Cells[i, rate1Location].Value);
                        rateDataId = Convert.ToInt32(workSheet.Cells[i, rateDataIdLocation].Value);
                        rateCodeValue = Convert.ToInt32(workSheet.Cells[i, rateCodeLocation].Value);

                        using (StreamWriter sw = File.AppendText(updateSqlPath))
                        {
                            sw.WriteLine("UPDATE [RateData] SET");
                            sw.WriteLine("[RateCode]=" + rateCodeValue + ",");
                            sw.WriteLine("[Rate1]=" + rate1Value);
                            sw.WriteLine("WHERE [RateDataID]=" + rateDataId);
                            sw.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) log.Error("Unable to complete the generation of the MIR Rate Data SQL Script.", ex);

                throw new Exception("Unable to complete the generation of the MIR Rate Data SQL Script.", ex);
            }
        }
    }
}