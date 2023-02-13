using Microsoft.EntityFrameworkCore;
using FarmaciaHJ.Server.Models;


namespace FarmaciaHJ.Server.Conetxt;

internal interface IMyDbContext
{
    DbSet<Usuario> Usuarios { get; set; }
    DbSet<Usuario> UsuariosRoles { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

internal class MyDbContext : DbContext, IMyDbContext
{
    protected readonly IConfiguration _Configuration;
    public MyDbContext(IConfiguration Configuration) 
    { 
        _Configuration = Configuration;
    }
protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
       options.UseSqlServer(_Configuration.GetConnectionString("FarmaciaHJ"));
    } 
    #region Tabla de la BD.
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<Usuario> UsuariosRoles { get; set; } = null!;
    #endregion
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}