using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {

        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("compra");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("idcompra")
                .UseIdentityColumn();

            builder.Property(x => x.PersonId)
                .HasColumnName("idproduto");

            builder.Property(x => x.Date)
                .HasColumnName("datacompra");

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Purchases);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Purchases);
                
        }
    }
}
