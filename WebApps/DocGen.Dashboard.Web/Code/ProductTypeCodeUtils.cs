using log4net;
using System.Collections.Generic;
using System.Linq;
using WOW.IllustrationMgmntTool.Common.DAL;

namespace LPA.Dashboard.Web.Code
{
    /// <summary>
    /// The product type code utilities.
    /// </summary>
    public class ProductTypeCodeUtils
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ProductTypeCodeUtils));

        /// <summary>
        /// Gets the product type codes.
        /// </summary>
        /// <returns>A list of strings.</returns>
        public List<string> GetProductTypeCodes()
        {
            if (log.IsInfoEnabled) log.Info("GetProductTypeCodes called.");

            ProductTypeCodeLogic productTypeCodeLogic = new ProductTypeCodeLogic();
            var productTypeCodeList = productTypeCodeLogic.GetProductTypeCodes();
            return productTypeCodeList.OrderBy(p => p.ProductTypeCode).Select(p => p.ProductTypeCode).ToList();
        }
    }
}