using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NHibernateDemoApp
{
    class Student
    {
        public virtual int ID { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
    }
}
