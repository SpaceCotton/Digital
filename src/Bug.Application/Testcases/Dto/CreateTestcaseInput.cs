using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bug.Testcases.Dto
{
    [AutoMapTo(typeof(Testcase))] //定义单向映射
    public class CreateTestcaseInput
    {

        public int? AssignedPersonId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }

        public TestcaseState State { get; set; }
        public override string ToString()
        {
            return string.Format("[CreateTestcaseInput > AssignedPersonId = {0}, Description = {1}]", AssignedPersonId, Description);
        }

    }
}
