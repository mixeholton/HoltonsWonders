
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MixeWonders.Values.Entities;
using static MixeWonders.Values.Services.ScopeService;

namespace MixeWonders.Values.Context;

public class BrugsDbContext : DbContext, IProvideDbContext
{
    BrugsDbContext IProvideDbContext.GetTransactionalDbContext()
    {
        ChangeTracker.AutoDetectChangesEnabled = true;
        return this;
    }
    private readonly IConfiguration configuration;
    public BrugsDbContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DbConnect"), b => b.MigrationsAssembly("MixeWonders.ClientServer"));
    //}
    public BrugsDbContext(DbContextOptions<BrugsDbContext> options, IConfiguration configuration) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
        this.configuration = configuration;

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
    public DbSet<AffiliationEntity> Affiliations { get; set; }
    public DbSet<GroupEntity> Groups { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<PermissionEntity> Permissions { get; set; }
    public DbSet<CreditDebitEntity> CreditDebits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {        

        modelBuilder.Entity<CreditDebitEntity>(x =>
        {
            x.HasKey(x => x.Id);
            x.Property(e => e.Amount).HasColumnType("decimal(18,2)");
        });
        // One-to-One Relationship between UserEntity and AffiliationEntity
        modelBuilder.Entity<UserEntity>(x =>
        {
            x.HasKey(x => x.Id);
            x.HasOne(u => u.Affiliation).WithOne(a => a.User).HasForeignKey<UserEntity>(u => u.AffiliationId);
            x.HasMany(u => u.Groups).WithMany(x => x.Users);
        });

        // Many-to-Many Relationship between GroupEntity and UserEntity
        modelBuilder.Entity<GroupEntity>(x =>
        {
            x.HasKey(x => x.Id);
            x.HasMany(g => g.Users).WithMany(u => u.Groups);
            x.HasMany(g => g.Roles).WithMany(r => r.Groups);
        });
        modelBuilder.Entity<AffiliationEntity>(x =>
        {            
            x.HasKey(x => x.Id);
            x.HasOne(g => g.User).WithOne(u => u.Affiliation).HasForeignKey<AffiliationEntity>(u => u.UserId);
            x.HasMany(a => a.Groups).WithMany(g => g.Affiliations);
            x.HasMany(a => a.Roles).WithMany(g => g.Affiliations);
        });

    }
}
