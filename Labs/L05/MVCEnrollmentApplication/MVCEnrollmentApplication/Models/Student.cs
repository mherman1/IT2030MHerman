﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEnrollmentApplication.Models
{
    public class Student
    {
        public virtual int StudentID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

    }
}