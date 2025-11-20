using System;
using System.DirectoryServices.AccountManagement;

namespace LPA.Dashboard.Web.Helpers
{
    /// <summary>
    /// static class for active directory methods
    /// </summary>
    public static class ActiveDirectoryHelper
    {
        /// <summary>
        /// Get a person's full name from their windows user name
        /// </summary>
        /// <param name="username">The windows user name to that you are checking</param>
        /// <returns>The Full name of the user</returns>
        public static string UsernameToFullName(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("User name can't be null");

            using (var ctx = new PrincipalContext(ContextType.Domain))
            using (UserPrincipal user = UserPrincipal.FindByIdentity(ctx, username))
            {
                if (user != null)
                {
                    return user.DisplayName;
                }
            }

            return null;
        }
    }
}