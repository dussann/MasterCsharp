// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StackOverflow.Data;

namespace StackOverflow.Migrations
{
    [DbContext(typeof(SOContext))]
    [Migration("20211113225818_init3")]
    partial class init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("StackOverflow.Models.Answer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<short>("Raiting")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("StackOverflow.Models.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<string>("Header")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("StackOverflow.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("JobTitle")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
