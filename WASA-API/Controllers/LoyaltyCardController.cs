using Core.Entity;
using DTO.LoyaltyCard;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WASA_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoyaltyCardController : ControllerBase
    {
        private readonly LoyaltyCardService _loyaltyCardService;

        public LoyaltyCardController(LoyaltyCardService loyaltyCardService)
        {
            _loyaltyCardService = loyaltyCardService;
        }

        [HttpPost]
        public async Task<LoyaltyCardEntity?> Add(LoyaltyCardEntity entity)
        {
            if(ModelState.IsValid)
            {
                return await _loyaltyCardService.Add(entity);
            }
            return null;
        }

        [HttpPost]
        public async Task<LoyaltyCardEntity?> ShowById(int id)
        {
            if(ModelState.IsValid)
            {
                return await _loyaltyCardService.ShowById(id);
            }
            return null;
        }

        [HttpPut]
        public async Task<LoyaltyCardEntity?> AddReceiptId(int id, int receiptId)
        {
            if(ModelState.IsValid)
            {
                return await _loyaltyCardService.AddReceiptId(id, receiptId);
            }
            return null;
        }

        [HttpPut]
        public async Task<LoyaltyCardEntity?> AddBonus(int id, AddBonusToLoyaltyCardRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _loyaltyCardService.AddBonus(id, request);
            }
            return null;
        }

        [HttpPut]
        public async Task<LoyaltyCardEntity?> RemoveBonus(int id, RemoveBonusFromLoyaltyCardRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _loyaltyCardService.RemoveBonus(id, request);
            }
            return null;
        }
    }
}
