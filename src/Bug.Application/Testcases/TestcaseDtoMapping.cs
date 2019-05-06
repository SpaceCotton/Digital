using AutoMapper;
using Bug.Testcases.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using static Bug.Testcases.Dto.Testcase;

namespace Bug.Testcases
{
    class TestcaseDtoMapping : IDtoMapping
    {
        public void CreateMapping(IMapperConfigurationExpression mapperConfig)
        {
            //定义单向映射
            mapperConfig.CreateMap<CreateTestcaseInput, Testcase>();
            mapperConfig.CreateMap<UpdateTestcaseInput, Testcase>();
            mapperConfig.CreateMap<TestcaseDto, UpdateTestcaseInput>();

            //自定义映射
            var testcaseDtoMapper = mapperConfig.CreateMap<Testcase, TestcaseDto>();
            testcaseDtoMapper.ForMember(dto => dto.AssignedPersonName, map => map.MapFrom(m => m.AssignedPerson.FullName));
        }

    }
}
