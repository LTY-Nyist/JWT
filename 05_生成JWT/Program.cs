// See https://aka.ms/new-console-template for more information
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

List<Claim> claims = new List<Claim>();
claims.Add(new Claim("Passport", "123456"));
claims.Add(new Claim("QQ", "88888"));
claims.Add(new Claim("Id", "777777"));
claims.Add(new Claim(ClaimTypes.NameIdentifier, "11111"));
claims.Add(new Claim(ClaimTypes.Name, "LTY"));
claims.Add(new Claim(ClaimTypes.HomePhone, "999"));
claims.Add(new Claim(ClaimTypes.Role, "admin"));
claims.Add(new Claim(ClaimTypes.Role, "manager"));
string key = "fasdfad&9045dafz222#fadpio@0232";
DateTime expires = DateTime.Now.AddDays(1);
byte[] secBytes = Encoding.UTF8.GetBytes(key);
var secKey = new SymmetricSecurityKey(secBytes);
var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
var tokenDescriptor = new JwtSecurityToken(claims: claims,
    expires: expires, signingCredentials: credentials);
//var tokenDescriptor = new JwtSecurityToken(claims: claims,
//     signingCredentials: credentials);
string jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
Console.WriteLine(jwt);

