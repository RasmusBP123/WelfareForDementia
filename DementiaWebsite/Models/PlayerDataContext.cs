﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DementiaWebsite.Models
{
    public class SignUpDataContext : DbContext
    {

        public SignUpDataContext(DbContextOptions<SignUpDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Person> Persons {get; set; }
    }
}
