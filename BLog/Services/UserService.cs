using AutoMapper;
using BLog.IServices;
using DataAccess;
using DataAccess.Entities;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repo.IRepositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLog.Services
{
    public class UserService : IUserService<User,UserDTO>
    {
        public readonly IRepository<User> repo;
        public readonly IMapper mapper;
        SqlDataReader? reader;
        private IConfiguration configuration;
        public UserService(IRepository<User> repo, IMapper mapper,IConfiguration configuration)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.configuration = configuration;
        }


        public bool Register(UserDTO user, string table, string value)
        {
            string sql = $@"SELECT us_name FROM Users
                            WHERE us_name='{user.Name}'";
            reader = DbContext.ExecuteRead(sql);

               if (!reader.HasRows)
                {
                    CreatePassHash(user.Password, out byte[] passHash);
                    string? hash = null;

                    if (passHash != null)
                    {
                        
                        foreach (byte h in passHash)
                        {
                            hash += h.ToString("x2");
                        }


                    }

                    var data = mapper.Map<User>(user);

                    value = $@"(us_name,passwordHash) VALUES('{data.Name}','{hash}')";

                    repo.Add(data, table, value);

                    return true;

                }
                else
                {
                    return false;
                }
                        
        }

        public void CreatePassHash(string pass, out byte[] passHash)
        {
            SHA512 hmac = SHA512.Create();
            passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pass)); 
            
        }
        public string CreateJwtToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim(ClaimTypes.Role,user.role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSetings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);
                
            var jwt=new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public bool VeryfyPassHash(string pass, string? passHash)
        {
            string? hashCheck = null;
            SHA512 hmac = SHA512.Create();
                           
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pass));
            foreach(byte b in hash)
            {
                hashCheck += b.ToString("x2");
            }
            if (hashCheck == passHash)
            {
                return true;
            }
            else
            {
                return false;
            }
                
            
        }



        public string LogIn(UserDTO user, string table, string value)
        {
            try
            {
                string token = "";
                string? passHash;
                User data = mapper.Map<User>(user);
                value = $@"select u.us_name,u.passwordHash,r.rl_name as Role from Users as u
                            inner join Roles as r on r.id=u.role_id
                        WHERE us_name='{user.Name}'";

                reader = DbContext.ExecuteRead(value);
                if(reader.Read())
                {
                    data.role = reader["Role"].ToString();
                    passHash = reader["passwordHash"].ToString();
                    if (VeryfyPassHash(user.Password, passHash) == true)
                    {
                        token = CreateJwtToken(data);                       
                    }                 

                }

                return token;
                             
            }
            catch(Exception ex)
            {
               
                throw new Exception(ex.HelpLink);
            }

        }
    }
}
