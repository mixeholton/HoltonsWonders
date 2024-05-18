using Komit.MixeWonders.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static MixeWonders.Model.Services.ScopeService;

namespace MixeWonders.Model.DbContexts;

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
    public virtual DbSet<AffiliationEntity> Affiliation { get; set; }
    public virtual DbSet<UserEntity> Users { get; set; }
    public virtual DbSet<CreditDebitEntity> CreditDebit { get; set; }
    public virtual DbSet<GroupEntity> Group { get; set; }
    public virtual DbSet<RoleEntity> Role { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AffiliationEntity>(s =>
        {
            s.OwnsOne(x => x.User);
            s.OwnsMany(x => x.Groups);
            s.OwnsMany(x => x.Roles);
        });
        modelBuilder.Entity<CreditDebitEntity>(entity =>
        {
            entity.HasOne(c => c.User);
        });        
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasOne(x => x.Affiliation);
            entity.OwnsMany(x => x.creditDebits);
        });
        modelBuilder.Entity<GroupEntity>(entity =>
        {
            entity.HasOne(x => x.Affiliation);
            entity.HasMany(x => x.Roles);
        });
        modelBuilder.Entity<RoleEntity>(entity =>
        {
            entity.HasOne(x => x.Affiliation);
        });


    }
}
