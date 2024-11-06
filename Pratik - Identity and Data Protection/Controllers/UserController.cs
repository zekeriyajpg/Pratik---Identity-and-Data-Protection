using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pratik___Identity_and_Data_Protection.Models;

namespace Pratik___Identity_and_Data_Protection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IDataProtector _protector;

        public UserController(ApplicationDbContext context, IDataProtectionProvider provider)
        {
            _context = context;
            _protector = provider.CreateProtector("UserPasswordProtector");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Şifreyi şifreleme
                user.Password = _protector.Protect(user.Password);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Kullanıcı başarıyla kaydedildi." });
            }
            return BadRequest(ModelState);
        }
    }
}
