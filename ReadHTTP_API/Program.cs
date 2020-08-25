using Data;
using System;
using System.Threading.Tasks;

namespace ReadHTTP_API
{
    internal partial class Program
    {
        private static IUsersData allAuthors { get; } = Injector.Inject();

        private static async Task Main(string[] args)
        {
            await allAuthors.GetNames(@"https://jsonmock.hackerrank.com/api/article_users/search?page=");

            Console.WriteLine("Count  " + allAuthors.allAuthors.Count);
            Console.WriteLine("Count  " + allAuthors.authorNames.Count);
            Console.WriteLine();

            Console.WriteLine("List of all Names:");
            foreach (var name in allAuthors.authorNames)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            Console.WriteLine("List of all Names sorted according to their Submission count and set threshold:");
            foreach (var name in allAuthors.BySubmission(30))
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            Console.WriteLine("Names of author with the highest comments");
            foreach (var name in allAuthors.ByComment())
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            // Converting date-time to  UnixTimeSeconds
            DateTime chosen = new DateTime(2009, 04, 23);
            Console.WriteLine($"List of all Names sorted according to when created and set threshold of on or after {chosen.ToLongDateString()}:");

            foreach (var name in allAuthors.ByCreated(chosen))
            {
                Console.WriteLine(name);
            }
        }
    }
}