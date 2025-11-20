using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WOW.MobileRaterService.Data
{
    /// <summary>
    /// Class containing methods for converting between data sources.
    /// </summary>
    internal static class Conversions
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Conversions));

        /// <summary>
        /// Translates the data type to the .NET equivalent.
        /// </summary>
        /// <param name="dbType">The OleDb data type.</param>
        /// <returns>The .NET data type.</returns>
        static internal Type TranslateType(OleDbType dbType)
        {
            Type netType = null;

            switch (dbType)
            {
                case OleDbType.Char:
                case OleDbType.VarChar:
                    netType = typeof(string);
                    break;

                case OleDbType.Decimal:
                case OleDbType.Currency:
                case OleDbType.Numeric:
                    netType = typeof(decimal);
                    break;

                case OleDbType.Double:

                    netType = typeof(double);

                    break;
                case OleDbType.Integer:
                    netType = typeof(int);
                    break;

                case OleDbType.Single:
                    netType = typeof(float);
                    break;

                case OleDbType.SmallInt:
                    netType = typeof(short);
                    break;

                case OleDbType.Date:
                case OleDbType.DBDate:
                case OleDbType.DBTimeStamp:
                    netType = typeof(DateTime);
                    break;

                case OleDbType.Boolean:
                    netType = typeof(bool);
                    break;

                case OleDbType.Binary:
                case OleDbType.LongVarBinary:
                case OleDbType.VarBinary:
                    netType = typeof(byte[]);
                    break;

                default:
                    if (log.IsWarnEnabled) log.WarnFormat(CultureInfo.InvariantCulture, "Unexpected OleDbType: {0}", dbType);
                    netType = typeof(string);
                    break;
            }

            return netType;
        }

        /// <summary>
        /// Translates the data type to the .NET equivalent.
        /// </summary>
        /// <param name="dbType">The SqlDb data type.</param>
        /// <returns>The .NET data type.</returns>
        static internal System.Type TranslateType(SqlDbType dbType)
        {
            System.Type netType = null;

            switch (dbType)
            {
                case SqlDbType.Char:
                case SqlDbType.VarChar:
                case SqlDbType.NChar:
                case SqlDbType.NVarChar:
                    netType = typeof(string);
                    break;

                case SqlDbType.Decimal:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney:
                    netType = typeof(decimal);
                    break;

                case SqlDbType.Float:
                    netType = typeof(double);
                    break;

                case SqlDbType.Int:
                    netType = typeof(int);
                    break;

                case SqlDbType.Real:
                    netType = typeof(float);
                    break;

                case SqlDbType.SmallInt:
                    netType = typeof(short);
                    break;

                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.SmallDateTime:
                case SqlDbType.Time:
                    netType = typeof(DateTime);
                    break;

                case SqlDbType.Bit:
                    netType = typeof(bool);
                    break;

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.VarBinary:
                    netType = typeof(byte[]);
                    break;

                default:
                    if (log.IsWarnEnabled) log.WarnFormat(CultureInfo.InvariantCulture, "Unexpected SqlDbType: {0}", dbType);
                    netType = typeof(string);
                    break;
            }

            return netType;
        }
    }
}