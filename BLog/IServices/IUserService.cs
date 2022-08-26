using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLog.IServices
{
    public interface IUserService<User,UserDTO>
    {
        public void Register(UserDTO user, string table, string value);
        public void CreatePassHash(string? pass, out byte[] passHash, out byte[] passSalt);
        
    }
}
