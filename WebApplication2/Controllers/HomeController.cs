using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly FirstDbContext _context;
        public HomeController(FirstDbContext context)
        {
            _context = context;
        }

        //[HttpGet("SingleThreadFunction")]
        //public IActionResult SingleThreadFunction()
        //{
        //    Console.WriteLine("Operation1");
        //    Operation1();
        //    Console.WriteLine("Operation2");
        //    Operation2();

        //    return Ok();
        //}

        //[HttpGet("Operation1")]
        //public void Operation1()
        //{
        //    Thread.Sleep(5000);
        //}
        //[HttpGet("Operation2")]
        //public void Operation2()
        //{
        //    Thread.Sleep(5000);
        //}

        //[HttpGet("MultiThreadFunction")]
        //public async Task<IActionResult> MultiThreadFunction()
        //{
        //    var tasks = new List<Task>();
        //    Console.WriteLine("Operation1");
        //    tasks.Add(Operation1());
        //    Console.WriteLine("Operation2");
        //    tasks.Add(Operation2());

        //    await Task.WhenAll(tasks);

        //    return Ok();
        //}

        //[HttpGet("Operation1")]
        //public async Task Operation1()
        //{
        //    Console.WriteLine("Task Run Time" + DateTime.Now.ToLongTimeString());
        //    await Task.Delay(5000);
        //}

        //[HttpGet("Operation2")]
        //public async Task Operation2()
        //{
        //    Console.WriteLine("Task Run Time" + DateTime.Now.ToLongTimeString());
        //    await Task.Delay(5000);
        //}

        #region OneToOne
        [HttpGet("GetUsersWithDetails")]
        public async Task<IActionResult> GetUsersWithDetails()
        {
            var data = await _context.Set<UserDetailEntity>()
                .Include(x => x.User)
                .ToListAsync();

            var parsedData = JsonConvert.SerializeObject(data);

            return Ok(parsedData);
        }

        [HttpPost("InsertUserWithDetails")]
        public async Task InsertUserWithDetails(
            string userName, 
            string idNumber,
            string name,
            string email,
            string password
            )
        {
            var userDetail = new UserDetailEntity
            {
                IdNumber = idNumber,
                UserName = userName,
                User = new UserEntity
                {
                    Email = email,
                    Name = name,
                    Password = password,
                }
            };

            await _context.AddAsync(userDetail);

            await _context.SaveChangesAsync();
        }
        #endregion

        #region OneToMany
        [HttpPost("CreatePost")]
        public async Task CreatePost(string title, string description)
        {
            var post = new PostEntity
            {
                Title = title,
                Description = description
            };

            await _context.AddAsync(post);

            await _context.SaveChangesAsync();
        }
        [HttpPost("CreateComment")]
        public async Task CreateComment(int postId, string title, string body)
        {
            var comment = new CommentEntity
            {
                PostId = postId,
                Title = title,
                Body = body
            };

            await _context.AddAsync(comment);

            await _context.SaveChangesAsync();
        }
        [HttpGet("GetPost")]
        public async Task<IActionResult> GetPost()
        {
            var data = await _context.Set<PostEntity>()
                .Include(x => x.Comments)
                .ToListAsync();

            var parsedData = JsonConvert.SerializeObject(data);

            return Ok(parsedData);
        }

        #endregion

        // C.R.U.D - Create Read Update Delete
        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.Set<TestEntity>().ToList();

            var parsedData = JsonConvert.SerializeObject(data);

            return Ok(parsedData);
        }

        [HttpPost]
        public IActionResult Post(string name, string description)
        {
            TestEntity testEntity = new TestEntity
            {
                Name = name,
                Description = description
            };

            _context.Set<TestEntity>().Add(testEntity);

            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id, string name, string description)
        {
            var data = _context.Set<TestEntity>().FirstOrDefault(x => x.Id == id);

            data.Name = name;
            data.Description = description;

            _context.Set<TestEntity>().Update(data);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = _context.Set<TestEntity>().FirstOrDefault(x => x.Id == id);

            _context.Set<TestEntity>().Remove(data);

            _context.SaveChanges();

            return Ok();
        }
    }
}
