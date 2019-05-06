using Abp.Dependency;
using Abp.Domain.Entities.Caching;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Bug.Testcases.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bug.Testcases
{
    public class TaskCache : EntityCache<Testcase, TestcaseCacheItem>, ITestcaseCache, ISingletonDependency
    {
        public TaskCache(ICacheManager cacheManager, IRepository<Testcase, int> repository, string cacheName = null)
            : base(cacheManager, repository, cacheName)
        {
        }
    }
}
