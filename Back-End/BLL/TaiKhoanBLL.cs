using DAL;
using Microsoft.IdentityModel.Tokens;
using Model;
using System;
using Helper;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public partial class TaiKhoanBLL : ITaiKhoanBLL
    {
        private ITaiKhoanDAL _res;
        private string Secret;
        public TaiKhoanBLL(ITaiKhoanDAL res, IConfiguration configuration)
        {
            Secret = configuration["AppSettings:Secret"];
            _res = res;
        }
        public TaiKhoanModel XacThuc(string username, string password)
        {
            var taikhoan = _res.GetTaiKhoan(username, password);
            // return null if TaiKhoan not found
            if (taikhoan == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, taikhoan.Ten_TK.ToString()),
                    new Claim(ClaimTypes.Role, taikhoan.Quyen)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            taikhoan.token = tokenHandler.WriteToken(token);

            return taikhoan;

        }
        public TaiKhoanModel GetThongTin(string id)
        {
            return _res.GetThongTin(id);
        }
    }
}
