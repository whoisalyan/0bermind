using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Obermind.Models;

namespace Obermind.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Obermind.Models.customer> customer { get; set; }
        public DbSet<Obermind.Models.List_item> List_item { get; set; }
        public DbSet<Obermind.Models.Products> Products { get; set; }
        public DbSet<Obermind.Models.Purchase_Order> Purchase_Order { get; set; }
    }
}