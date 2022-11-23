using BLog.IServices;
using DataAccess;
using DataAccess.Entities;
using DTO;
using Repo.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLog.Services
{
    public class SubjectService : BaseService<Subject>, ISubjectService
    {
        public SubjectService(IRepository<Subject> repo) : base(repo)
        {
        }

        public void Add(Subject entity, string table, string value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id, string table, string value)
        {
            throw new NotImplementedException();
        }

        public DataTable Get(string table)
        {
            throw new NotImplementedException();
        }

        public DataTable Get(int id, string table, string value)
        {
            throw new NotImplementedException();
        }

        public DataTable GetSubject()
        {
            string query = $@"select S.S_ID as S_ID,E.EX_NAME as EX_NAME,E.EX_ID AS EX_ID,S.S_NAME as S_NAME from T_SUBJECT AS S
                                LEFT JOIN T_EXAM AS E ON E.EX_ID=S.S_EX_ID";

            return DbContext.Execute(query);  
            
        }

        public void Update(Subject entity, string table, string value)
        {
            throw new NotImplementedException();
        }
    }
}
