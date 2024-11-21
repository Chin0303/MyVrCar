using System;
using System.IO;

namespace Doorstop
{
    public static class Logger
    {
        public delegate void LogHandler(string message);

        private static readonly string LogFileName = "mscVR.log";

        public static void LogToConsole(string message) =>
            Console.WriteLine($"[My VR Car] {message}");

        // ONLY for backend if the console fucking dies. Please dont harras me!!
        public static void LogToFile(string message)
        {
            try
            {
                File.AppendAllText(LogFileName, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}");
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine($"[My VR Car] Failed to write to log file: {ex.Message}");
            }
        }

        public static LogHandler GetLogger(bool useConsole) =>
            useConsole ? LogToConsole : LogToFile;
    }
}
