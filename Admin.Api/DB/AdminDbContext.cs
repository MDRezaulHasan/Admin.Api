using System;
using Admin.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Api.DB;

public class AdminDbContext : DbContext
{
public AdminDbContext(DbContextOptions options):base(options)
{
    
}
public DbSet<Skill> Skills { get;set;}
}
