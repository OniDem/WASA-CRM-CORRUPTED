using MarkingVerifyAPI.Core.Entity;
using MarkingVerifyAPI.Infrastructure.Repositories;

namespace MarkingVerifyAPI.Services
{
    public class AlcoholLabelService
    {
        private readonly AlcoholLabelRepository _alcoholLabelRepository;

        public AlcoholLabelService(AlcoholLabelRepository alcoholLabelRepository)
        {
            _alcoholLabelRepository = alcoholLabelRepository;
        }

        public async Task<AlcoholLabelEntity?> Add(AlcoholLabelEntity entity)
        {
            return _alcoholLabelRepository.Add(entity);
        }

        public async Task<AlcoholLabelEntity?> GetByLabel(string label)
        {
            return _alcoholLabelRepository.GetByLabel(label);
        }

        public void Remove(string label)
        {
            _alcoholLabelRepository.Remove(label);
        }
    }
}
