using AutoMapper;
using BLog.IServices;
using DataAccess;
using DataAccess.Entities;
using DTO;
using Microsoft.Data.SqlClient;
using Repo.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLog.Services
{
    public class UserService : IUserService<User,UserDTO>
    {
        public readonly IRepository<User> repo;
        public readonly IMapper mapper;
        SqlDataReader reader;
        public UserService(IRepository<User> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }


        public void Register(UserDTO user, string table, string value)
        {
            CreatePassHash(user.Password, out byte[] passHash, out byte[] passSalt);
            string? salt = null;
            string? hash = null;

            if (passHash != null && passSalt != null)
            {
                foreach (byte s in passSalt)
                {
                    salt += s.ToString("x2");
                }
                foreach (byte h in passHash)
                {
                    hash += h.ToString("x2");
                }


            }

            var data = mapper.Map<User>(user);

            value = $@"(name,passwordHash,passwordSalt) VALUES('{data.Name}','{hash}','{salt}')";

            repo.Add(data, table, value);
        }

        public void CreatePassHash(string? pass, out byte[] passHash, out byte[] passSalt)
        {
            using(var hmac = new HMACMD5())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pass)); 
            }
        }

        public bool VeryfyPassHash(string? pass, byte[] passHash, byte[] passSalt)
        {
            
            using(var hmac = new HMACMD5(passSalt))
            {
                string? pp=null;
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pass));
                foreach (byte h in hash)
                {
                    pp += h.ToString("x2");
                }
                return hash.SequenceEqual(passHash);
            }
        }



        public bool LogIn(UserDTO user, string table, string value)
        {
            
            byte[] passHash;
            byte[] passSalt;
            var data = mapper.Map<User>(user);
            value = $@"SELECT name,passwordHash,passwordSalt FROM Users
                        WHERE name='{user.Name}'";

            reader = DbContext.ExecuteRead(value);
            while (reader.Read())
            {
                       
                passHash = Encoding.UTF8.GetBytes(reader["passwordHash"].ToString());
                passSalt = Encoding.UTF8.GetBytes(reader["passwordSalt"].ToString());
                
                if(VeryfyPassHash(user.Password,passHash,passSalt)==true)
                {
                    break;
                }
                else
                {
                    continue;
                }
                
            }



            return true;//VeryfyPassHash(user.Password, dataPassHash., dataPassSalt);
        }
    }
}
