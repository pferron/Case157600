using LPA.Dashboard.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LPA.Dashboard.Models.Deployment
{
    public class CreateResourceUpdateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}
