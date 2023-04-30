using KidscryptoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace KidscryptoAp.Data
{
    public class ApiContext : DbContext
    {
    public DbSet<CryptoFact> factories { get; set; }
    public ApiContext(DbContextOptions<ApiContext> options) : base(options) {
 
    }
    }
}
