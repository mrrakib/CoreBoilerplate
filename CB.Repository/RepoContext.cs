using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepoContext : DbContext
    {
        public RepoContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<SocietyInfo> SocietyInfos { get; set; }
        public DbSet<SocietyMember> SocietyMembers { get; set; }
    }
}
