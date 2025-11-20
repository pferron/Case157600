using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceTestManager.Models
{
    public class ExecutedTestModifier : IRemovable
    {
        private Guid _id;
        public ExecutedTestModifier(Guid id)
        {
            _id = id;
        }
        public bool Remove()
        {
            try
            {
                using (var context = new Database())
                {
                    var testExecutions = context.TestExecutions.Where(te => te.TestIdentifier == _id).ToList();

                    foreach (var item in testExecutions)
                    {
                        context.TestExecutions.Remove(item);
                    }
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}