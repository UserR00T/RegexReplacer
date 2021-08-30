using System.IO;

namespace RegexReplacer.Models
{
    public class Pattern
    {
        public string Name => $"{Matcher} - {SearchBlob}";

        public string Path { get; set; } = Directory.GetCurrentDirectory();

        public string SearchBlob { get; set; } = "*.*";

        public string Matcher { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public SearchOption SearchOptions { get; set; } = SearchOption.AllDirectories;
    }
}