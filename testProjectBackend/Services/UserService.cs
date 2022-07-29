using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using testProjectBackend.DbContext;
using testProjectBackend.DTO;
using testProjectBackend.DbContext;

namespace testProjectBackend.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _dbContext;

        public UserService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<object> AuthenticateAsync(LoginDto model)
        {
            var user = await _dbContext.Users
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Email.Contains(model.Email) 
                        && x.Password.Contains(model.Password));

            if (user is null)
                throw new AuthenticationException("User not found");
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ewfjiowejfiwoe7362563oijedf76326ewjw");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()), 
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            
            return new
            {
                access_token = user.Token
            };
        }
    }
}