using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Infrastructure.ProtectionPlusInsurance.Database
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;
        private readonly string _dbCreationScript;

        public DatabaseInitializer(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection") ?? string.Empty;

            _dbCreationScript = ReadEmbeddedResource(
                "Infrastructure.ProtectionPlusInsurance.Database.CreateProtectionPlusInsuranceDB.sql"
            );
        }

        public void Initialize()
        {
            const string databaseName = "ProtectionPlusInsurance";

            if (DatabaseExists(databaseName))
                return;

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var commands = SplitBatches(_dbCreationScript);

            foreach (var command in commands)
            {
                using var cmd = new SqlCommand(command, connection);
                cmd.ExecuteNonQuery();
            }

            ApplyStoredProcedures();
        }

        private void ApplyStoredProcedures()
        {
            var assembly = Assembly.GetExecutingAssembly();

            const string spPrefix = "Infrastructure.ProtectionPlusInsurance.Database.StoredProcedures.";

            var resourceNames = assembly
                .GetManifestResourceNames()
                .Where(r => r.StartsWith(spPrefix) && r.EndsWith(".sql"));

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            foreach (var resourceName in resourceNames)
            {
                string script = ReadEmbeddedResource(resourceName);
                var batches = SplitBatches(script);

                foreach (var batch in batches)
                {
                    using var cmd = new SqlCommand(batch, connection);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private string ReadEmbeddedResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using Stream? stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new Exception($"Embedded SQL resource not found: {resourceName}");
            }

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public IEnumerable<string> SplitBatches(string sqlScript)
        {
            return sqlScript
                .Split(["GO", "go", "Go", "gO"], StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s));
        }

        private bool DatabaseExists(string databaseName)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var cmd = new SqlCommand(
                "SELECT DB_ID(@dbName)",
                connection
            );

            cmd.Parameters.AddWithValue("@dbName", databaseName);

            var result = cmd.ExecuteScalar();

            return result != DBNull.Value && result != null;
        }
    }
}
