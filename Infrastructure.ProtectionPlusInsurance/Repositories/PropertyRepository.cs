using System.Data;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Infrastructure.ProtectionPlusInsurance.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ISqlExecutor _sql;

        public PropertyRepository(ISqlExecutor sqlExecutor)
        {
            _sql = sqlExecutor;
        }

        public async Task CreateAsync(Property entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PolicyHolderId", entity.PolicyHolderId },
                { "@Address", entity.Address },
                { "@City", entity.City },
                { "@State", entity.State },
                { "@Zip", entity.Zip },
                { "@PropertyTypeId", entity.PropertyTypeId },
                { "@YearBuilt", entity.YearBuilt }
            };

            await _sql.ExecuteAsync("CreateProperty", parameters, ct);
        }

        public async Task UpdateAsync(Property entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PropertyId", entity.PropertyId },
                { "@PolicyHolderId", entity.PolicyHolderId },
                { "@Address", entity.Address },
                { "@City", entity.City },
                { "@State", entity.State },
                { "@Zip", entity.Zip },
                { "@PropertyTypeId", entity.PropertyTypeId },
                { "@YearBuilt", entity.YearBuilt }
            };

            await _sql.ExecuteAsync("UpdateProperty", parameters, ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PropertyId", id }
            };

            await _sql.ExecuteAsync("DeleteProperty", parameters, ct);
        }

        public async Task<Property?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PropertyId", id }
            };

            var dt = await _sql.GetDataTableAsync("GetPropertyById", parameters, ct);

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        public async Task<List<Property>> GetListAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PageNumber", pageNumber },
                { "@PageSize", pageSize }
            };

            var dt = await _sql.GetDataTableAsync("GetProperties", parameters, ct);
            var list = new List<Property>();

            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));

            return list;
        }

        private Property Map(DataRow row)
        {
            return new Property
            {
                PropertyId = (int)row["PropertyId"],
                PolicyHolderId = (int)row["PolicyHolderId"],
                Address = (string)row["Address"],
                City = (string)row["City"],
                State = (string)row["State"],
                Zip = (string)row["Zip"],
                PropertyTypeId = (int)row["PropertyTypeId"],
                YearBuilt = row["YearBuilt"] == DBNull.Value ? null : (int?)row["YearBuilt"]
            };
        }
    }
}
