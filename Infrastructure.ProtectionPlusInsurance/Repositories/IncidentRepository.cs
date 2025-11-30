using System.Data;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Infrastructure.ProtectionPlusInsurance.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly ISqlExecutor _sql;

        public IncidentRepository(ISqlExecutor sqlExecutor)
        {
            _sql = sqlExecutor;
        }

        public async Task<int> CreateAsync(Incident entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PolicyId", entity.PolicyId },
                { "@IncidentTypeId", entity.IncidentTypeId },
                { "@DateOfIncident", entity.DateOfIncident },
                { "@Description", entity.Description }
            };

            return await _sql.ExecuteScalarAsync<int>("CreateIncident", parameters, ct);
        }

        public async Task<int> UpdateAsync(Incident entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@IncidentId", entity.IncidentId },
                { "@PolicyId", entity.PolicyId },
                { "@IncidentTypeId", entity.IncidentTypeId },
                { "@DateOfIncident", entity.DateOfIncident },
                { "@Description", entity.Description }
            };

            return await _sql.ExecuteScalarAsync<int>("UpdateIncident", parameters, ct);
        }

        public async Task<int> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@IncidentId", id }
            };

            return await _sql.ExecuteScalarAsync<int>("DeleteIncident", parameters, ct);
        }

        public async Task<Incident?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@IncidentId", id }
            };

            var dt = await _sql.GetDataTableAsync("GetIncidentById", parameters, ct);

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        public async Task<List<Incident>> GetListAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PageNumber", pageNumber },
                { "@PageSize", pageSize }
            };

            var dt = await _sql.GetDataTableAsync("GetIncidents", parameters, ct);
            var list = new List<Incident>();

            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));

            return list;
        }

        private Incident Map(DataRow row)
        {
            return new Incident
            {
                IncidentId = (int)row["IncidentId"],
                PolicyId = (int)row["PolicyId"],
                IncidentTypeId = (int)row["IncidentTypeId"],
                DateOfIncident = (DateTime)row["DateOfIncident"],
                Description = row["Description"] == DBNull.Value ? null : (string?)row["Description"],
                ReportedDate = (DateTime)row["ReportedDate"]
            };
        }
    }
}
