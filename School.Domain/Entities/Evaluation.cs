using Flunt.Validations;
using School.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Entities
{
    public class Evaluation:Entity
    {
        public Evaluation(Subject subject, double note)
        {
            Subject = subject;
            Note = note;
            Validate();
        }

        public Subject Subject { get; private set; }
        public double Note { get; private set; }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
               .Requires()
               .IsGreaterOrEqualsThan(Note,0.0M, "Nota","")
               .IsLowerOrEqualsThan(Note,10.0M, "Nota", "")
            );
          
            AddNotifications(Subject.Notifications);
        }
    }
}
