namespace Vanilla.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users")
            .HasIndex(u => u.Email)
            .IsUnique()
            .IsClustered(false); //non-clustered indexes for frequently searched columns

        builder.ToTable("Users")
            .HasIndex(u => u.CreatedAt)
            .IsClustered(); // only one cluster index. order by

        builder.HasKey(u => u.Id)
            .IsClustered(false);
        
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Email)
            .IsRequired();
        
        builder.HasMany(u => u.Roles)
            .WithOne(r => r.User)
            .OnDelete(DeleteBehavior.Cascade);
    }
}