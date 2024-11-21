using System;
using System.Runtime.InteropServices;

namespace Doorstop
{
    /// <summary>
    /// Entry point for the Doorstop plugin, responsible for initialization and console setup.
    /// </summary>
    public static class Entrypoint
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        public static void Start()
        {
            var log = Logger.GetLogger(TryInitializeConsole());

            try
            {
                log("Loaded successfully, for now...");
            }
            catch (Exception ex)
            {
                Logger.LogToFile($"Critical error during initialization: {ex.Message}");
            }
        }

        /// <summary>
        /// Attempts to initialize a console for logging.
        /// </summary>
        /// <returns>True if the console is successfully initialized; otherwise, false.</returns>
        private static bool TryInitializeConsole()
        {
            try
            {
                if (AllocConsole())
                {
                    Logger.LogToConsole("Console window initialized successfully.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogToFile($"Failed to initialize console: {ex.Message}");
            }

            return false;
        }
    }
}
