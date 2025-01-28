using Microsoft.EntityFrameworkCore;

namespace PetStore.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\code you projects\\LindasPetShop\\PetStore.Data\\PetStore.db")
                           .LogTo(Console.WriteLine);
        }
    }
}
