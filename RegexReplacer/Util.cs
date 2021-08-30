using System;

namespace RegexReplacer
{
    public static class Util
    {
        public static void ExitWith(string message, int exitCode)
        {
            // Don't need to reset, this will kill the program anyways
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"error: {message}");
            Environment.Exit(exitCode);
        }
    }
}