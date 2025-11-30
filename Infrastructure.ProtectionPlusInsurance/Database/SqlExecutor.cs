using Core.ProtectionPlusInsurance.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.ProtectionPlusInsurance.Database
{
    public class SqlExecutor : ISqlExecutor
    {
        private readonly string _connectionString;

        public SqlExecutor(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("ProtectionPlusConnection") ?? string.Empty;
        }

        public async Task<DataTable> GetDataTableAsync(
            string storedProc,
            Dictionary<string, object> parameters,
            CancellationToken ct = default)
        {
            var dt = new DataTable();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(storedProc, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            foreach (var param in parameters)
                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);

            using var adapter = new SqlDataAdapter(cmd);

            await conn.OpenAsync(ct);
            adapter.Fill(dt);

            return dt;
        }

        public async Task<int> ExecuteAsync(
            string storedProc,
            Dictionary<string, object> parameters,
            CancellationToken ct = default)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(storedProc, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            foreach (var param in parameters)
                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);

            await conn.OpenAsync(ct);
            return await cmd.ExecuteNonQueryAsync(ct);
        }
    }
}
