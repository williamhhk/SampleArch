using SampleArch.Helpers.Domain;
using SampleArch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleArch.Events
{
    public class PersonCreated : IDomainEvent
    {
        public Person _person { get; set; }
    }
}