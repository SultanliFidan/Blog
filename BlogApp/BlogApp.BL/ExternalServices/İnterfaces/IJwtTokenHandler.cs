using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.ExternalServices.İnterfaces
{
    public interface IJwtTokenHandler
    {
        string CreateToken(User user, int hours);
    }
}
