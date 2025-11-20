using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceTestManager.Models
{
    public class FileDetail : IDetailView
    {
        Guid _id;

        /// <summary>
        /// create a new file detail object
        /// </summary>
        /// <param name="id">the id of the file</param>
        public FileDetail(Guid id)
        {
            _id = id;
        }

        /// <summary>
        /// Get a <see cref="FileDetailViewModel"/>
        /// </summary>
        /// <exception cref="Exception">Unable to perform the specified action</exception>
        /// <returns>A file detail object with the correct values from the database</returns>
        public IViewModel Model
        {
            get
            {
                try
                {
                    using (var context = new Database())
                    {
                        var file = context.Files.Find(_id);
                        var expectedFiles = context.ExpectedValues.Where(e => e.FileId == file.Id).ToList();
                        var model = new FileDetailViewModel()
                        {
                            FileName = file.Name,
                            Expected = expectedFiles
                        };
                        return model;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("not found");
                }

            }
        }
    }
}