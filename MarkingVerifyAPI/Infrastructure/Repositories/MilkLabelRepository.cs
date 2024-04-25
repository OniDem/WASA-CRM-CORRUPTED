using MarkingVerifyAPI.Core.Entity;

namespace MarkingVerifyAPI.Infrastructure.Repositories
{
    public class MilkLabelRepository
    {
        private readonly ApplicationContext _applicationContext;

        public MilkLabelRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public MilkLabelEntity Add(MilkLabelEntity entity)
        {
            _applicationContext.MilkLabels.Add(entity);
            _applicationContext.SaveChanges();
            return entity;
        }

        public MilkLabelEntity? GetByLabel(string label)
        {
            return _applicationContext.MilkLabels.FirstOrDefault(x => x.Label == label);
        }

        public void Remove(string label)
        {
            _applicationContext.MilkLabels.Remove(GetByLabel(label));
            _applicationContext.SaveChanges();
        }
    }
}
