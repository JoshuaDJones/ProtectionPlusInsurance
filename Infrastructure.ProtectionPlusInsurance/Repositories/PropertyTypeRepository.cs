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

        public async Task<int> CreateAsync(PropertyType entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@TypeName", entity.TypeName }
            };

            return await _sql.ExecuteScalarAsync<int>("CreatePropertyType", parameters, ct);
        }

        public async Task<int> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PropertyTypeId", id }
            };

            return await _sql.ExecuteScalarAsync<int>("DeletePropertyType", parameters, ct);
        }

        public async Task<PropertyType?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PropertyTypeId", id }
            };

            DataTable dt = await _sql.GetDataTableAsync("GetPropertyTypeById", parameters, ct);

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

        public async Task<int> UpdateAsync(PropertyType entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PropertyTypeId", entity.PropertyTypeId },
                { "@TypeName", entity.TypeName }
            };

            return await _sql.ExecuteScalarAsync<int>("UpdatePropertyType", parameters, ct);
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
