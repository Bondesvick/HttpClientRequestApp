using System.Collections.Generic;

namespace Data
{
    /// <summary>
    /// A class that holds the blueprint format of the root header of the JSON API
    /// </summary>
    public class Root
    {
        public string page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<ArticleUsers> data { get; set; }
    }
}