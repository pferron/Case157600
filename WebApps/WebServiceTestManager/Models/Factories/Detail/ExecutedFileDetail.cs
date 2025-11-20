using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceTestManager.Models
{
    public class ExecutedFileDetail : IDetailView
    {
        /// <summary>
        /// The id of the executed file.
        /// </summary>
        private int _id;

        public ExecutedFileDetail(int id)
        {
            _id = id;
        }

        /// <summary>
        /// Get the model of the exectued model.
        /// </summary>
        /// <returns>A model with the executed file information</returns>
        public IViewModel Model
        {
            get
            {
                try
                {
                    using (var context = new Database())
                    {
                        var file = context.TestExecutions.Find(_id);
                        var expectedFiles = context.ExpectedValues.Where(e => e.FileId == file.FileId).ToList();
                        var model = new ExecutedFileDetailViewModel()
                        {
                            Expected = expectedFiles,
                            Summary = file.Summary
                        };
                        return model;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}