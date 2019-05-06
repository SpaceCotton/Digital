using Abp.AutoMapper;
using Bug.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bug.Testcases.Dto
{

    public class GetTestcasesInput : PagedSortedAndFilteredInputDto
    {

        public TestcaseState? State { get; set; }

        public int? AssignedPersonId { get; set; }

    }
}
