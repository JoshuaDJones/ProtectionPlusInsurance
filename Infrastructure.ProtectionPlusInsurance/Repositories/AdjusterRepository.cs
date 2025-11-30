using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;
using System.Data;

namespace Infrastructure.ProtectionPlusInsurance.Repositories
{
    public class AdjusterRepository : IAdjusterRepository
    {
        private readonly ISqlExecutor _sql;

        public AdjusterRepository(ISqlExecutor sqlExecutor)
        {
            _sql = sqlExecutor;
        }

        public async Task<int> CreateAsync(Adjuster entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@FirstName", entity.FirstName },
                { "@LastName", entity.LastName },
                { "@Email", entity.Email },
                { "@Phone", entity.Phone }
            };

            return await _sql.ExecuteScalarAsync<int>("CreateAdjuster", parameters, ct);
        }

        public async Task<int> UpdateAsync(Adjuster entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@AdjusterId", entity.AdjusterId },
                { "@FirstName", entity.FirstName },
                { "@LastName", entity.LastName },
                { "@Email", entity.Email },
                { "@Phone", entity.Phone }
            };

            return await _sql.ExecuteScalarAsync<int>("UpdateAdjuster", parameters, ct);
        }

        public async Task<int> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@AdjusterId", id }
            };

            return await _sql.ExecuteScalarAsync<int>("DeleteAdjuster", parameters, ct);
        }

        public async Task<Adjuster?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@AdjusterId", id }
            };

            DataTable dt = await _sql.GetDataTableAsync("GetAdjusterById", parameters, ct);

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        public async Task<List<Adjuster>> GetListAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PageNumber", pageNumber },
                { "@PageSize", pageSize }
            };

            DataTable dt = await _sql.GetDataTableAsync("GetAdjusters", parameters, ct);

            var list = new List<Adjuster>();

            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));

            return list;
        }

        private Adjuster Map(DataRow row)
        {
            return new Adjuster
            {
                AdjusterId = (int)row["AdjusterId"],
                FirstName = row["FirstName"].ToString()!,
                LastName = row["LastName"].ToString()!,
                Email = row["Email"].ToString()!,
                Phone = row["Phone"].ToString()!
            };
        }
    }
}
