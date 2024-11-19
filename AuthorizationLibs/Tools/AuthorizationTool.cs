using App.HRIS.Entities.Database;
using App.HRIS.Entities.Models;
using AuthorizationLibs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationLibs.Tools
{
    public class AuthorizationTool(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<ViewModels.AuthorizationVM> IsAuthorized(ClaimsPrincipal user, Enums.AuthGrantEnum? grantType)
        {
            try
            {
                var username = user.Identity?.Name ?? throw new Exception("Invalid identity");

                var sessionId = user.FindFirstValue(ClaimTypes.Sid) ?? throw new Exception("Invalid session");

                UserSession currentSession = await _context.UserSessions
                    .Where(x => x.UserId == username && x.IsActive == true && x.SessionId == sessionId)
                    .FirstOrDefaultAsync() ?? throw new Exception("Expired session");

                User? authedUser = await _context.Users.Where(x =>
                    x.Username == username &&
                    x.IsActive == true &&
                    x.IsDeleted == false).FirstOrDefaultAsync() ?? throw new Exception("Invalid identity. Username not found");
                               
                return new ViewModels.AuthorizationVM
                {
                    Auth = true,
                    UserId = (int)authedUser.Id,
                    UserName = authedUser.Fullname,
                    UserNik = authedUser.Username,
                    Message = "OK"
                };
            }
            catch (Exception ex)
            {
                return new ViewModels.AuthorizationVM { Auth = false, Message = ex.Message, UserId = 0 };
            }
        }
    }
}
