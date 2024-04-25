using MarkingVerifyAPI.Core.Entity;
using MarkingVerifyAPI.Infrastructure.Repositories;

namespace MarkingVerifyAPI.Services
{
    public class MilkLabelService
    {
        private readonly MilkLabelRepository _milkLabelRepository;

        public MilkLabelService(MilkLabelRepository milkLabelService)
        {
            _milkLabelRepository = milkLabelService;
        }

        public async Task<MilkLabelEntity?> Add(MilkLabelEntity entity)
        {
            return _milkLabelRepository.Add(entity);
        }

        public async Task<MilkLabelEntity?> GetByLabel(string label)
        {
            return _milkLabelRepository.GetByLabel(label);
        }

        public void Remove(string label)
        {
            _milkLabelRepository.Remove(label);
        }
    }
}
