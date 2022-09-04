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


        public bool Register(UserDTO user, string table, string value)
        {
            string sql = $@"SELECT name FROM Users
                            WHERE name='{user.Name}'";
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

                    value = $@"(name,passwordHash) VALUES('{data.Name}','{hash}')";

                    repo.Add(data, table, value);
                return true;
                }
            else
            {
                return false;
            }
                        
        }

        public void CreatePassHash(string? pass, out byte[] passHash)
        {
            HMACMD5 hmac = new HMACMD5();
            passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pass)); 
            
        }

        public bool VeryfyPassHash(string? pass, byte[] passHash)
        {

            HMACMD5 hmac = new HMACMD5();
            
                string? pp = null;
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pass)); 
                foreach (byte h in hash)
                {
                    pp += h.ToString("x2");
                }               

                return hash.SequenceEqual(passHash);
                
            
        }



        public bool LogIn(UserDTO user, string table, string value)
        {
            
            byte[] passHash;            
            var data = mapper.Map<User>(user);
            value = $@"SELECT name,passwordHash FROM Users
                        WHERE name='{user.Name}'";

            reader = DbContext.ExecuteRead(value);
            while (reader.Read())
            {
                       
                passHash = Encoding.UTF8.GetBytes(reader["passwordHash"].ToString());
                
                
                if(VeryfyPassHash(user.Password,passHash)==true)
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
