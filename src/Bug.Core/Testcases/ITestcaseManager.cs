using Abp.Domain.Services;
using Bug.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bug.Testcases
{
     public interface ITestcaseManager : IDomainService
    {
        void AssignTestcaseToPerson(Testcase testcase, User user);

    }
}
