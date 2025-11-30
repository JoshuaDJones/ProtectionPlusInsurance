using System.Data;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Infrastructure.ProtectionPlusInsurance.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly ISqlExecutor _sql;

        public PolicyRepository(ISqlExecutor sqlExecutor)
        {
            _sql = sqlExecutor;
        }

        public async Task CreateAsync(Policy entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PolicyHolderId", entity.PolicyHolderId },
                { "@PolicyStatusId", entity.PolicyStatusId },
                { "@PropertyId", entity.PropertyId },
                { "@PolicyNumber", entity.PolicyNumber },
                { "@CoverageAmount", entity.CoverageAmount },
                { "@Deductible", entity.Deductible },
                { "@EffectiveDate", entity.EffectiveDate },
                { "@ExpirationDate", entity.ExpirationDate }
            };

            await _sql.ExecuteAsync("CreatePolicy", parameters, ct);
        }

        public async Task UpdateAsync(Policy entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PolicyId", entity.PolicyId },
                { "@PolicyHolderId", entity.PolicyHolderId },
                { "@PolicyStatusId", entity.PolicyStatusId },
                { "@PropertyId", entity.PropertyId },
                { "@PolicyNumber", entity.PolicyNumber },
                { "@CoverageAmount", entity.CoverageAmount },
                { "@Deductible", entity.Deductible },
                { "@EffectiveDate", entity.EffectiveDate },
                { "@ExpirationDate", entity.ExpirationDate }
            };

            await _sql.ExecuteAsync("UpdatePolicy", parameters, ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PolicyId", id }
            };

            await _sql.ExecuteAsync("DeletePolicy", parameters, ct);
        }

        public async Task<Policy?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PolicyId", id }
            };

            var dt = await _sql.GetDataTableAsync("GetPolicyById", parameters, ct);

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        public async Task<List<Policy>> GetListAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PageNumber", pageNumber },
                { "@PageSize", pageSize }
            };

            var dt = await _sql.GetDataTableAsync("GetPolicies", parameters, ct);
            var list = new List<Policy>();

            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));

            return list;
        }

        private Policy Map(DataRow row)
        {
            return new Policy
            {
                PolicyId = (int)row["PolicyId"],
                PolicyHolderId = (int)row["PolicyHolderId"],
                PolicyStatusId = (int)row["PolicyStatusId"],
                PropertyId = (int)row["PropertyId"],
                PolicyNumber = (string)row["PolicyNumber"],
                CoverageAmount = (decimal)row["CoverageAmount"],
                Deductible = (decimal)row["Deductible"],
                EffectiveDate = (DateTime)row["EffectiveDate"],
                ExpirationDate = (DateTime)row["ExpirationDate"]
            };
        }
    }
}
