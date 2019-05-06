using Abp.EntityFrameworkCore;
using Bug.IRepositories;
using Bug.Testcases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bug.EntityFrameworkCore.Repositories
{
    public class BackendTestcaseRepository :BugRepositoryBase<Testcase> , IBackendTestcaseRepository
    {
        public BackendTestcaseRepository(IDbContextProvider<BugDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// 获取某个用户分配了哪些任务
        /// </summary>
        /// <param name="personId">用户Id</param>
        /// <returns>任务列表</returns>
        public List<Testcase> GetTestcaseByAssignedPersonId(long personId)
        {
            var query = GetAll();

            if (personId > 0)
            {
                query = query.Where(t => t.AssignedPersonId == personId);
            }

            return query.ToList();
        }
    }
}
