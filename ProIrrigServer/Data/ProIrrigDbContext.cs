using Microsoft.EntityFrameworkCore;
using ProIrrigServer.Models;

namespace ProIrrigServer.Data;

public class ProIrrigDbContext : DbContext
{
    public ProIrrigDbContext(DbContextOptions<ProIrrigDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
}