using Flunt.Validations;
using School.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Entities
{
    public class Subject:Entity
    {
        public Subject(string description, Teacher teacherResponsible)
        {
            Description = description;
            TeacherResponsible = teacherResponsible;
            Validate();
        }

        public string Description { get; private set; }
        public Teacher TeacherResponsible { get; private set; }

        public override void Validate()
        {
            AddNotifications(
            new Contract()
                .Requires()
                .IsNotNullOrEmpty(Description, "Descrição", " ")
            );
            AddNotifications(TeacherResponsible.Notifications);

        }
    }
}
