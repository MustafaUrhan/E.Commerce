using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnit.ECommonTest
{
    public class TestDbContext:DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options) { }
        public DbSet<UserTest> Users { get; set; }
    }
}
