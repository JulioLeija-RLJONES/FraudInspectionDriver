using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLJones.FraudInspectionDriver.Classes
{
    public class SqlHelper : IDisposable
    {
        protected readonly ConnectionStringManager ConnStrMgr;
        protected readonly SqlConnection Connection;

        public SqlHelper(string connectionName)
        {
            ConnStrMgr = new ConnectionStringManager(connectionName);
            Connection = new SqlConnection(ConnStrMgr.ToString());
        }

        public void Dispose()
        {
            if (Connection != null)
                Connection.Close();
        }

        public void Open()
        {
            if (Connection != null)
                Connection.Open();
        }

        public async Task OpenAsync()
        {
            if (Connection != null)
                await Connection.OpenAsync();
        }

        public List<SqlTableRow> ExecuteReader(string sql, IEnumerable<SqlParameter> parameters=null)
        {
            List<SqlTableRow> allRows = new List<SqlTableRow>();

            if (parameters == null)
                parameters = new List<SqlParameter>();

            using (var cmd = new SqlCommand(sql, Connection))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SqlTableRow row = new SqlTableRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        // Process each column as appropriate
                        object fieldValue = reader.GetFieldValue<object>(i);
                        row.FieldValues.Add(fieldValue);
                    }
                    if (row.FieldValues.Count > 0)
                        allRows.Add(row);
                }
                reader.Close();
            }
            return allRows;
        }

        public async Task<List<SqlTableRow>> 
            ExecuteReaderAsync(string sql, IEnumerable<SqlParameter> parameters = null)
        {
            List<SqlTableRow> allRows = new List<SqlTableRow>();

            if (parameters == null)
                parameters = new List<SqlParameter>();

            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(parameters.ToArray());

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    SqlTableRow row = new SqlTableRow();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        // Process each column as appropriate
                        object fieldValue = await reader.GetFieldValueAsync<object>(i);
                        row.FieldValues.Add(fieldValue);
                    }
                    if (row.FieldValues.Count > 0)
                        allRows.Add(row);
                }
            }
            return allRows;
        }
    }
}
