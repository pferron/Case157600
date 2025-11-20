using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebServiceTestManager.Models
{
    /// <summary>
    /// An interface for any modifiable <see cref="IViewModel"/>
    /// </summary>
    public interface IModifiable
    {
        IViewModel GetModel();
        IViewModel GetEmptyModel();
    }
}
