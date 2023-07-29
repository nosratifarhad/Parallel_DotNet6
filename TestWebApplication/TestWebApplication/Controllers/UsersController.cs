using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Repositories.Contracts;

namespace TestWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet("/api/products")]
        public async Task<IActionResult> GetProducts()
        {

            Parallel.For(1, 50, i => _userRepository.AddUser(new Dtos.User() { Id = 1 }));
            Parallel.For(1, 50, i => _userRepository.AddUser(new Dtos.User() { Id = 1 }));
            Parallel.For(1, 50, i => _userRepository.AddUser(new Dtos.User() { Id = 1 }));

            var rere = _userRepository.GetAllUser();

            return Ok();
        }

    }
}
