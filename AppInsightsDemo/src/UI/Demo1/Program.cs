using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    class Program
    {
        static TelemetryClient tc;
        static Stopwatch sw;
        static void Main(string[] args)
        {
            TCBuildUp();
            ProgrammStart();
            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.ReadLine();
            ProgrammEnde();
        }


        static void TCBuildUp()
        {
            tc = new TelemetryClient();
            tc.InstrumentationKey = "3fa22409-3d8d-499e-9fa6-1cf2b05af4a5";
            tc.Context.Device.OperatingSystem = Environment.OSVersion.ToString();
            tc.Context.Properties["Assembly"] = AppDomain.CurrentDomain.FriendlyName;
        }
        static void ProgrammStart()
        {
            sw = Stopwatch.StartNew();
            tc.TrackEvent("Programm gestartet");
        }
        static void ProgrammEnde()
        {
            sw.Stop();
            tc.TrackMetric("Laufzeit", sw.ElapsedMilliseconds);
            tc.TrackEvent("Programm beendet");

            tc.Flush();
        }
        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            tc.TrackException(new ApplicationException("Programm wurde vom Benutzer abgebrochen"));
            tc.Flush();
        }
    }
}
