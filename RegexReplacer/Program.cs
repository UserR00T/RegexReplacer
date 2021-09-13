using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RegexReplacer.Models;

namespace RegexReplacer
{
    public class Program
    {
        private static JsonSerializerOptions _serializerSettings = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static string SettingsPath { get; private set; }

        public static void Main(string[] args)
        {
            SettingsPath = args.Length != 0 ? string.Join(' ', args) : "regexreplacer.json";
            if (!File.Exists(SettingsPath))
            {
                File.WriteAllText(SettingsPath, JsonSerializer.Serialize<Settings>(new Settings()
                {
                    Patterns = new List<Pattern>()
                    {
                        new Pattern()
                    }
                }, _serializerSettings));
                Util.ExitWith($"File '{SettingsPath}' does not exist. An example file has been created.", 1);
                return;
            }

            Settings settings;
            try
            {
                settings = JsonSerializer.Deserialize<Settings>(File.ReadAllText(SettingsPath), _serializerSettings);
            }
            catch (JsonException ex)
            {
                Util.ExitWith($"Invalid JSON: {ex.Message}", 2);
                return;
            }
            // Expand path for future comparison
            SettingsPath = Path.GetFullPath(SettingsPath);

            var core = new Core(settings);
            try
            {
                core.Initialize();
            }
            catch (Exception ex)
            {
                Util.ExitWith(ex.ToString(), -1);
                return;
            }
            Console.WriteLine("Process finished!");
        }
    }
}
