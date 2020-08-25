using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// An interface that holds the blueprint of the UsersData class
    /// </summary>
    public interface IUsersData
    {
        public List<ArticleUsers> allAuthors { get; set; }
        public List<string> authorNames { get; set; }

        /// <summary>
        /// Runs HTTP GET request on the API and returns a List of object of users
        /// </summary>
        /// <param name="url">The passed API URI</param>
        /// <returns>Asynchronous Task</returns>
        public Task Initialize(string url);

        /// <summary>
        /// Gets the names all Article writers
        /// </summary>
        /// <param name="url">The passed API URI</param>
        /// <returns>Asynchronous Task</returns>
        public Task GetNames(string url);

        /// <summary>
        /// Gets name of most active authors ordered by their Submission count
        /// </summary>
        /// <param name="threshold">The set Threshold</param>
        /// <returns>Returned value</returns>
        public List<string> BySubmission(int threshold);

        /// <summary>
        /// Gets name with the highest Comment count
        /// </summary>
        /// <returns>Returned value</returns>
        public List<string> ByComment();

        /// <summary>
        /// Gets names ordered by when article was created
        /// </summary>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public List<string> ByCreated(DateTime threshold);
    }
}