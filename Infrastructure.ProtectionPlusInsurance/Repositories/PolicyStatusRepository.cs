using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;
using System.Data;

namespace Infrastructure.ProtectionPlusInsurance.Repositories
{
    public class PolicyStatusRepository : IPolicyStatusRepository
    {
        private readonly ISqlExecutor _sql;

        public PolicyStatusRepository(ISqlExecutor sql)
        {
            _sql = sql;
        }

        public async Task<int> CreateAsync(PolicyStatus entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@StatusName", entity.StatusName }
            };

            return await _sql.ExecuteScalarAsync<int>("CreatePolicyStatus", parameters, ct);
        }

        public async Task<int> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PolicyStatusId", id }
            };

            return await _sql.ExecuteScalarAsync<int>("DeletePolicyStatus", parameters, ct);
        }

        public async Task<PolicyStatus?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PolicyStatusId", id }
            };

            DataTable dt = await _sql.GetDataTableAsync("GetPolicyStatusById", parameters, ct);

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        public async Task<List<PolicyStatus>> GetListAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PageNumber", pageNumber },
                { "@PageSize", pageSize }
            };

            DataTable dt = await _sql.GetDataTableAsync("GetPolicyStatuses", parameters, ct);

            var list = new List<PolicyStatus>();

            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));

            return list;
        }

        public async Task<int> UpdateAsync(PolicyStatus entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PolicyStatusId", entity.PolicyStatusId },
                { "@StatusName", entity.StatusName }
            };

            return await _sql.ExecuteScalarAsync<int>("UpdatePolicyStatus", parameters, ct);
        }

        private PolicyStatus Map(DataRow row)
        {
            return new PolicyStatus
            {
                PolicyStatusId = (int)row["PolicyStatusId"],
                StatusName = row["StatusName"].ToString()!
            };
        }
    }
}
