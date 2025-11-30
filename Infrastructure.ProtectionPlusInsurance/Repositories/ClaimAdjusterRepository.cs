using System.Data;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Infrastructure.ProtectionPlusInsurance.Repositories
{
    public class ClaimAdjusterRepository : IClaimAdjusterRepository
    {
        private readonly ISqlExecutor _sql;

        public ClaimAdjusterRepository(ISqlExecutor sqlExecutor)
        {
            _sql = sqlExecutor;
        }

        public async Task CreateAsync(ClaimAdjuster entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ClaimId", entity.ClaimId },
                { "@AdjusterId", entity.AdjusterId },
                { "@AssignedDate", entity.AssignedDate }
            };

            await _sql.ExecuteAsync("CreateClaimAdjuster", parameters, ct);
        }

        public async Task UpdateAsync(ClaimAdjuster entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ClaimAdjusterId", entity.ClaimAdjusterId },
                { "@ClaimId", entity.ClaimId },
                { "@AdjusterId", entity.AdjusterId },
                { "@AssignedDate", entity.AssignedDate }
            };

            await _sql.ExecuteAsync("UpdateClaimAdjuster", parameters, ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ClaimAdjusterId", id }
            };

            await _sql.ExecuteAsync("DeleteClaimAdjuster", parameters, ct);
        }

        public async Task<ClaimAdjuster?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ClaimAdjusterId", id }
            };

            DataTable dt = await _sql.GetDataTableAsync("GetClaimAdjusterById", parameters, ct);

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        public async Task<List<ClaimAdjuster>> GetListAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PageNumber", pageNumber },
                { "@PageSize", pageSize }
            };

            DataTable dt = await _sql.GetDataTableAsync("GetClaimAdjusters", parameters, ct);

            var list = new List<ClaimAdjuster>();

            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));

            return list;
        }

        private ClaimAdjuster Map(DataRow row)
        {
            return new ClaimAdjuster
            {
                ClaimAdjusterId = (int)row["ClaimAdjusterId"],
                ClaimId = (int)row["ClaimId"],
                AdjusterId = (int)row["AdjusterId"],
                AssignedDate = (DateTime)row["AssignedDate"]
            };
        }
    }
}
