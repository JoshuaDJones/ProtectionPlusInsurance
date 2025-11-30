using System.Data;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Infrastructure.ProtectionPlusInsurance.Repositories
{
    public class PolicyHolderRepository : IPolicyHolderRepository
    {
        private readonly ISqlExecutor _sql;

        public PolicyHolderRepository(ISqlExecutor sqlExecutor)
        {
            _sql = sqlExecutor;
        }

        public async Task CreateAsync(PolicyHolder entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@FirstName", entity.FirstName },
                { "@LastName", entity.LastName },
                { "@Email", entity.Email },
                { "@Phone", entity.Phone }
            };

            await _sql.ExecuteAsync("CreatePolicyHolder", parameters, ct);
        }

        public async Task UpdateAsync(PolicyHolder entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PolicyHolderId", entity.PolicyHolderId },
                { "@FirstName", entity.FirstName },
                { "@LastName", entity.LastName },
                { "@Email", entity.Email },
                { "@Phone", entity.Phone }
            };

            await _sql.ExecuteAsync("UpdatePolicyHolder", parameters, ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PolicyHolderId", id }
            };

            await _sql.ExecuteAsync("DeletePolicyHolder", parameters, ct);
        }

        public async Task<PolicyHolder?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PolicyHolderId", id }
            };

            var dt = await _sql.GetDataTableAsync("GetPolicyHolderById", parameters, ct);

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        public async Task<List<PolicyHolder>> GetListAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PageNumber", pageNumber },
                { "@PageSize", pageSize }
            };

            var dt = await _sql.GetDataTableAsync("GetPolicyHolders", parameters, ct);
            var list = new List<PolicyHolder>();

            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));

            return list;
        }

        private PolicyHolder Map(DataRow row)
        {
            return new PolicyHolder
            {
                PolicyHolderId = (int)row["PolicyHolderId"],
                FirstName = (string)row["FirstName"],
                LastName = (string)row["LastName"],
                Email = (string)row["Email"],
                Phone = (string)row["Phone"],
                CreatedDate = (DateTime)row["CreatedDate"]
            };
        }
    }
}
