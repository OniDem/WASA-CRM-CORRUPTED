using MarkingVerifyAPI.Core.Entity;
using MarkingVerifyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarkingVerifyAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MilkLabelController : ControllerBase
    {
        private readonly MilkLabelService _milkLabelService;

        public MilkLabelController(MilkLabelService milkLabelService)
        {
            _milkLabelService = milkLabelService;
        }

        [HttpPost]
        public async Task<MilkLabelEntity?> Add(MilkLabelEntity entity)
        {
            if(ModelState.IsValid)
            {
                return await _milkLabelService.Add(entity);
            }
            return null;
        }

        [HttpPost]
        public async Task<bool> VerifyLabel(string label)
        {
            if(ModelState.IsValid)
            {
                var result = await _milkLabelService.GetByLabel(label);
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
                _milkLabelService.Remove(label);
            }
        }
    }
}
