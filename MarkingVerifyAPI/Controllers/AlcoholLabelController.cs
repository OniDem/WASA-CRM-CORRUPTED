using MarkingVerifyAPI.Core.Entity;
using MarkingVerifyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarkingVerifyAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AlcoholLabelController : ControllerBase
    {
        private readonly AlcoholLabelService _alcoholLabelService;

        public AlcoholLabelController(AlcoholLabelService alcoholLabelService)
        {
            _alcoholLabelService = alcoholLabelService;
        }

        [HttpPost]
        public async Task<AlcoholLabelEntity?> Add(AlcoholLabelEntity entity)
        {
            if(ModelState.IsValid)
            {
                return await _alcoholLabelService.Add(entity);
            }
            return null;
        }

        [HttpPost]
        public async Task<bool> VerifyLabel(string label)
        {
            if(ModelState.IsValid)
            {
                var result = await _alcoholLabelService.GetByLabel(label);
                if (result != null)
                    return true;
            }
            return false;
        }

        [HttpDelete]
        public void Remove(string label)
        {
            if(ModelState.IsValid)
            {
                _alcoholLabelService.Remove(label);
            }
        }
    }
}
