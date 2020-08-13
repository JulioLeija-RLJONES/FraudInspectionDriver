using System;

namespace RLJones.FraudInspectionDriver.Classes
{
    public class FraudTracker
    {
        public int FraudId { get; set; }
        public DateTime Date { get; set; }
        public string DeviceType { get; set; }
        public string SerialNumber { get; set; }
        public string PSUTest { get; set; }
        public string MagnetTest { get; set; }
        public string ManualCID { get; set; }
    }
}