using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BBRE.Classes
{
    /// <summary>
    ///     This class queries data from the FlexLink database replicated in the
    ///     RL Jones server. Please note that a valid connection string shall be
    ///     provided in the constructor, pointing to SQL Server on 10.30.100.206
    ///     
    ///     On this server we configured a Linked server in order to get read 
    ///     access to the FlexLink database.
    /// </summary>
    class FlexLinkManager : SqlHelper
    {
        public FlexLinkManager(string connectionString="")
            : base(connectionString == "" ? "ProductionDatabase" : connectionString)
        {
            Open();
        }

        public string GetMasterPartDescription(string nfSku)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@PartNumber", nfSku)
            };

            string sql = "SELECT PartDescription FROM tbl_Master_Part WHERE PartNumber=@PartNumber";
            var sqlRows = ExecuteReader(sql, parameters);
           
            foreach(var row in sqlRows)
                return row.FieldValues[0].ToString();

            return "NOT FOUND IN FLEXLINK";
        }

        public async Task<string> GetMasterPartDescriptionAsync(string nfSku)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@PartNumber", nfSku)
            };

            string sql = "SELECT PartDescription FROM MasterPart WHERE PartNumber=@PartNumber";
            var sqlRows = await ExecuteReaderAsync(sql, parameters);

            foreach (SqlTableRow row in sqlRows)
                return row.FieldValues[0].ToString();

            return "NOT FOUND IN FLEXLINK";
        }
    }
}
