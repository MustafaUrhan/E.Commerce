using E.Common.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnit.ECommonTest
{
    public class UserTest:BaseEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
