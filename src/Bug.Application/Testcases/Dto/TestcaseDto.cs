using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bug.Testcases.Dto
{
  //  [AutoMapTo(typeof(TestcaseDto))] //定义单向映射
    public class Testcase : Entity<long>
    {
        /// <summary>
        /// A DTO class that can be used in various application service methods when needed to send/receive Task objects.
        /// </summary>
       // [AutoMapTo(typeof(Testcase))] //定义单向映射
        public class TestcaseDto : EntityDto
        {
            public long? AssignedPersonId { get; set; }

            public string AssignedPersonName { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }

            public DateTime CreationTime { get; set; }

            public TestcaseState State { get; set; }

            //This method is just used by the Console Application to list tasks
            public override string ToString()
            {
                return string.Format(
                    "[Testcase Id={0}, Description={1}, CreationTime={2}, AssignedPersonName={3}, State={4}]",
                    Id,
                    Description,
                    CreationTime,
                    AssignedPersonId,
                    (TestcaseState)State
                    );
            }
        }
    }
}
