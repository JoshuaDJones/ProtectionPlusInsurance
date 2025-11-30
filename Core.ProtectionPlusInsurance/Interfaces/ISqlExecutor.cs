using System.Data;

namespace Core.ProtectionPlusInsurance.Interfaces
{
    public interface ISqlExecutor
    {
        public Task<DataTable> GetDataTableAsync(string storedProc,
            Dictionary<string, object> parameters,
            CancellationToken ct = default);

        public Task<int> ExecuteAsync(
            string storedProc,
            Dictionary<string, object> parameters,
            CancellationToken ct = default);
    }
}
