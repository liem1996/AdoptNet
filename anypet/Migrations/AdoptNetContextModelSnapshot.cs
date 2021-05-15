﻿// <auto-generated />
using System;
using AdoptNet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdoptNet.Migrations
{
    [DbContext(typeof(AdoptNetContext))]
    partial class AdoptNetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdoptNet.Models.AdoptionDays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AdoptionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocationAdopt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdoptionDays");
                });

            modelBuilder.Entity("AdoptionDaysAssociation", b =>
                {
                    b.Property<int>("AdoptionDaysId")
                        .HasColumnType("int");

                    b.Property<int>("associationsAdoptID")
                        .HasColumnType("int");

                    b.HasKey("AdoptionDaysId", "associationsAdoptID");

                    b.HasIndex("associationsAdoptID");

                    b.ToTable("AdoptionDaysAssociation");
                });

            modelBuilder.Entity("anypet.Models.Animal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("IdAssociation")
                        .HasColumnType("int");

                    b.Property<int>("Kind")
                        .HasColumnType("int");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int?>("associationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("associationID");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("anypet.Models.AnimalImage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AnimalId")
                        .IsUnique();

                    b.ToTable("AnimalImage");
                });

            modelBuilder.Entity("anypet.Models.Association", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailOfUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("Association");
                });

            modelBuilder.Entity("anypet.Models.AssociationImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssociationId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssociationId")
                        .IsUnique();

                    b.ToTable("AssociationImage");
                });

            modelBuilder.Entity("anypet.Models.UserReg", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(9)
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailOfUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivateName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ThereIsAnimal")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("UserReg");
                });

            modelBuilder.Entity("AdoptionDaysAssociation", b =>
                {
                    b.HasOne("AdoptNet.Models.AdoptionDays", null)
                        .WithMany()
                        .HasForeignKey("AdoptionDaysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("anypet.Models.Association", null)
                        .WithMany()
                        .HasForeignKey("associationsAdoptID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("anypet.Models.Animal", b =>
                {
                    b.HasOne("anypet.Models.Association", "association")
                        .WithMany("AssociationAnimals")
                        .HasForeignKey("associationID");

                    b.Navigation("association");
                });

            modelBuilder.Entity("anypet.Models.AnimalImage", b =>
                {
                    b.HasOne("anypet.Models.Animal", "animal")
                        .WithOne("AnimalImage")
                        .HasForeignKey("anypet.Models.AnimalImage", "AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("animal");
                });

            modelBuilder.Entity("anypet.Models.AssociationImage", b =>
                {
                    b.HasOne("anypet.Models.Association", "Association")
                        .WithOne("AssociationImage")
                        .HasForeignKey("anypet.Models.AssociationImage", "AssociationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Association");
                });

            modelBuilder.Entity("anypet.Models.Animal", b =>
                {
                    b.Navigation("AnimalImage");
                });

            modelBuilder.Entity("anypet.Models.Association", b =>
                {
                    b.Navigation("AssociationAnimals");

                    b.Navigation("AssociationImage");
                });
#pragma warning restore 612, 618
        }
    }
}
