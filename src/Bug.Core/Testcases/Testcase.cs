using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Bug.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bug.Testcases
{
    public class Testcase : Entity, IHasCreationTime
    {
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 64 * 1024;//64kb

        public long? AssignedPersonId { get; set; }

        [ForeignKey("AssignedPersonId")]
        public User AssignedPerson { get; set; }

        [Required]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public TestcaseState State { get; set; }
        public DateTime CreationTime { get; set; }

        public Testcase()
        {
            CreationTime = Clock.Now;
            State = TestcaseState.Open; 
        }

        public Testcase(string title, string description = null) : this()
        {
            Title = title;
            Description = description;
        }
    }

    public enum TestcaseState : byte
    {
        Open = 0,
        Completed = 1
    }


}
