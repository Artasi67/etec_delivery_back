using etec_delivery_backend.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace etec_delivery_backend.Services
{
    public interface IServiceJWT
    {
        public string CriarToken(Usuario usuario);
    }
    public class ServiceJWT : IServiceJWT
    {
        private readonly SymmetricSecurityKey _key;
        private readonly string _emissor;
        private readonly string _destinatario;

        public ServiceJWT(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes(config["JWT:key"]!)
               );
            _emissor = config["JWT:Issuer"]!;
            _destinatario = config["JWT:Audience"]!;
        }
        public string CriarToken(Usuario usuario)
        {
            var claims = new List<Claim>
           {
               new(
                   JwtRegisteredClaimNames.NameId,
                   usuario.Id_Usuario.ToString()
                   ),
               new(
                   JwtRegisteredClaimNames.Name,
                   usuario.Nome_Usuario
                   ),
               new(
                   JwtRegisteredClaimNames.Email,
                   usuario.Email_Usuario
                   )
           };

            var credenciais = new SigningCredentials(
                _key, SecurityAlgorithms.HmacSha256Signature
                );

            var tokenCriptografado = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credenciais,
                Issuer = _emissor,
                Audience = _destinatario,
            };

            var tokenEmissor = new JwtSecurityTokenHandler();

            var token = tokenEmissor.CreateToken(tokenCriptografado);

            return tokenEmissor.WriteToken(token);
        }
    }
}
