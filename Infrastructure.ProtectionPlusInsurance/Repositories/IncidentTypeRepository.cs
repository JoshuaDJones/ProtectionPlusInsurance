using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;
using System.Data;

namespace Infrastructure.ProtectionPlusInsurance.Repositories
{
    public class IncidentTypeRepository : IIncidentTypeRepository
    {
        private readonly ISqlExecutor _sql;

        public IncidentTypeRepository(ISqlExecutor sql)
        {
            _sql = sql;
        }

        public async Task CreateAsync(IncidentType entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@IncidentName", entity.IncidentName }
            };

            await _sql.ExecuteAsync("CreateIncidentType", parameters, ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@IncidentTypeId", id }
            };

            await _sql.ExecuteAsync("DeleteIncidentType", parameters, ct);
        }

        public async Task<IncidentType?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@IncidentTypeId", id }
            };

            DataTable dt = await _sql.GetDataTableAsync("GetIncidentTypeById", parameters, ct);

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        public async Task<List<IncidentType>> GetListAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PageNumber", pageNumber },
                { "@PageSize", pageSize }
            };

            DataTable dt = await _sql.GetDataTableAsync("GetIncidentTypes", parameters, ct);

            var list = new List<IncidentType>();

            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));

            return list;
        }

        public async Task UpdateAsync(IncidentType entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@IncidentTypeId", entity.IncidentTypeId},
                { "@IncidentName", entity.IncidentName }
            };

            await _sql.ExecuteAsync("UpdateIncidentType", parameters, ct);
        }

        private IncidentType Map(DataRow row)
        {
            return new IncidentType
            {
                IncidentTypeId = (int)row["IncidentTypeId"],
                IncidentName = row["IncidentName"].ToString()!
            };
        }
    }
}
