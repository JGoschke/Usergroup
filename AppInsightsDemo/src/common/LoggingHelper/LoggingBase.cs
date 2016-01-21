using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingHelper
{
    public class LoggingBase<T>:IDisposable where T :new()
    {
        static T instance;
        static object _sync = new object();
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_sync)
                    {
                        if (instance == null)
                        {
                            instance = new T();
                        }
                    }
                }
                return instance;
            }
        }
        string logFilename = "";
        System.IO.TextWriter logger;
        string appName;
        protected string AppName
        {
            get { return appName; }
        }
        TelemetryClient tc;
        public TelemetryClient TelemetryClient
        {
            get { return tc; }
        }
        System.Diagnostics.Stopwatch sw;
        protected LoggingBase()
        {
            tc = new TelemetryClient();
            tc.InstrumentationKey = "3fa22409-3d8d-499e-9fa6-1cf2b05af4a5";
            tc.Context.Device.OperatingSystem = Environment.OSVersion.ToString();
            tc.Context.Properties["Assembly"] = AppDomain.CurrentDomain.FriendlyName;

            appName = AppDomain.CurrentDomain.FriendlyName.Split('.').First();
            var LoggingPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
            System.IO.Directory.CreateDirectory(LoggingPath);
            logFilename = Path.Combine(LoggingPath, appName.Trim() + "_" + DateTime.Today.ToString("yyyyMMdd") + ".log");
            logger = System.IO.File.AppendText(logFilename);
            ProgrammStart();
        }
        public void ProgrammStart()
        {
            tc.TrackEvent("Start");
            sw = System.Diagnostics.Stopwatch.StartNew();
            Write(AppName + " gestartet");
        }
        public void ProgrammEnde()
        {
            sw.Stop();
            tc.TrackEvent("Ende");
            Write(AppName + " beendet");
        }
        public void Error(Exception e)
        {
            tc.TrackException(e);
            Write(string.Format("FEHLER: {0}", e));
        }

        protected virtual void Write(string logEintrag)
        {
            logger.Write("{0:yyyy-MM-dd HH:mm:ss} {1}\r\n", DateTime.Now, logEintrag);
            logger.Flush();
        }
        public void Dispose()
        {
            ProgrammEnde();
            TelemetryClient.TrackRequest(AppName, DateTime.Now, sw.Elapsed, "OK", true);

            tc.Flush();
            logger.Close();
            logger = null;
        }
    }
}
