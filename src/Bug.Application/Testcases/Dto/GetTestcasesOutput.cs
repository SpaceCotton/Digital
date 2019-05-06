using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using static Bug.Testcases.Dto.Testcase;

namespace Bug.Testcases.Dto
{
    public class GetTestcasesOutput
    {
        public List<TestcaseDto> Testcases { get; set; }

    }
}
