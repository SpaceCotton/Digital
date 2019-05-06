using Abp.Authorization;
using Abp.Domain.Services;
using Abp.Events.Bus;
using Abp.Runtime.Session;
using Bug.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bug.Testcases
{
    public class TestcaseManager : DomainService, ITestcaseManager
    {
        private readonly IPermissionChecker _permissionChecker;
        private readonly IAbpSession _abpSession;
        private readonly IEventBus _eventBus;

        public TestcaseManager(IPermissionChecker permissionChecker, IAbpSession abpSession, IEventBus eventBus)
        {
            _permissionChecker = permissionChecker;
            _abpSession = abpSession;
            _eventBus = eventBus;
        }

        public void AssignTestcaseToPerson(Testcase testcase, User user)
        {
            //已经分配，就不再分配
            if (testcase.AssignedPersonId.HasValue && testcase.AssignedPersonId.Value == user.Id)
            {
                return;
            }

            if (testcase.State != TestcaseState.Open)
            {
                throw new ApplicationException("处于非活动状态的任务不能分配！");
            }

            testcase.AssignedPersonId = user.Id;


            //使用领域事件触发发送通知操作
            _eventBus.Trigger(new TestcaseAssignedEventData(testcase, user));
        }
    }
}
