// <auto-generated />
using DebetCards.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DebetCards.Migrations
{
    [DbContext(typeof(CardDbContext))]
    partial class CardDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.1.22076.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DebetCards.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("card_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CVC")
                        .HasColumnType("integer")
                        .HasColumnName("cvc");

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("cardnumber");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("ValidUntilMonth")
                        .HasColumnType("integer")
                        .HasColumnName("validuntilmonth");

                    b.Property<int>("ValidUntilYear")
                        .HasColumnType("integer")
                        .HasColumnName("validuntilyear");

                    b.HasKey("Id");

                    b.ToTable("cards", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
