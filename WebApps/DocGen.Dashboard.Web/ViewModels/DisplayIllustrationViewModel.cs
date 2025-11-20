using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPA.Dashboard.Web.ViewModels
{
    public class DisplayIllustrationViewModel: BaseViewModel
    {
        public long TestResultId { get; set; }

       public DisplayIllustrationViewModel()
        {
            ErrorMessage = string.Empty;
        }
    }
}