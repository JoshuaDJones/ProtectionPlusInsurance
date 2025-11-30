using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Core.ProtectionPlusInsurance.Interfaces;
using Core.ProtectionPlusInsurance.Entities;

namespace Application.ProtectionPlusInsurance.Services.Implementations
{
    public class AdjusterService : IAdjusterService
    {
        private readonly IAdjusterRepository _adjusterRepository;

        public AdjusterService(IAdjusterRepository adjusterRepository)
        {
            _adjusterRepository = adjusterRepository;
        }

        public async Task<Result<int>> CreateAdjusterAsync(string firstName, string lastName, string email, 
            string phone, CancellationToken ct = default)
        {
            var adjusterId = await _adjusterRepository.CreateAsync(new Adjuster
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
            }, ct);

            return Result<int>.Ok(adjusterId);
        }

        public async Task<Result> DeleteAdjusterAsync(int adjusterId, CancellationToken ct = default)
        {
            var affectedRows = await _adjusterRepository.DeleteAsync(adjusterId, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("Adjuster.NotFound", "Adjuster does not exist."));

            return Result.Ok();
        }

        public async Task<Result<AdjusterDto?>> GetAdjusterByIdAsync(int adjusterId, 
            CancellationToken ct = default)
        {
            var adjuster = await _adjusterRepository.GetByIdAsync(adjusterId, ct);

            if (adjuster == null)
                return Result<AdjusterDto?>.Ok(null);

            return Result<AdjusterDto?>.Ok(adjuster.ToDto());
        }

        public async Task<Result<List<AdjusterDto>>> GetAdjustersAsync(int pageNumber = 1, int pageSize = 10, 
            CancellationToken ct = default)
        {
            var adjusters = await _adjusterRepository.GetListAsync(pageNumber, pageSize, ct);
            var adjusterDtos = adjusters.Select(a => a.ToDto()).ToList();

            return Result<List<AdjusterDto>>.Ok(adjusterDtos);
        }

        public async Task<Result> UpdateAdjusterAsync(int adjusterId, string firstName, string lastName, 
            string email, string phone, CancellationToken ct = default)
        {
            var adjuster = new Adjuster
            {
                AdjusterId = adjusterId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
            };

            var affectedRows = await _adjusterRepository.UpdateAsync(adjuster, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("Adjuster.NotFound", "Adjuster does not exist."));

            return Result.Ok();
        }
    }
}
