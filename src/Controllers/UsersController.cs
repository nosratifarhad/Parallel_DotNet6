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

        [HttpGet("/api/products/add-user-with-lock")]
        public async Task<IActionResult> AddUserWithLock()
        {

            int i = 0;

            Console.WriteLine($"Add User With Lock");

            //Parallel.For(1, 10, i => _userRepository.AddUser(new Dtos.User() { Id = 1 }));
            Parallel.ForEach(Enumerable.Range(0, 9), i => _userRepository.AddUserWithLock(new Dtos.User() { Id = i++ }));

            //var item = _userRepository.GetUser(2);
            //Console.WriteLine(item?.Id);

            var items = _userRepository.GetAllUser();

            var result = items.OrderBy(x => x.Id).ToList();

            i = 0;
            foreach (var item in result)
                Console.WriteLine($"i :{i++} - Id :{item.Id}");


            Console.WriteLine($"-------------------");

            return Ok();
        }

        [HttpGet("/api/products/add-user-without-lock")]
        public async Task<IActionResult> AddUserWithOutLock()
        {

            int i = 0;

            Console.WriteLine($"Add User WithOut Lock");

            //Parallel.For(1, 10, i => _userRepository.AddUser(new Dtos.User() { Id = 1 }));
            Parallel.ForEach(Enumerable.Range(0, 9), i => _userRepository.AddUserWithOutLock(new Dtos.User() { Id = i++ }));

            //var item = _userRepository.GetUser(2);
            //Console.WriteLine(item?.Id);

            var items = _userRepository.GetAllUser();

            var result = items.OrderBy(x => x.Id).ToList();

            i = 0;
            foreach (var item in result)
                Console.WriteLine($"i :{i++} - Id :{item.Id}");


            Console.WriteLine($"-------------------");

            return Ok();
        }
    }
}
