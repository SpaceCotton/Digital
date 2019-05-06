using Abp.AspNetCore.Mvc.Authorization;
using Abp.AspNetCore.Mvc.Controllers;
using Bug.Testcase;
using Bug.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bug.Controllers
{


    [AbpMvcAuthorize]
    public class TestcasesController : AbpController
    {
        private readonly ITestcaseAppService _testcaseAppService;
        private readonly IUserAppService _userAppService;

        public TestcasesController(ITestcaseAppService testcaseAppService, IUserAppService userAppService)
        {
            _testcaseAppService = testcaseAppService;
            _userAppService = userAppService;
        }
    }


}
