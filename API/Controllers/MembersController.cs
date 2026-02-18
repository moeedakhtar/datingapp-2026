using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")] //Localhost:5001/api/members
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task< ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var menbers =  await context.Users.ToListAsync();
            return menbers;
        }
        [HttpGet("{id}")] //Localhost:5001/api/members/bob-id
        public async Task< ActionResult<AppUser>> GetMember(string id)
        {
            var member = await context.Users.FindAsync(id);//Where(_ => _.Id == id).First();//
            if(member == null) return NotFound();
            return member;
        }

    }
}
