using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Mapping
{
	public class ProductMap : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasMany(x => x.ProductCategory).WithOne(x => x.Product).HasForeignKey(x => x.ProductId).IsRequired().OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(x => x.ProductSupplier).WithOne(x => x.Product).HasForeignKey(x => x.ProductId)
				.IsRequired().OnDelete(DeleteBehavior.Restrict);

			builder.Property(x => x.SalesStartDate).HasColumnType("datetime2");
			builder.Property(x => x.SalesEndDate).HasColumnType("datetime2");

			builder.HasKey(x => x.Id);
			builder.HasMany(x => x.ProductBrand).WithOne(x => x.Product).HasForeignKey(x => x.ProductId).IsRequired().OnDelete(DeleteBehavior.Restrict);

			//ProductCategori, ProductSupplier, ProductBrand tablosu ile ilişki kuruldu.
		}
	}
}
