using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace Bug.Person.Dto
{
    class Person : Entity
    {
        public virtual string Name { get; set; }

    }
}
