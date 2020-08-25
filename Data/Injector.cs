using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    /// <summary>
    /// A class that instantiates the UserData class
    /// </summary>
    public static class Injector
    {
        /// <summary>
        /// Instantiates and returns an object of UserData
        /// </summary>
        /// <returns>The UsersData object</returns>
        public static IUsersData Inject() => new UsersData();
    }
}