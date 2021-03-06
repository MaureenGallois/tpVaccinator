// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VaccinatorNet.Models;

namespace VaccinatorNet.Migrations
{
    [DbContext(typeof(ContextBDD))]
    partial class ContextBDDModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("VaccinatorNet.Models.Injection", b =>
                {
                    b.Property<int>("VaccinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("InjectionDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lot")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReminderDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VaccineId")
                        .HasColumnType("INTEGER");

                    b.HasKey("VaccinationId");

                    b.HasIndex("PersonId");

                    b.HasIndex("VaccineId");

                    b.ToTable("Injections");
                });

            modelBuilder.Entity("VaccinatorNet.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsResident")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lastname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("VaccinatorNet.Models.Vaccine", b =>
                {
                    b.Property<int>("VaccineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("VaccineType")
                        .HasColumnType("TEXT");

                    b.Property<int>("ValidityPeriod")
                        .HasColumnType("INTEGER");

                    b.HasKey("VaccineId");

                    b.ToTable("Vaccines");
                });

            modelBuilder.Entity("VaccinatorNet.Models.VaccineType", b =>
                {
                    b.Property<int>("VaccineTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("VaccineTypeId");

                    b.ToTable("VaccineTypes");
                });

            modelBuilder.Entity("VaccinatorNet.Models.Injection", b =>
                {
                    b.HasOne("VaccinatorNet.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("VaccinatorNet.Models.Vaccine", "Vaccine")
                        .WithMany()
                        .HasForeignKey("VaccineId");

                    b.Navigation("Person");

                    b.Navigation("Vaccine");
                });
#pragma warning restore 612, 618
        }
    }
}
