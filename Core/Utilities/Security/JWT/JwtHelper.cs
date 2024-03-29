using Core.Entities.Concrete;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Core.Utilities.Security.JWT;

public class JwtHelper : ITokenHelper
{
    public IConfiguration Configuration { get; }//appsettings de ki değerleri okur
    private TokenOptions _tokenOptions;
    private DateTime _accessTokenExpiration;
    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;
        _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

    }
    public async Task<AccessToken> CreateToken(UserAuth user, IList<OperationClaim> operationClaims)
    {
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);

        return new AccessToken
        {
            Token = token,
            Expiration = _accessTokenExpiration
        };

    }

    public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, UserAuth user,
        SigningCredentials signingCredentials, IList<OperationClaim> operationClaims)
    {
        var jwt = new JwtSecurityToken(
            issuer: tokenOptions.Issuer,
            audience: tokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: SetClaims(user, operationClaims),
            signingCredentials: signingCredentials
        );
        return jwt;
    }

    private IEnumerable<Claim> SetClaims(UserAuth user, IList<OperationClaim> operationClaims)
    {
        var claims = new List<Claim>();
        claims.AddNameIdentifier(user.Id.ToString());
        claims.AddEmail(user.Email);
        claims.AddName($"{user.FirstName} {user.LastName}");
        claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

        return claims;
    }
    public RefreshToken CreateRefreshToken(UserAuth userAuth, string ipAddress)
    {
        RefreshToken refreshToken =
            new()
            {
                UserId = userAuth.Id,
                Token = RandomRefreshToken(),
                Expires = DateTime.UtcNow.AddMinutes(7),
                CreatedByIp = ipAddress
            };

        return refreshToken;
    }
    public ResetToken CreateResetToken(UserAuth userAuth)
    {
        ResetToken resetToken =
            new()
            {
                UserId = userAuth.Id,
                Token = RandomRefreshToken(),
                Expires = DateTime.UtcNow.AddMinutes(7),
            };

        return resetToken;
    }
    private string RandomRefreshToken()
    {
        byte[] numberByte = new byte[32];
        using var random = RandomNumberGenerator.Create();
        random.GetBytes(numberByte);
        return Convert.ToBase64String(numberByte);
    }
}
