using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Net.Mail.Smtp;
using Abp.Notifications;
using Abp.Timing;
using AutoMapper;
using Bug.Authorization;
using Bug.Authorization.Users;
using Bug.Testcases.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bug.Testcases.Dto.Testcase;
using Bug.Testcases;
using Bug;
using Bug.Testcase;
using Abp.Events.Bus;
using Microsoft.EntityFrameworkCore;
using Abp.Collections.Extensions;
using Abp.Extensions;
using System.Linq.Dynamic;
using Microsoft.EntityFrameworkCore.Metadata;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;

namespace Bug.Testcases
{
    public class TestcaseAppService : BugAppServiceBase, ITestcaseAppService
    {

        private readonly INotificationPublisher _notificationPublisher;
        private readonly ISmtpEmailSender _smtpEmailSender;
        //These members set in constructor using constructor injection.

        private readonly IRepository<Testcase> _testcaseRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly ITestcaseManager _testcaseManager;       
        private readonly ITestcaseCache _testcaseCache;
        private readonly IEventBus _eventBus;



        /// <summary>
        ///     In constructor, we can get needed classes/interfaces.
        ///     They are sent here by dependency injection system automatically.
        /// </summary>
        public TestcaseAppService(
            IRepository<Testcase> testcaseRepository,
            IRepository<User, long> userRepository,
            ISmtpEmailSender smtpEmailSender,
            INotificationPublisher notificationPublisher,
            ITestcaseCache testcaseCache,
            ITestcaseManager testcaseManager,
            IEventBus eventBus)
        {
            _testcaseRepository = testcaseRepository;
            _userRepository = userRepository;
            _smtpEmailSender = smtpEmailSender;
            _notificationPublisher = notificationPublisher;
            _testcaseCache = testcaseCache;
            _testcaseManager = testcaseManager;
            _eventBus = eventBus;
        }

        public TestcaseCacheItem GetTestcaseFromCacheById(int testcaseId)
        {
            return _testcaseCache[testcaseId];
        }
        public IList<TestcaseDto> GetAllTestcases()
        {
            var testcases = _testcaseRepository.GetAll().OrderByDescending(t => t.CreationTime).ToList();
            return Mapper.Map<IList<TestcaseDto>>(testcases);
        }


        public int CreateTestcase(CreateTestcaseInput input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            Logger.Info("Creating a testcase for input: " + input);

            //判断用户是否有权限
            if (input.AssignedPersonId.HasValue && input.AssignedPersonId.Value != AbpSession.GetUserId())
                PermissionChecker.Authorize(PermissionNames.Pages_Testcases_AssignPerson);

            var testcase = Mapper.Map<Testcase>(input);

            int result = _testcaseRepository.InsertAndGetId(testcase);

            //只有创建成功才发送邮件和通知
            if (result > 0)
            {
                if (input.AssignedPersonId.HasValue)
                {
                    var user = _userRepository.Load(input.AssignedPersonId.Value);
                    //task.AssignedPerson = user;
                    //var message = "You hava been assigned one task into your todo list.";

                    //使用领域事件触发发送通知操作
                    _eventBus.Trigger(new TestcaseAssignedEventData(testcase, user));

                    //TODO:需要重新配置QQ邮箱密码
                    //_smtpEmailSender.Send("ysjshengjie@qq.com", task.AssignedPerson.EmailAddress, "New Todo item", message);

                    //_notificationPublisher.Publish("NewTask", new MessageNotificationData(message), null,
                    //    NotificationSeverity.Info, new[] { task.AssignedPerson.ToUserIdentifier() });
                }
            }

            return result;
        }
        [AbpAuthorize(PermissionNames.Pages_Testcases_Delete)]
        public void DeleteTestcase(int testcaseId)
        {
            var testcase = _testcaseRepository.Get(testcaseId);
            if (testcase != null)
                _testcaseRepository.Delete(testcase);
        }


        public TestcaseDto GetTestcaseById(int testcaseId)
        {
            var testcase = _testcaseRepository.Get(testcaseId);

            return testcase.MapTo<TestcaseDto>();
        }

        public async Task<TestcaseDto> GetTestcaseByIdAsync(int testcaseId)
        {
            //Called specific GetAllWithPeople method of task repository.
            var testcase = await _testcaseRepository.GetAsync(testcaseId);

            //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return testcase.MapTo<TestcaseDto>();
        }

        public GetTestcasesOutput GetTestcases(GetTestcasesInput input)
        {
            var query = _testcaseRepository.GetAll().Include(t => t.AssignedPerson)
                        .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
                        .WhereIf(!input.Filter.IsNullOrEmpty(), t => t.Title.Contains(input.Filter))
                        .WhereIf(input.AssignedPersonId.HasValue, t => t.AssignedPersonId == input.AssignedPersonId.Value);

            //排序
            if (!string.IsNullOrEmpty(input.Sorting))
               query = query.OrderBy(input.Sorting);
            else
                query = query.OrderByDescending(t => t.CreationTime);

            var testcasseList = query.ToList();

            //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return new GetTestcasesOutput
            {
                Testcases = Mapper.Map<List<TestcaseDto>>(testcasseList)
            };
        }


        public PagedResultDto<TestcaseDto> GetPagedTasks(GetTestcasesInput input)
        {
            //初步过滤
            var query = _testcaseRepository.GetAll().Include(t => t.AssignedPerson)
                .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
                .WhereIf(!input.Filter.IsNullOrEmpty(), t => t.Title.Contains(input.Filter))
                .WhereIf(input.AssignedPersonId.HasValue, t => t.AssignedPersonId == input.AssignedPersonId.Value);

            //排序
            query = !string.IsNullOrEmpty(input.Sorting) ? query.OrderBy(input.Sorting) : query.OrderByDescending(t => t.CreationTime);

            //获取总数
            var tasksCount = query.Count();
            //默认的分页方式
            //var taskList = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            //ABP提供了扩展方法PageBy分页方式
            var taskList = query.PageBy(input).ToList();

            return new PagedResultDto<TestcaseDto>(tasksCount, taskList.MapTo<List<TestcaseDto>>());
        }

        public void AssignTestcaseToPerson(AssignTestcaseToPersonInput input)
        {
            var testcase = _testcaseRepository.Get(input.TestcaseId);
            var user = _userRepository.Get(input.UserId);
            _testcaseManager.AssignTestcaseToPerson(testcase, user);
            //这里有一个问题就是，当开发人员不知道有这个TestcaseManager时，依然可以通过直接修改Task的AssignedPersonId属性就行任务分配。

            //分配任务成功后，触发领域事件，发送邮件通知
            //_eventBus.Trigger(new TestcaseAssignedEventData(testcase, user));//由领域服务触发领域事件

        }


        public void UpdateTestcase(UpdateTestcaseInput input)
        {
            //We can use Logger, it's defined in ApplicationService base class.
            Logger.Info("Updating a testcase for input: " + input);

            //获取是否有权限
            bool canAssignTestcaseToOther = PermissionChecker.IsGranted(PermissionNames.Pages_Testcases_AssignPerson);
            //如果任务已经分配且未分配给自己，且不具有分配任务权限，则抛出异常
            if (input.AssignedPersonId.HasValue && input.AssignedPersonId.Value != AbpSession.GetUserId() &&
                !canAssignTestcaseToOther)
            {
                throw new AbpAuthorizationException("没有分配测试案例给他人的权限！");
            }

            var updateTestcase = Mapper.Map<Testcase>(input);
            var user = _userRepository.Get(input.AssignedPersonId.Value);
            //先执行分配任务
            _testcaseManager.AssignTestcaseToPerson(updateTestcase, user);

            //再更新其他字段
            _testcaseRepository.Update(updateTestcase);
        }
    }
}
