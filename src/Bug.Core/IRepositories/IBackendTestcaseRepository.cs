using Abp.Domain.Repositories;
using Bug.Testcases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bug.IRepositories
{
    /// <summary>
    /// 自定义仓储示例
    /// </summary>
    public interface IBackendTestcaseRepository : IRepository<Testcase>
    {
        /// <summary>
        /// 获取某个用户分配了哪些任务
        /// </summary>
        /// <param name="personId">用户Id</param>
        /// <returns>任务列表</returns>
        List<Testcase> GetTestcaseByAssignedPersonId(long personId);
    }
}
