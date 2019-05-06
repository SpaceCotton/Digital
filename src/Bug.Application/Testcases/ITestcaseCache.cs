using Abp.Domain.Entities.Caching;
using Bug.Testcases.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bug.Testcases
{
    public interface ITestcaseCache : IEntityCache<TestcaseCacheItem>
    {
    }
}
