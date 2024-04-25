using MarkingVerifyAPI.Core.Entity;

namespace MarkingVerifyAPI.Infrastructure.Repositories
{
    
    public class AlcoholLabelRepository
    {
        private readonly ApplicationContext _applicationContext;

        public AlcoholLabelRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public AlcoholLabelEntity Add(AlcoholLabelEntity entity)
        {
            _applicationContext.AlcoholLabels.Add(entity);
            _applicationContext.SaveChanges();
            return entity;
        }

        public AlcoholLabelEntity? GetByLabel(string label)
        {
            return _applicationContext.AlcoholLabels.FirstOrDefault(x =>  x.Label == label);
        }

        public void Remove(string label)
        {
            _applicationContext.AlcoholLabels.Remove(GetByLabel(label)!);
            _applicationContext.SaveChanges();
        }
    }
}
