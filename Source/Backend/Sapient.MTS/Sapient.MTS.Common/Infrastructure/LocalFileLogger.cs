﻿using Sapient.MTS.Common.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Sapient.MTS.Common.Infrastructure
{
    public class LocalFileLogger : ILogger
    {
        private const string DATE_FORMAT_SHORT = "yyyy-MM-dd";
        private const string DATE_FORMAT_LONG = "yyyy-MM-dd HH:mm:ss";

        private const string FOLDER = "Logs//";
        private const string FILE = "Log_{0}.log";

        // Public Methods

        public void LogError(Exception ex)
        {
            Log(ex.Message + Environment.NewLine + ex.StackTrace);
        }

        public Task LogErrorAsync(Exception ex)
        {
            LogError(ex);
            return Task.CompletedTask;
        }

        public void LogError(string subject, string message = null)
        {
            Log(subject + Environment.NewLine + message);
        }

        public Task LogErrorAsync(string subject, string message = null)
        {
            LogError(subject, message);
            return Task.CompletedTask;
        }

        public void LogMessage(string subject, string message = null)
        {
            LogError(subject, message);
        }

        public Task LogMessageAsync(string subject, string message = null)
        {
            return LogErrorAsync(subject, message);
        }

        // Private Methods

        private void Log(string message)
        {
            try
            {
                var fileName = GetFilePath();

                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.Write(String.Format("{0} [UTC]-->:", DateTime.UtcNow.ToString(DATE_FORMAT_LONG)));
                    sw.Write(message);
                    sw.WriteLine();

                    sw.Flush();
                }
            }
            catch { }
        }

        private string GetFilePath()
        {
            var fileName = string.Format(FILE, DateTime.UtcNow.ToString(DATE_FORMAT_SHORT));
            var directoryPath = AppDomain.CurrentDomain.BaseDirectory + FOLDER;

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(directoryPath));
            }

            return directoryPath + fileName;
        }
    }
}
