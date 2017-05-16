using SampleArch.Helpers.Domain;
using SampleArch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleArch.Events
{
    public class PersonCreated : DomainEvent, IDomainEvent
    {
        public Person _person { get; set; }

        public override void Flatten()
        {
            this.Args.Add("Name", this._person.Name);
            this.Args.Add("Phone", this._person.Phone);
            this.Args.Add("State", this._person.State);
            this.Args.Add("UpdateBy", this._person.UpdatedBy);
            this.Args.Add("UpdateDate", this._person.UpdatedDate);
        }
    }
}