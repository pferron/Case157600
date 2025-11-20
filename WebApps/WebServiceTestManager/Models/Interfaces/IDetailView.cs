using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceTestManager.Models
{
    public interface IDetailView 
    {
        IViewModel Model { get; }
    }
}