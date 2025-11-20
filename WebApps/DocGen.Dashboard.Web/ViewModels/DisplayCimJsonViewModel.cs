using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPA.Dashboard.Web.ViewModels
{
    public class DisplayCimJsonViewModel: BaseViewModel
    {
        public string CimJson { get; set; }

        public DisplayCimJsonViewModel()
        {
            CimJson = string.Empty;
            ErrorMessage = string.Empty;
        }
    }
}