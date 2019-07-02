using School.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Entities
{
    public class Student : Person
    {
        public Student(string name, string document) : base(name, document)
        {
        }
    }
}
