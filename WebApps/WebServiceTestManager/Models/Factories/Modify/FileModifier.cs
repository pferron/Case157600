using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceTestManager.Exceptions;

namespace WebServiceTestManager.Models
{
    public class FileModifier : IModifiable, IRemovable
    {
        private Guid _id;
        private int _testSetId;

        public FileModifier(int testSetId)
        {
            _testSetId = testSetId;
        }

        public FileModifier(Guid id)
        {
            _id = id;
        }


        public IViewModel GetEmptyModel()
        {
            using (var context = new Database())
            {
                var testSet = context.TestSets.Find(_testSetId);
                if (testSet == null)
                    throw new ModelNotFoundException();
            }
            return new RaterModel { TestSetId = _testSetId };
        }

        /// <summary>
        /// Get a file model
        /// </summary>
        /// <returns>A new FileEditModel</returns>
        public IViewModel GetModel()
        {
            using (var context = new Database())
            {
                var file = context.Files.Find(_id);
                if (file == null)
                    throw new ModelNotFoundException();


                var list = new List<ExpectedValue>();
                list = context.ExpectedValues.Where(e => e.FileId == file.Id).ToList();
                var newList = new List<ExpectedResultModel>();
                foreach (var item in list)
                {
                    newList.Add(new ExpectedResultModel()
                    {
                        PropertyName = item.PropertyName,
                        ExpectedValue = item.ExpectedResult,
                        Id = item.Id
                    });
                }

                return new FileEditModel()
                {
                    FileName = file.Name,
                    ExpectedResults = newList,
                    FileId = _id
                };
            }
        }

        public bool Remove()
        {
            try
            {
                using (var context = new Database())
                {
                    var file = context.Files.Find(_id);
                    file.TestSetId = null;
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