using School.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Entities
{
    public class Teacher : Person
    {
        public Teacher(string name, string document) : base(name, document)
        {
        }
    }
}
