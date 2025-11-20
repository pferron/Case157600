using System;
using System.Linq;
using WebServiceTestManager.Exceptions;

namespace WebServiceTestManager.Models
{
    public class DestinationModifier : IModifiable, IRemovable, IAuthorizable
    {
        /// <summary>
        /// The id of the destination we are trying to find
        /// </summary>
        private int _id;

        private User _user;

        /// <summary>
        /// A destination editor created by the edit factory
        /// </summary>
        /// <param name="id">The unverified id of destination</param>
        /// <param name="user">the user information</param>
        public DestinationModifier(int id, User user)
        {
            _id = id;
            _user = user;
        }

        public bool CanAuthorize()
        {
            using (var context = new Database())
            {
                return context.UserDestinations.Where(ud => ud.UserId == _user.Id && ud.DestinationId == _id).ToList().Count != 0;
            }
        }

        public IViewModel GetEmptyModel()
        {
            return new DestinationViewModel();
        }

        /// <summary>
        /// Get a the correct destination model.
        /// </summary>
        /// <returns>a new <see cref="DestinationViewModel"/></returns>
        public IViewModel GetModel()
        {
            using (var context = new Database())
            {
                var destination = context.Destinations.Find(_id);

                if (destination == null)
                    throw new ModelNotFoundException();

                if (!CanAuthorize())
                    throw new ModelNotFoundException();

                return new DestinationViewModel()
                {
                    Name = destination.Name,
                    Url = destination.Url
                };
            }
        }

        public bool Remove()
        {
            try
            {
                using (var context = new Database())
                {
                    var destination = context.Destinations.Find(_id);

                    if (destination == null)
                        throw new ModelNotFoundException();

                    if (!CanAuthorize())
                        throw new ModelNotFoundException();

                    //var userDestination = context.UserDestinations.Where(ud => ud.DestinationId == destination.Id).First();

                    //context.UserDestinations.Remove(userDestination);
                    context.Destinations.Remove(destination);
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