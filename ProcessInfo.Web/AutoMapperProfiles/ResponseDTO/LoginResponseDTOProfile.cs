using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ProcessInfo.DB.Models;
using ProcessInfo.Utility;
using ProcessInfo.Web.Models.DTOs.ResponseDTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProcessInfo.Web.AutoMapperProfiles.ResponseDTO
{
    public class LoginResponseDTOProfile : Profile
    {
        public LoginResponseDTOProfile()
        {
            CreateMap<User, LoginResponseDTO>()
               .ForMember(m => m.UserRoleName, map => map.MapFrom(s => s.Role.ToEnumDescription()))
               .ForMember(m => m.UserToken, map => map.MapFrom(s => GenerateToken(s.UserId, s.Username)));
        }
        private string GenerateToken(Guid userId, string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is custom Secret key for authentication");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim(ClaimTypes.NameIdentifier,userId.ToString()),
                     new Claim(ClaimTypes.Name,username)
                }),
                Expires = System.DateTime.Now.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;

        }
    }
}
