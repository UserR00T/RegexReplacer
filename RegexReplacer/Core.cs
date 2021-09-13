using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using RegexReplacer.Models;

namespace RegexReplacer
{
    public class Core
    {
        public Settings Settings { get; }

        public Core(Settings settings)
        {
            Settings = settings;
        }

        public void Initialize()
        {
            if (Settings.Patterns == null || Settings.Patterns.Count < 1)
            {
                Util.ExitWith($"No patterns were defined! Please define a pattern in the specified patterns file.", 3);
                return;
            }

            foreach (var pattern in Settings.Patterns)
            {
                var files = Directory.GetFiles(pattern.Path, pattern.SearchBlob, pattern.SearchOptions).AsEnumerable();
                if (!string.IsNullOrWhiteSpace(pattern.Matcher))
                {
                    var regex = new Regex(pattern.Matcher);
                    files = files.Where(x => regex.IsMatch(x));
                }
                Console.WriteLine($"{pattern.Name}: Found {files.Count()} total files.");

                foreach (var file in files)
                {
                    if (file == Program.SettingsPath)
                    {
                        continue;
                    }
                    var content = File.ReadAllText(file);

                    var newContent = content.Replace(pattern.From, pattern.To);
                    if (content == newContent)
                    {
                        continue;
                    }
                    File.WriteAllText(file, newContent);
                    Console.WriteLine($"{pattern.Name}({file}): wrote {newContent.Length} characters");
                }
            }
        }
    }
}