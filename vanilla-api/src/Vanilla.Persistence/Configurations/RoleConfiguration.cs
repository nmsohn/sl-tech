namespace Vanilla.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id)
            .IsClustered(false);
        
        builder.HasIndex(r => r.Type)
            .IsUnique()
            .IsClustered(false);
    }
}