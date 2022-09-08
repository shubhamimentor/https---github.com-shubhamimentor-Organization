using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Org.Data
{
    public class ApplicationDBContext : DbContext
    {
        private readonly ApplicationDBContext _context;


        public ApplicationDBContext([NotNullAttribute]DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
            
        }
       
        public DbSet<Register> Registers { get; set; }

        public DbSet<Invite> Invites { get; set; }

       
    }       
}
