using MarkingVerifyAPI.Core.Entity;

namespace MarkingVerifyAPI.Infrastructure.Repositories
{
    public class CigaretteLabelRepository
    {
        private readonly ApplicationContext _applicationContext;

        public CigaretteLabelRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public CigaretteLabelEntity Add(CigaretteLabelEntity entity)
        {
            _applicationContext.CigaretteLabels.Add(entity);
            _applicationContext.SaveChanges();
            return entity;
        }

        public CigaretteLabelEntity? GetByLabel(string label)
        {
            return _applicationContext.CigaretteLabels.FirstOrDefault(x => x.Label == label);
        }

        public void Remove(string label)
        {
            _applicationContext.CigaretteLabels.Remove(GetByLabel(label)!);
            _applicationContext.SaveChanges();
        }
    }
}
