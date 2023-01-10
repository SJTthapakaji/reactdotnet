using Ecommerce.Modal;
using GroupMeeting.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private IProgramService _programService;

        public ProgramController(IProgramService programService)
        {
            _programService = programService;

        }

        [HttpGet("detail")]
        public async Task<dynamic> Detail(int Id)
        {
            ProgramModel asc = await _programService.GetProgramById(Id);
            if (asc == null)
            {
                return "Could not found";
                            }
            return asc;
        }
    }
}
