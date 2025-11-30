using System.Data;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Infrastructure.ProtectionPlusInsurance.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly ISqlExecutor _sql;

        public ClaimRepository(ISqlExecutor sqlExecutor)
        {
            _sql = sqlExecutor;
        }

        public async Task CreateAsync(Claim entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@IncidentId", entity.IncidentId },
                { "@ClaimStatusId", entity.ClaimStatusId },
                { "@ClaimNumber", entity.ClaimNumber },
                { "@EstimatedLossAmount", entity.EstimatedLossAmount },
                { "@ApprovedPayoutAmount", entity.ApprovedPayoutAmount }
            };

            await _sql.ExecuteAsync("CreateClaim", parameters, ct);
        }

        public async Task UpdateAsync(Claim entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ClaimId", entity.ClaimId },
                { "@IncidentId", entity.IncidentId },
                { "@ClaimStatusId", entity.ClaimStatusId },
                { "@ClaimNumber", entity.ClaimNumber },
                { "@EstimatedLossAmount", entity.EstimatedLossAmount },
                { "@ApprovedPayoutAmount", entity.ApprovedPayoutAmount }
            };

            await _sql.ExecuteAsync("UpdateClaim", parameters, ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ClaimId", id }
            };

            await _sql.ExecuteAsync("DeleteClaim", parameters, ct);
        }

        public async Task<Claim?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ClaimId", id }
            };

            var dt = await _sql.GetDataTableAsync("GetClaimById", parameters, ct);

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        public async Task<List<Claim>> GetListAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PageNumber", pageNumber },
                { "@PageSize", pageSize }
            };

            var dt = await _sql.GetDataTableAsync("GetClaims", parameters, ct);
            var list = new List<Claim>();

            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));

            return list;
        }

        private Claim Map(DataRow row)
        {
            return new Claim
            {
                ClaimId = (int)row["ClaimId"],
                IncidentId = (int)row["IncidentId"],
                ClaimStatusId = (int)row["ClaimStatusId"],
                ClaimNumber = (string)row["ClaimNumber"],
                EstimatedLossAmount = row["EstimatedLossAmount"] == DBNull.Value ? null : (decimal?)row["EstimatedLossAmount"],
                ApprovedPayoutAmount = row["ApprovedPayoutAmount"] == DBNull.Value ? null : (decimal?)row["ApprovedPayoutAmount"],
                CreatedDate = (DateTime)row["CreatedDate"],
                LastUpdated = (DateTime)row["LastUpdated"]
            };
        }
    }
}
