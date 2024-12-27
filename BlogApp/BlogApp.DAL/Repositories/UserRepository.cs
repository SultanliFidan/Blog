using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;
using BlogApp.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        readonly HttpContext _httpContext;
        readonly BlogDbContext _context;
        public UserRepository(BlogDbContext context,IHttpContextAccessor httpContext) : base(context)
        {
            _httpContext = httpContext.HttpContext;
            _context = context;
        }

        public async Task<User?> GetByUserNameAsync(string username)
        {
            return await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
        }

        public User GetCurrentUser()
        {
            return new();
        }

        public int GetCurrentUserId()
        {
            return 0;
        }
    }
}
