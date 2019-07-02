using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Shared
{
    public class Person:Entity
    {
        public Person(string name, string document)
        {
            Name = name;
            Document = document;
            Validate();
        }

        public string Name { get; private set; }
        public string Document { get; private set; }

        public override void Validate()
        {
            AddNotifications(
            new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Nome", "")
                .IsNotNullOrEmpty(Document, "Documento", "")
                );
        }
    }
}
