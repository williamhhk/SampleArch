using SampleArch.Helpers.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SampleArch.Events
{
    public class PersonCreatedHandler : IDomainHandler<PersonCreated>
    {
        public void Handle(PersonCreated @event)
        {
            Trace.WriteLine("This is a test");
        }
    }
}