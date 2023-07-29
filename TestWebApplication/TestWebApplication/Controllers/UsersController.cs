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

            //Parallel.For(1, 10, i => _userRepository.AddUser(new Dtos.User() { Id = 1 }));
            Parallel.ForEach(Enumerable.Range(1, 10), i => _userRepository.AddUser(new Dtos.User() { Id = 1 }));

            //var item = _userRepository.GetUser(2);
            //Console.WriteLine(item?.Id);

            var items = _userRepository.GetAllUser();

            int i = 0;
            foreach (var item in items)
                Console.WriteLine($"{i++} {item.Id}");

            return Ok();
        }

    }
}
