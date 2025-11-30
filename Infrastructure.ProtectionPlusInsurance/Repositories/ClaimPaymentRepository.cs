using System.Data;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Infrastructure.ProtectionPlusInsurance.Repositories
{
    public class ClaimPaymentRepository : IClaimPaymentRepository
    {
        private readonly ISqlExecutor _sql;

        public ClaimPaymentRepository(ISqlExecutor sqlExecutor)
        {
            _sql = sqlExecutor;
        }

        public async Task<int> CreateAsync(ClaimPayment entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ClaimId", entity.ClaimId },
                { "@ClaimPaymentMethodId", entity.ClaimPaymentMethodId },
                { "@Amount", entity.Amount },
                { "@PaymentDate", entity.PaymentDate },
                { "@ReferenceNumber", entity.ReferenceNumber }
            };

            return await _sql.ExecuteScalarAsync<int>("CreateClaimPayment", parameters, ct);
        }

        public async Task<int> UpdateAsync(ClaimPayment entity, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ClaimPaymentId", entity.ClaimPaymentId },
                { "@ClaimId", entity.ClaimId },
                { "@ClaimPaymentMethodId", entity.ClaimPaymentMethodId },
                { "@Amount", entity.Amount },
                { "@PaymentDate", entity.PaymentDate },
                { "@ReferenceNumber", entity.ReferenceNumber }
            };

            return await _sql.ExecuteScalarAsync<int>("UpdateClaimPayment", parameters, ct);
        }

        public async Task<int> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ClaimPaymentId", id }
            };

            return await _sql.ExecuteScalarAsync<int>("DeleteClaimPayment", parameters, ct);
        }

        public async Task<ClaimPayment?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ClaimPaymentId", id }
            };

            var dt = await _sql.GetDataTableAsync("GetClaimPaymentById", parameters, ct);

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        public async Task<List<ClaimPayment>> GetListAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@PageNumber", pageNumber },
                { "@PageSize", pageSize }
            };

            var dt = await _sql.GetDataTableAsync("GetClaimPayments", parameters, ct);
            var list = new List<ClaimPayment>();

            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));

            return list;
        }

        private ClaimPayment Map(DataRow row)
        {
            return new ClaimPayment
            {
                ClaimPaymentId = (int)row["ClaimPaymentId"],
                ClaimId = (int)row["ClaimId"],
                ClaimPaymentMethodId = (int)row["ClaimPaymentMethodId"],
                Amount = (decimal)row["Amount"],
                PaymentDate = (DateTime)row["PaymentDate"],
                ReferenceNumber = row["ReferenceNumber"] == DBNull.Value ? null : (string)row["ReferenceNumber"]
            };
        }
    }
}
