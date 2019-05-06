using System;
using System.Collections.Generic;
using System.Text;
using Abp.AutoMapper;
using Abp.Runtime.Validation;

namespace Bug.Person.Dto
{
    [AutoMapTo(typeof(Person))]
    class CreatePersonDto : IShouldNormalize
    {
        public string Name { get; set; }

        public void Normalize()
        {
            throw new NotImplementedException();
        }
    }
}
