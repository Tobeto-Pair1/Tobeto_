using Entities.Concretes;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services;

public class JWTService
{



    public string CreateToken(User user,  bool RememberMe = false)
    {

        string token = string.Empty;

        DateTime expire = RememberMe == true ? DateTime.Now.AddMonths(1) : DateTime.Now.AddDays(1);


        List<Claim> claims = new List<Claim>();
        claims.Add(new("UserId", user.Id.ToString()));

        if (user.FirstName is not null)
            

        claims.Add(new("FirstName", user.FirstName.ToString()));


        if (user.Email is not null)
            claims.Add(new("Email", user.Email));


        JwtSecurityToken securityToken = new(
            issuer: "Pair1",
            audience: "Tobeto",
            notBefore: DateTime.UtcNow,
            expires: expire,
             claims: claims,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Doldur be Meyhaneci dsfsfdsaf"))
                                  , SecurityAlgorithms.HmacSha256)

            );


        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        token = handler.WriteToken(securityToken);




        return token;
    }
}
