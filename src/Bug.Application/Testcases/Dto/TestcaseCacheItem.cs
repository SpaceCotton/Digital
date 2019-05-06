using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bug.Testcases.Dto
{
    [AutoMapFrom(typeof(Testcase))]
     public class TestcaseCacheItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TestcaseState State { get; set; }
    }
}
