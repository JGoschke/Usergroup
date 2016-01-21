using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    class Logging:LoggingHelper.LoggingBase<Logging>
    {
        public void MeldeMesswert1(double wert)
        {
            TelemetryClient.TrackMetric("Messwert", wert);
        }
    }
}
