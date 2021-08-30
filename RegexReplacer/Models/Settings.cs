using System.Collections.Generic;

namespace RegexReplacer.Models
{
    public class Settings
    {
        public List<Pattern> Patterns { get; set; } = new List<Pattern>();
    }
}