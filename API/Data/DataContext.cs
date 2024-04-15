using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext {

    public DataContext(DbContextOptions options) : base(options)
    {

    }
    
    public DbSet<AppUser> Users {get; set;} // "Users" will represent the name of the table when it's created
}