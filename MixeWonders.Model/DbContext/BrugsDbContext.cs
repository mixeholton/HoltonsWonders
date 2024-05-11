using Komit.CompanionApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Komit.CompanionApp.Model.Services.ScopeService;

namespace Komit.CompanionApp.Model.DbContexts;

public class BrugsDbContext : DbContext, IProvideDbContext
{
    BrugsDbContext IProvideDbContext.GetTransactionalDbContext()
    {
        ChangeTracker.AutoDetectChangesEnabled = true;
        return this;
    }
    //private readonly IConfiguration configuratio;
    private readonly string database;
    //public BrugsDbContextOld(IConfiguration configuration)
    //{
    //    this.configuration = configuration;
    //}

    public BrugsDbContext(DbContextOptions<BrugsDbContext> options, IConfiguration configuration) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
        try
        {
            database = configuration.GetSection("BrugsDBSettings").GetSection("Database").Value;
        }
        catch (Exception exc)
        {
            throw new DomainException("Init af Schema fejlede", "Kunne ikke finde sektionen BrugsDatabase og sektionen Database");
        }

    }
    #region transaction handling
    protected void ValidateTransaction()
    {
        if (!ChangeTracker.AutoDetectChangesEnabled)
            throw new Exception("SaveChanges cannot be called on the readonly context");
    }
    public override int SaveChanges()
    {
        ValidateTransaction();
        return base.SaveChanges();
    }
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ValidateTransaction();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        ValidateTransaction();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ValidateTransaction();
        return base.SaveChangesAsync(cancellationToken);
    }
    #endregion
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Logadgang> Logadgangs { get; set; }
    public virtual DbSet<LinkUserAD> LinkedUser { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LinkUserAD>(s =>
        {
            s.Property(x => x.UserName);
            s.Property(x => x.ADId);
        });
        modelBuilder.Entity<Author>(entity =>
        {

        });        
        modelBuilder.Entity<Logadgang>(entity =>
        {
            
        });

    }
}
