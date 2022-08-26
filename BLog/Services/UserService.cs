using AutoMapper;
using BLog.IServices;
using DataAccess.Entities;
using DTO;
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
           // string? newPass = null;
            if (passHash != null && passSalt != null)
            {
                foreach (byte s in passSalt)
                {
                    salt += s;
                }
                foreach (byte h in passHash)
                {
                    hash += h;
                }

                //newPass = salt + hash;
            }

            //user.Password = newPass;

            var data = mapper.Map<User>(user);

            value = $@"(name,passwordHash,passwordSalt) VALUES({data.Name},{hash},{salt})";

            repo.Add(data, table, value);
        }

        public void CreatePassHash(string? pass, out byte[] passHash, out byte[] passSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass)); 
            }
        }


    }
}
