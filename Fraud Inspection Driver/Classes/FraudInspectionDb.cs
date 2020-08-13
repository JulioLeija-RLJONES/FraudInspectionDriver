using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLJones.FraudInspectionDriver.Classes
{
    public class FraudInspectionDb : SqlHelper
    {
        public FraudInspectionDb()
            : base( ApplicationDeployment.IsNetworkDeployed ? "ProductionDatabase" : "DebugDatabase")
        {

        }

        public FraudInspectionTarget GetInspectionTarget(string partNumber)
        {
            FraudInspectionTarget target = null;

            // force to remove all unwanted characters from PartNumber string in db
            string sql = "SELECT * FROM FraudInspectionTargets WHERE ";
            sql += "LTRIM(RTRIM(REPLACE(REPLACE(REPLACE(REPLACE(PartNumber, ";
            sql += "CHAR(10), CHAR(32)), CHAR(13), CHAR(32)), CHAR(160), CHAR(32)), CHAR(9), CHAR(32))))";
            sql += "='" + partNumber + "'";
           
            var rows = ExecuteReader(sql);

            foreach(var row in rows)
            {
                target = new FraudInspectionTarget
                {
                    Id = Convert.ToInt32(row.FieldValues[0]),
                    PartNumber = row.FieldValues[1].ToString().Replace("\n\r", "").Trim(),
                    Class = row.FieldValues[2].ToString(),
                    Message = row.FieldValues[3].ToString()
                };
            }

            return target;
        }

        public FraudTracker GetFraudTracker(string serialNumber)
        {
            FraudTracker tracker = null;

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@SerialNumber", serialNumber)
            };

            var rows =
                ExecuteReader
                ("SELECT * FROM FraudTracker WHERE SerialNumber=@SerialNumber", parameters);

            foreach (var row in rows)
            {
                tracker = new FraudTracker
                {
                    FraudId = Convert.ToInt32(row.FieldValues[0]),
                    Date = Convert.ToDateTime(row.FieldValues[1]),
                    DeviceType = row.FieldValues[2].ToString(),
                    SerialNumber = row.FieldValues[3].ToString(),
                    PSUTest = row.FieldValues[4].ToString(),
                    MagnetTest = row.FieldValues[5].ToString(),
                    ManualCID = row.FieldValues[6].ToString(),   
                };
            }
            return tracker;
        }

        public void InsertFraudTracker(FraudTracker tracker)
        {
            string sql = "INSERT INTO FraudTracker";
            sql += "(Date, DeviceType, SerialNumber, PSUTest) ";
            sql += "VALUES(@Date, @DeviceType, @SerialNumber, @PSUTest)";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Date", DateTime.Now),
                new SqlParameter("@DeviceType", tracker.DeviceType),
                new SqlParameter("@SerialNumber", tracker.SerialNumber),
                new SqlParameter("@PSUTest", tracker.PSUTest)
            };

            ExecuteReader(sql, parameters);
        }
    }
}
