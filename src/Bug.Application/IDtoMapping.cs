using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bug
{
    /// <summary>
    ///     实现该接口以进行映射规则创建
    /// </summary>
    internal interface IDtoMapping
    {
        void CreateMapping(IMapperConfigurationExpression mapperConfig);
    }
}
