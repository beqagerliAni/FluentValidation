using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestValidations : ControllerBase
    {
        [HttpPost]
        public TestDto Index(TestDto user)
        {
            return user;
        }
    }
}
