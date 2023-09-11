using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain;

namespace ProductService.Persistance;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();
        builder.HasData(new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Poco X4 GT",
                Description = "AHUENII INTERNET",
                Category =  "Phone",
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Pova 4",
                Description = "ZA SVOI BABKI TOP",
                Category =  "Phone",
            }
        });
    }
}