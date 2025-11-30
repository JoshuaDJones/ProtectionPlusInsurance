using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;
using System.Data;

namespace Infrastructure.ProtectionPlusInsurance.Repositories
{
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private readonly ISqlExecutor _sql;

        public PropertyTypeRepository(ISqlExecutor sql)
        {
            _sql = sql;
        }

        public async Task CreateAsync(PropertyType entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@TypeName", entity.TypeName }
            };

            await _sql.ExecuteAsync("CreatePropertyType", parameters, ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PropertyTypeId", id }
            };

            await _sql.ExecuteAsync("DeletePropertyType", parameters, ct);
        }

        public async Task<PropertyType?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PropertyTypeId", id }
            };

            DataTable dt = await _sql.GetDataTableAsync("GetPropertyTypeId", parameters, ct);

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        public async Task<List<PropertyType>> GetListAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PageNumber", pageNumber },
                { "@PageSize", pageSize }
            };

            DataTable dt = await _sql.GetDataTableAsync("GetPropertyTypes", parameters, ct);

            var list = new List<PropertyType>();

            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));

            return list;
        }

        public async Task UpdateAsync(PropertyType entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PropertyTypeId", entity.PropertyTypeId },
                { "@TypeName", entity.TypeName }
            };

            await _sql.ExecuteAsync("UpdatePropertyType", parameters, ct);
        }

        private PropertyType Map(DataRow row)
        {
            return new PropertyType
            {
                PropertyTypeId = (int)row["PropertyTypeId"],
                TypeName = row["TypeName"].ToString()!
            };
        }
    }
}
