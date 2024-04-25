using MarkingVerifyAPI.Core.Entity;
using MarkingVerifyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarkingVerifyAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CigaretteLabelController : ControllerBase
    {
        private readonly CigaretteLabelService _cigaretteLabelService;

        public CigaretteLabelController(CigaretteLabelService cigaretteLabelService)
        {
            _cigaretteLabelService = cigaretteLabelService;
        }

        [HttpPost]
        public async Task<CigaretteLabelEntity?> Add(CigaretteLabelEntity entity)
        {
            if(ModelState.IsValid)
            {
                return await _cigaretteLabelService.Add(entity);
            }
            return null;
        }

        [HttpPost]
        public async Task<bool> VerifyLabel(string label)
        {
            if(ModelState.IsValid)
            {
                var result = await _cigaretteLabelService.GetByLabel(label);
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
                _cigaretteLabelService.Remove(label);
            }
        }
    }
}
