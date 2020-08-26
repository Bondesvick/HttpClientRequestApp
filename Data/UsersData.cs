using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// A class that handles how to get user data
    /// </summary>
    public class UsersData : IUsersData
    {
        public List<ArticleUsers> allAuthors { get; set; }
        public List<string> authorNames { get; set; }

        /// <summary>
        /// Runs HTTP GET request on the API and returns a List of object of users
        /// </summary>
        /// <param name="url">The passed API URI</param>
        /// <returns>Asynchronous Task</returns>
        public async Task Initialize(string url)
        {
            try
            {
                allAuthors = await ApiReader.GetRequest(url);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //MessageBox.Show();
            }
        }

        /// <summary>
        /// Gets the names all Article writers
        /// </summary>
        /// <param name="url">The passed API URI</param>
        /// <returns>Asynchronous Task</returns>
        public async Task GetNames(string url)
        {
            await Initialize(url);
            List<string> toReturn = new List<string>();

            if (allAuthors != null)
            {
                foreach (var user in allAuthors)
                {
                    toReturn.Add(user.username);
                }

                authorNames = toReturn;
            }
        }

        /// <summary>
        /// Gets name of most active authors ordered by their Submission count
        /// </summary>
        /// <param name="threshold">The set Threshold</param>
        /// <returns>Returned value</returns>
        public List<string> BySubmission(int threshold)
        {
            return allAuthors.OrderByDescending(author => author.submission_count)
                .Where(author => author.submission_count >= threshold)
                .Select(author => author.username).ToList();
        }

        /// <summary>
        /// Gets name with the highest Comment count
        /// </summary>
        /// <returns>Returned value</returns>
        public List<string> ByComment()
        {
            return allAuthors.OrderByDescending(author => author.comment_count)
                .Select(author => author.username).Take(1).ToList();
        }

        /// <summary>
        /// Gets names ordered by when article was created
        /// </summary>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public List<string> ByCreated(DateTime threshold)
        {
            // Converting date-time to  UnixTimeSeconds
            DateTimeOffset choseOffset = new DateTimeOffset(threshold);
            int thresholdInUnix = (int)choseOffset.ToUnixTimeSeconds();

            return allAuthors.OrderBy(author => author.created_at)
                .Where(author => author.created_at >= thresholdInUnix)
                .Select(author => author.username).ToList();
        }
    }
}