namespace ProjectBD.Helper
{
    public class LoggerHelper
    {
        private static string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.log");

        public static void Log(string message, string messageType = "INFO")
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} [{messageType}] {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}
