using Bug.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bug.Testcases
{
   public class TestcaseAssignedEventData :TestcaseEventData
    {
        public User User { get; set; }
        public TestcaseAssignedEventData(Testcase testcase, User user)
        {
            this.Testcase = testcase;
            this.User = user;
        }

    }
}
