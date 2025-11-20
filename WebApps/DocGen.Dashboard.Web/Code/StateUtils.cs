using log4net;
using System.Collections.Generic;
using System.Web.Mvc;
using WOW.IllustrationMgmntTool.Common.DAL;

namespace LPA.Dashboard.Web.Code
{
    /// <summary>
    /// The state utilities.
    /// </summary>
    public class StateUtils
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(StateUtils));

        /// <summary>
        /// Gets the states.
        /// </summary>
        /// <returns>A list of select list items.</returns>
        public List<SelectListItem> GetStates()
        {
            if (log.IsInfoEnabled) log.Info("GetStates called.");
            StateLogic stateLogic = new StateLogic();

            List<SelectListItem> statesSelectList = new List<SelectListItem>();

            foreach (var state in stateLogic.GetStateCodes())
            {
                SelectListItem item = new SelectListItem() { Text = state.Name, Value = state.StateCode };
                statesSelectList.Add(item);
            }

            return statesSelectList;
        }
    }
}