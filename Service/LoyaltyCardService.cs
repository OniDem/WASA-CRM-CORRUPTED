using Core.Entity;
using DTO.LoyaltyCard;
using Infrastructure.Repositories;

namespace Services
{
    public class LoyaltyCardService
    {
        private readonly LoyaltyCardRepository _loyaltyCardRepository;

        public LoyaltyCardService(LoyaltyCardRepository loyaltyCardRepository)
        {
            _loyaltyCardRepository = loyaltyCardRepository;
        }

        public async Task<LoyaltyCardEntity> Add(LoyaltyCardEntity entity)
        {
            return _loyaltyCardRepository.Add(entity);
        }

        public async Task<LoyaltyCardEntity> ShowById(int id)
        {
            return _loyaltyCardRepository.ShowById(id);
        }

        public async Task<LoyaltyCardEntity> AddReceiptId(int id, int receiptId)
        {
            return _loyaltyCardRepository.AddReceiptId(id, receiptId);
        }

        public async Task<LoyaltyCardEntity> AddBonus(int id, AddBonusToLoyaltyCardRequest request)
        {
            return _loyaltyCardRepository.AddBonus(id, request);
        }

        public async Task<LoyaltyCardEntity> RemoveBonus(int id, RemoveBonusFromLoyaltyCardRequest request)
        {
            return _loyaltyCardRepository.RemoveBonus(id, request);
        }
    }
}
