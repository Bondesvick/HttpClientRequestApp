using System;

namespace Data
{
    /// <summary>
    /// A class that holds the blueprint format articles owned by each author
    /// </summary>
    public class ArticleUsers
    {
        public int id { get; set; }
        public string username { get; set; }
        public string about { get; set; }
        public int submitted { get; set; }
        public DateTime updated_at { get; set; }
        public int submission_count { get; set; }
        public int comment_count { get; set; }
        public int created_at { get; set; }
    }
}