// <auto-generated />
using CommanderGQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CommanderGQL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210321051926_MySQLContext")]
    partial class MySQLContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("CommanderGQL.Models.Command", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CommandLine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HowTo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("CommanderGQL.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LicenseKey")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("CommanderGQL.Models.Command", b =>
                {
                    b.HasOne("CommanderGQL.Models.Platform", "Platform")
                        .WithMany("Commands")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("CommanderGQL.Models.Platform", b =>
                {
                    b.Navigation("Commands");
                });
#pragma warning restore 612, 618
        }
    }
}
