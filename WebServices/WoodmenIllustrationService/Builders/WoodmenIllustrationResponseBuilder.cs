using System;
using System.Globalization;
using WOW.Illustration.Model.ACORD;
using WOW.Illustration.Model.Generation.Response;

namespace WOW.WoodmenIllustrationService.Builders
{
    public static class WoodmenIllustrationResponseBuilder
    {

        public static WoodmenIllustrationResponse BuildFromTXLife(TXLife acordResponseObject)
        {
            if (acordResponseObject == null)
            {
                throw new ArgumentNullException("acordResponseObject", "ACORD Response Object cannot be null.");
            }

            var response = new WoodmenIllustrationResponse();

            try
            {
                // Find the part of the TX Life with the attachments
                foreach (var item in acordResponseObject.Items)
                {
                    var txLifeResponse = item as TXLifeResponse;

                    if (txLifeResponse != null)
                    {
                        //Failure	RESULT_FAILURE	5
                        //Received Pending (transaction in queue)	RESULT_RECDPEND	3
                        //Received Pending with information	RESULT_RECDPENDINFO	4
                        //Success	RESULT_SUCCESS	1
                        //Success with information	RESULT_SUCCESSINFO	2
                        int resultCode;

                        if (Int32.TryParse(txLifeResponse.TransResult.ResultCode.tc, out resultCode) && resultCode == 1)
                        {
                            foreach (var attachment in txLifeResponse.IllustrationResult.Attachment)
                            {
                                if (attachment.MimeTypeTC.tc == OLI_LU_MIMETYPE_TC.OLI_MIMETYPE_PDF)
                                {
                                    // Found a PDF
                                    response.PdfFileAttachment = attachment.AttachmentData;
                                }

                                if (attachment.MimeTypeTC.tc == OLI_LU_MIMETYPE_TC.OLI_MIMETYPE_TEXTPLAIN)
                                {
                                    // Found a PDF
                                    response.ValuesFileAttachment = attachment.AttachmentData;
                                }
                            }
                        }
                        else
                        {
                            response.ErrorMessage = string.Format(CultureInfo.InvariantCulture, "The illustration request has failed. Error Code: {0}", resultCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("There was an error extracting the attachments from the TXLife Response Object.", "acordResponseObject", ex);
            }

            return response;
        }
    }
}