using BLog.IServices;
using DataAccess.Entities;
using Repo.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLog.Services
{
    public class UserListService: BaseService<UserList>, IUserListService
    {
        public UserListService(IRepository<UserList> repo) : base(repo)
        {

        }

        public override void Add(UserList entity, string table, string value)
        {
            value = $@" (NAME, SURNAME, PASSWORD, STATUS) 
                     VALUES('{entity.NAME}','{entity.SURNAME}','{entity.PASSWORD}', {entity.STATUS})";
            base.Add(entity, table, value);
        }

        public override void Delete(int id, string table, string value)
        {
            value = $@"WHERE USERID={id}";
            base.Delete(id, table, value);
        }

        public override DataTable Get(string table)
        {
            return base.Get(table);
        }

        public override DataTable Get(int id, string table, string value)
        {
            value = $@" WHERE USERID={id}";
            return base.Get(id, table, value);
        }

        public override void Update(UserList entity, string table, string value)
        {
            value = $@" SET NAME='{entity.NAME}', SURNAME='{entity.SURNAME}', PASSWORD='{entity.PASSWORD}', STATUS={entity.STATUS}
                        WHERE USERID={entity.USERID}";
            base.Update(entity, table, value);
        }
    }
}
