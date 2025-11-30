using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;

namespace Application.ProtectionPlusInsurance.Services.Interfaces
{
    public interface IAdjusterService
    {
        Task<Result<List<AdjusterDto>>> GetAdjustersAsync(int pageNumber = 1, int pageSize = 10, 
            CancellationToken ct = default);

        Task<Result<AdjusterDto?>> GetAdjusterByIdAsync(int adjusterId, CancellationToken ct = default);

        Task<Result> CreateAdjusterAsync(string firstName, string lastName, string email, string phone, 
            CancellationToken ct = default);

        Task<Result> UpdateAdjusterAsync(int adjusterId, string firstName, string lastName, 
            string email, string phone, CancellationToken ct = default);

        Task<Result> DeleteAdjusterAsync(int adjusterId, CancellationToken ct = default);
    }
}
