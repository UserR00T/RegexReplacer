using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;

namespace RegexReplacer.Models
{
    public class Pattern
    {
        [JsonIgnore]
        public string Name => $"{SearchBlob} @ {Matcher} [{Replace.Count}]";

        public string Path { get; set; } = Directory.GetCurrentDirectory();

        public string SearchBlob { get; set; } = "*.*";

        public string Matcher { get; set; }

        public List<Replace> Replace { get; set; } = new List<Replace>();

        public SearchOption SearchOptions { get; set; } = SearchOption.AllDirectories;
    }
}