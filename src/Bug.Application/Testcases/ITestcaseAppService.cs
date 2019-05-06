using Abp.Application.Services;
using Bug.Testcases.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Bug.Testcases.Dto.Testcase;

namespace Bug.Testcase
{
    public interface ITestcaseAppService : IApplicationService
    {
        GetTestcasesOutput GetTestcases(GetTestcasesInput input);

        void UpdateTestcase(UpdateTestcaseInput input);

       int CreateTestcase(CreateTestcaseInput input);

        Task<TestcaseDto> GetTestcaseByIdAsync(int testcaseId);

        TestcaseDto GetTestcaseById(int testcaseId);

        void DeleteTestcase(int testcaseId);

        IList<TestcaseDto> GetAllTestcases();
    }

}
