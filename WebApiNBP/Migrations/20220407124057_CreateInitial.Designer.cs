// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiNBP.Data;

#nullable disable

namespace WebApiNBP.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220407124057_CreateInitial")]
    partial class CreateInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApiNBP.Pozycja", b =>
                {
                    b.Property<string>("Kod_waluty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kurs_sredni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa_waluty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Przelicznik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Pozycje");
                });
#pragma warning restore 612, 618
        }
    }
}
