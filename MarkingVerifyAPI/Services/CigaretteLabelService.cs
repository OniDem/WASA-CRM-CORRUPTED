using MarkingVerifyAPI.Core.Entity;
using MarkingVerifyAPI.Infrastructure.Repositories;

namespace MarkingVerifyAPI.Services
{
    public class CigaretteLabelService
    {
        private readonly CigaretteLabelRepository _cigaretteLabelRepository;

        public CigaretteLabelService(CigaretteLabelRepository cigaretteLabelRepository)
        {
            _cigaretteLabelRepository = cigaretteLabelRepository;
        }

        public async Task<CigaretteLabelEntity?> Add(CigaretteLabelEntity entity)
        {
            return _cigaretteLabelRepository.Add(entity);
        }

        public async Task<CigaretteLabelEntity?> GetByLabel(string label)
        {
            return _cigaretteLabelRepository.GetByLabel(label);
        }

        public void Remove(string label)
        {
            _cigaretteLabelRepository.Remove(label);
        }
    }
}
