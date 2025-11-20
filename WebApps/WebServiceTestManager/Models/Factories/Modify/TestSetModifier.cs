using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServiceTestManager.Controllers;
using WebServiceTestManager.Exceptions;

namespace WebServiceTestManager.Models
{
    public class TestSetModifier : IModifiable, IRemovable, IAuthorizable
    {
        /// <summary>
        /// The id of the test set we want to edit
        /// </summary>
        private int _id;

        /// <summary>
        /// The user who is trying to access a testset
        /// </summary>
        private User _user;

        /// <summary>
        /// A testset editor created by the edit factory
        /// </summary>
        /// <param name="id">The unverified id of testset</param>
        public TestSetModifier(int id, User user)
        {
            _id = id;
            _user = user;
        }

        /// <summary>
        /// Determine if a person can access
        /// </summary>
        /// <returns>true if a person can access an object</returns>
        public bool CanAuthorize()
        {
            using (var context = new Database())
            {
                return context.UserTestSets.Where(uts => uts.UserId == _user.Id && uts.TestSetId == _id).ToList().Count != 0;
            }
        }

        /// <summary>
        /// Gets an empty model for creating an object
        /// </summary>
        /// <returns>an empty model, used to pass into the view to create an object</returns>
        public IViewModel GetEmptyModel()
        {
            return new TestSetModel();
        }

        /// <summary>
        /// Get a model for editing
        /// </summary>
        /// <exception cref="ModelNotFoundException">The model wasn't found given the i'd
        /// or the user wasn't authorized.</exception>
        /// <returns>Get a model and it's values if authenticated</returns>
        public IViewModel GetModel()
        {
            using (var context = new Database())
            {
                var testSet = context.TestSets.Find(_id);

                if (testSet == null )
                    throw new ModelNotFoundException();

                if (!CanAuthorize())
                    throw new ModelNotFoundException();

                return new TestSetModel()
                {
                    Name = testSet.Name,
                    Id = testSet.Id
                };

            }
        }

        /// <summary>
        /// Determine if an object can be removed
        /// </summary>
        /// <returns>True if the object was successfully removed, otherwise false</returns>
        public bool Remove()
        {
            try
            {
                if (!CanAuthorize())
                    throw new ModelNotFoundException();

                using(var context = new Database())
                {
                    var fileList = context.Files.Where(f => f.TestSetId == _id).ToList();
                    foreach (var item in fileList)
                    {
                        item.TestSetId = null;
                    }
                    var userTestSet = context.UserTestSets.Where(uts => uts.TestSetId == _id).First();
                    context.UserTestSets.Remove(userTestSet);

                    var testSet = context.TestSets.Find(_id);
                    context.TestSets.Remove(testSet);

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