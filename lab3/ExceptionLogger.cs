using System;
using System.IO;

namespace lab3
{
    public static class ExceptionLogger
    {
        public static readonly string LogFilePath = "ExceptionLog.txt";

        public static void LogException(Exception ex)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(LogFilePath, true))
                {
                    sw.WriteLine("Дата: " + DateTime.Now.ToString());
                    sw.WriteLine("Исключение: " + ex.GetType().ToString());
                    sw.WriteLine("Сообщение: " + ex.Message);
                    sw.WriteLine("Метод: " + ex.TargetSite);
                    sw.WriteLine("Стек вызовов: " + ex.StackTrace);
                    sw.WriteLine(new string('-', 80));
                }
            }
            catch
            {
                // Если логирование не удалось, ничего не делаем
            }
        }
    }
}