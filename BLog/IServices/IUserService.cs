using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLog.IServices
{
    public interface IUserService<User,UserDTO>
    {
        public bool Register(UserDTO user, string table, string value);
        public void CreatePassHash(string pass, out byte[] passHash);
        public string LogIn(UserDTO user, string table, string value);
        
    }
}
