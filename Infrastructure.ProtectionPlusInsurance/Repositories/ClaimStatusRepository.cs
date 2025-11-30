using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;
using System.Data;

namespace Infrastructure.ProtectionPlusInsurance.Repositories
{
    public class ClaimStatusRepository : IClaimStatusRepository
    {
        private readonly ISqlExecutor _sql;

        public ClaimStatusRepository(ISqlExecutor sql)
        {
            _sql = sql;
        }

        public async Task<int> CreateAsync(ClaimStatus entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@StatusName", entity.Statusname }
            };

            return await _sql.ExecuteScalarAsync<int>("CreateClaimStatus", parameters, ct);
        }

        public async Task<int> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ClaimStatusId", id }
            };

            return await _sql.ExecuteScalarAsync<int>("DeleteClaimStatus", parameters, ct);
        }

        public async Task<ClaimStatus?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ClaimStatusId", id }
            };

            DataTable dt = await _sql.GetDataTableAsync("GetClaimStatusById", parameters, ct);

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        public async Task<List<ClaimStatus>> GetListAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PageNumber", pageNumber },
                { "@PageSize", pageSize }
            };

            DataTable dt = await _sql.GetDataTableAsync("GetClaimStatuses", parameters, ct);

            var list = new List<ClaimStatus>();

            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));

            return list;
        }

        public async Task<int> UpdateAsync(ClaimStatus entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ClaimStatusId", entity.ClaimStatusId},
                { "@StatusName", entity.Statusname }
            };

            return await _sql.ExecuteScalarAsync<int>("UpdateClaimStatus", parameters, ct);
        }

        private ClaimStatus Map(DataRow row)
        {
            return new ClaimStatus
            {
                ClaimStatusId = (int)row["ClaimStatusId"],
                Statusname = row["StatusName"].ToString()!
            };
        }
    }
}
