using Core.Entity;
using DTO.LoyaltyCard;

namespace Infrastructure.Repositories
{
    public class LoyaltyCardRepository
    {
        private readonly ApplicationContext _applicationContext;

        public LoyaltyCardRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public LoyaltyCardEntity Add(LoyaltyCardEntity entity)
        {
            _applicationContext.LoyaltyCards.Add(entity);
            _applicationContext.SaveChanges();
            return entity;
        }

        public LoyaltyCardEntity AddReceiptId(int id, int receiptId)
        {
            var loyaltyCard = ShowById(id);
            loyaltyCard.ReceiptIDs.Add(receiptId);

            _applicationContext.LoyaltyCards.Update(loyaltyCard);
            _applicationContext.SaveChanges();
            return loyaltyCard;
        }

        public LoyaltyCardEntity ShowById(int id)
        {
            return _applicationContext.LoyaltyCards.FirstOrDefault(x => x.Id == id);
        }

        public double GetBalanceById(int id)
        {
            return ShowById(id).Balance;
        }

        public LoyaltyCardEntity AddBonus(int id, AddBonusToLoyaltyCardRequest request)
        {
            var loyaltyCard = ShowById(id);
            loyaltyCard.Balance += request.BonusCount;
            loyaltyCard.BonusHistory.Add(request.BonusCount);

            _applicationContext.LoyaltyCards.Update(loyaltyCard);
            _applicationContext.SaveChanges();
            return loyaltyCard;
        }

        public LoyaltyCardEntity RemoveBonus(int id, RemoveBonusFromLoyaltyCardRequest request)
        {
            var loyaltyCard = ShowById(id);
            if((loyaltyCard.Balance - request.BonusCountToRemove) > 0.0)
            {
                loyaltyCard.Balance -= request.BonusCountToRemove;
                loyaltyCard.BonusHistory!.Add(-request.BonusCountToRemove);

                _applicationContext.LoyaltyCards.Update(loyaltyCard);
                _applicationContext.SaveChanges();
                return loyaltyCard;
            }
            return null!;
        }
    }
}
