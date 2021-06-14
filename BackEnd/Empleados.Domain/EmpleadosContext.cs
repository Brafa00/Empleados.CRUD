using Empleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Empleados.Domain
{
    public class EmpleadosContext : DbContext, IQueryableUnitOfWork
    {
        public EmpleadosContext(DbContextOptions<EmpleadosContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbContext GetContext()
        {
            return this;
        }

        public DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                return;
            }

            modelBuilder.Entity<Cargo>().HasKey(key => key.Id).IsClustered();
            modelBuilder.Entity<Empleado>().HasKey(key => key.Id).IsClustered();
            modelBuilder.Entity<Empleado>().HasAlternateKey(altKey => altKey.Documento);
            modelBuilder.Entity<Empleado>()
                .HasOne(x => x.Cargo)
                .WithMany()
                .HasForeignKey(fk => fk.IdCargo);
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await ex.Entries.Single().ReloadAsync().ConfigureAwait(false);
            }
        }
    }
}
