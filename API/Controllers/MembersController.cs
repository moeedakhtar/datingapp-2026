using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class MembersController(AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task< ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var menbers =  await context.Users.ToListAsync();
            return menbers;
        }
        [Authorize]
        [HttpGet("{id}")] //Localhost:5001/api/members/bob-id
        public async Task< ActionResult<AppUser>> GetMember(string id)
        {
            var member = await context.Users.FindAsync(id);//Where(_ => _.Id == id).First();//
            if(member == null) return NotFound();
            return member;
        }

    }
}
