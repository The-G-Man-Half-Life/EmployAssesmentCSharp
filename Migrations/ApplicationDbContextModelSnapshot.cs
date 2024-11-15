﻿// <auto-generated />
using System;
using EmployAssesmentCSharp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployAssesmentCSharp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EmployAssesmentCSharp.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentTypeId")
                        .HasColumnType("int")
                        .HasColumnName("appointment_type_id");

                    b.Property<int>("DiseasId")
                        .HasColumnType("int")
                        .HasColumnName("diseas_id");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("doctor_id");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("end_time");

                    b.Property<int>("PatientId")
                        .HasColumnType("int")
                        .HasColumnName("patient_id");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("reason");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("start_time");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentTypeId");

                    b.HasIndex("DiseasId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentTypeId = 3,
                            DiseasId = 1,
                            DoctorId = 1,
                            EndTime = new DateTime(2024, 12, 10, 5, 27, 15, 260, DateTimeKind.Local).AddTicks(533),
                            PatientId = 4,
                            Reason = "Enim maiores sunt quia dolor est neque sunt aut.",
                            StartTime = new DateTime(2024, 12, 10, 4, 27, 15, 260, DateTimeKind.Local).AddTicks(533)
                        },
                        new
                        {
                            Id = 2,
                            AppointmentTypeId = 3,
                            DiseasId = 3,
                            DoctorId = 5,
                            EndTime = new DateTime(2024, 12, 7, 3, 0, 15, 260, DateTimeKind.Local).AddTicks(1926),
                            PatientId = 5,
                            Reason = "Aut et eum voluptatem recusandae voluptas ullam sunt illo eveniet.",
                            StartTime = new DateTime(2024, 12, 7, 1, 54, 15, 260, DateTimeKind.Local).AddTicks(1926)
                        },
                        new
                        {
                            Id = 3,
                            AppointmentTypeId = 3,
                            DiseasId = 5,
                            DoctorId = 3,
                            EndTime = new DateTime(2024, 11, 24, 5, 7, 15, 260, DateTimeKind.Local).AddTicks(2016),
                            PatientId = 5,
                            Reason = "Laudantium sequi sed ullam voluptas eum qui.",
                            StartTime = new DateTime(2024, 11, 24, 3, 11, 15, 260, DateTimeKind.Local).AddTicks(2016)
                        },
                        new
                        {
                            Id = 4,
                            AppointmentTypeId = 2,
                            DiseasId = 1,
                            DoctorId = 3,
                            EndTime = new DateTime(2024, 11, 20, 2, 5, 15, 260, DateTimeKind.Local).AddTicks(2047),
                            PatientId = 1,
                            Reason = "Consequatur quia id delectus fuga quis natus.",
                            StartTime = new DateTime(2024, 11, 20, 0, 13, 15, 260, DateTimeKind.Local).AddTicks(2047)
                        },
                        new
                        {
                            Id = 5,
                            AppointmentTypeId = 1,
                            DiseasId = 5,
                            DoctorId = 3,
                            EndTime = new DateTime(2024, 11, 28, 19, 43, 15, 260, DateTimeKind.Local).AddTicks(2078),
                            PatientId = 5,
                            Reason = "Cum cumque et voluptatum minima veniam.",
                            StartTime = new DateTime(2024, 11, 28, 18, 34, 15, 260, DateTimeKind.Local).AddTicks(2078)
                        },
                        new
                        {
                            Id = 6,
                            AppointmentTypeId = 2,
                            DiseasId = 2,
                            DoctorId = 1,
                            EndTime = new DateTime(2024, 12, 9, 4, 57, 15, 260, DateTimeKind.Local).AddTicks(2106),
                            PatientId = 4,
                            Reason = "Molestiae sapiente corporis debitis temporibus quia minus sunt voluptatem amet.",
                            StartTime = new DateTime(2024, 12, 9, 3, 31, 15, 260, DateTimeKind.Local).AddTicks(2106)
                        },
                        new
                        {
                            Id = 7,
                            AppointmentTypeId = 2,
                            DiseasId = 3,
                            DoctorId = 3,
                            EndTime = new DateTime(2024, 12, 4, 2, 15, 15, 260, DateTimeKind.Local).AddTicks(2142),
                            PatientId = 4,
                            Reason = "Eum impedit sapiente corrupti quisquam assumenda cumque.",
                            StartTime = new DateTime(2024, 12, 4, 1, 9, 15, 260, DateTimeKind.Local).AddTicks(2142)
                        },
                        new
                        {
                            Id = 8,
                            AppointmentTypeId = 3,
                            DiseasId = 3,
                            DoctorId = 1,
                            EndTime = new DateTime(2024, 12, 2, 14, 31, 15, 260, DateTimeKind.Local).AddTicks(2240),
                            PatientId = 4,
                            Reason = "Aut est ut consectetur et minima incidunt repudiandae earum.",
                            StartTime = new DateTime(2024, 12, 2, 13, 23, 15, 260, DateTimeKind.Local).AddTicks(2240)
                        },
                        new
                        {
                            Id = 9,
                            AppointmentTypeId = 3,
                            DiseasId = 3,
                            DoctorId = 3,
                            EndTime = new DateTime(2024, 11, 28, 4, 45, 15, 260, DateTimeKind.Local).AddTicks(2276),
                            PatientId = 1,
                            Reason = "Dolorem ab non eos praesentium corrupti impedit perferendis vel.",
                            StartTime = new DateTime(2024, 11, 28, 3, 24, 15, 260, DateTimeKind.Local).AddTicks(2276)
                        },
                        new
                        {
                            Id = 10,
                            AppointmentTypeId = 3,
                            DiseasId = 4,
                            DoctorId = 1,
                            EndTime = new DateTime(2024, 12, 1, 1, 28, 15, 260, DateTimeKind.Local).AddTicks(2310),
                            PatientId = 1,
                            Reason = "Error at et rerum aliquid et consequatur animi.",
                            StartTime = new DateTime(2024, 11, 30, 23, 48, 15, 260, DateTimeKind.Local).AddTicks(2310)
                        });
                });

            modelBuilder.Entity("EmployAssesmentCSharp.Models.AppointmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("AppointmentType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Consequatur velit quis dolor et.",
                            Name = "Chequeo Preventivo"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Aperiam natus temporibus similique.",
                            Name = "Consulta General"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Amet quam voluptatem cumque recusandae.",
                            Name = "Chequeo Preventivo"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Impedit architecto quasi rerum aut quae.",
                            Name = "Chequeo Preventivo"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Repellat quas placeat ea eos fuga omnis illum quisquam.",
                            Name = "Consulta General"
                        });
                });

            modelBuilder.Entity("EmployAssesmentCSharp.Models.Diseas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Diseases");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Sit tenetur quod dolorum sunt cupiditate magnam eveniet itaque.",
                            Name = "EPOC"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Dolor explicabo cum dolores aliquid rerum veritatis aut qui officia.",
                            Name = "Diabetes"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Quo quas autem.",
                            Name = "Neumonía"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Consequuntur inventore praesentium adipisci impedit quia atque dicta.",
                            Name = "Artritis"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Error dolorem aspernatur deserunt.",
                            Name = "Gripe"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Facilis est omnis consequuntur aut.",
                            Name = "Insuficiencia Renal"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Et similique aut cum exercitationem.",
                            Name = "Cáncer"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Inventore facere asperiores sit aliquam nihil quia aperiam consectetur enim.",
                            Name = "Asma"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Porro non consequatur velit temporibus.",
                            Name = "EPOC"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Nostrum asperiores quas molestiae.",
                            Name = "Gripe"
                        });
                });

            modelBuilder.Entity("EmployAssesmentCSharp.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time")
                        .HasColumnName("end_time");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("identification_number");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("specialty");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time")
                        .HasColumnName("start_time");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Branson83@yahoo.com",
                            EndTime = new TimeSpan(0, 16, 0, 0, 0),
                            IdentificationNumber = "2895019",
                            Name = "Noelia Spencer",
                            Password = "ULVTHy0ZPQ",
                            Specialty = "Cardiology",
                            StartTime = new TimeSpan(0, 12, 0, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            Email = "Trever_Ruecker12@gmail.com",
                            EndTime = new TimeSpan(0, 13, 0, 0, 0),
                            IdentificationNumber = "2512693",
                            Name = "Lavinia Cronin",
                            Password = "9mgZlIj6AO",
                            Specialty = "General Surgery",
                            StartTime = new TimeSpan(0, 9, 0, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            Email = "Tyreek_Balistreri47@gmail.com",
                            EndTime = new TimeSpan(0, 17, 0, 0, 0),
                            IdentificationNumber = "4416555",
                            Name = "Assunta Lindgren",
                            Password = "8XJJfeqNGg",
                            Specialty = "Neurology",
                            StartTime = new TimeSpan(0, 9, 0, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            Email = "Clemmie_Harber76@hotmail.com",
                            EndTime = new TimeSpan(0, 13, 0, 0, 0),
                            IdentificationNumber = "5404316",
                            Name = "Gust Grant",
                            Password = "AhkMN112WY",
                            Specialty = "Cardiology",
                            StartTime = new TimeSpan(0, 9, 0, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            Email = "Dangelo_Lueilwitz@hotmail.com",
                            EndTime = new TimeSpan(0, 17, 0, 0, 0),
                            IdentificationNumber = "8980260",
                            Name = "Maya Ryan",
                            Password = "NPXaeLZ1Oj",
                            Specialty = "Orthopedics",
                            StartTime = new TimeSpan(0, 10, 0, 0, 0)
                        },
                        new
                        {
                            Id = 6,
                            Email = "Nicola.Larson96@yahoo.com",
                            EndTime = new TimeSpan(0, 15, 0, 0, 0),
                            IdentificationNumber = "4572758",
                            Name = "Jarret Huels",
                            Password = "8LqMH7T6s9",
                            Specialty = "Orthopedics",
                            StartTime = new TimeSpan(0, 8, 0, 0, 0)
                        },
                        new
                        {
                            Id = 7,
                            Email = "Ada.Heller94@hotmail.com",
                            EndTime = new TimeSpan(0, 13, 0, 0, 0),
                            IdentificationNumber = "2010250",
                            Name = "Waylon O'Keefe",
                            Password = "8IFjySoNB1",
                            Specialty = "Neurology",
                            StartTime = new TimeSpan(0, 9, 0, 0, 0)
                        },
                        new
                        {
                            Id = 8,
                            Email = "Jacques.Cormier@gmail.com",
                            EndTime = new TimeSpan(0, 14, 0, 0, 0),
                            IdentificationNumber = "8792763",
                            Name = "Quinten Bogan",
                            Password = "3WKYzrYKZn",
                            Specialty = "Neurology",
                            StartTime = new TimeSpan(0, 10, 0, 0, 0)
                        },
                        new
                        {
                            Id = 9,
                            Email = "Karlie_Wisozk98@hotmail.com",
                            EndTime = new TimeSpan(0, 17, 0, 0, 0),
                            IdentificationNumber = "8122699",
                            Name = "Howell Prosacco",
                            Password = "SW1dFpW8f9",
                            Specialty = "General Surgery",
                            StartTime = new TimeSpan(0, 9, 0, 0, 0)
                        },
                        new
                        {
                            Id = 10,
                            Email = "Jeromy.Legros58@gmail.com",
                            EndTime = new TimeSpan(0, 16, 0, 0, 0),
                            IdentificationNumber = "7469628",
                            Name = "Madonna Roob",
                            Password = "fei5BN3wx6",
                            Specialty = "General Surgery",
                            StartTime = new TimeSpan(0, 8, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("EmployAssesmentCSharp.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("identification_number");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Ruthie41@yahoo.com",
                            IdentificationNumber = "9544179",
                            Name = "Rigoberto McGlynn",
                            Password = "EdVDoBUknv"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Daisha_Stanton30@gmail.com",
                            IdentificationNumber = "7846039",
                            Name = "Charlie Wolf",
                            Password = "0yybUcOYZw"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Carolanne_Schultz39@hotmail.com",
                            IdentificationNumber = "1315007",
                            Name = "Reggie Mraz",
                            Password = "JZqXMpwZkh"
                        },
                        new
                        {
                            Id = 4,
                            Email = "Carole12@yahoo.com",
                            IdentificationNumber = "8739325",
                            Name = "Giovanni Gusikowski",
                            Password = "u8WL4aCQqt"
                        },
                        new
                        {
                            Id = 5,
                            Email = "Hilario6@hotmail.com",
                            IdentificationNumber = "5759409",
                            Name = "Joel Watsica",
                            Password = "26Iuv7BWah"
                        },
                        new
                        {
                            Id = 6,
                            Email = "Drake_Jacobs@hotmail.com",
                            IdentificationNumber = "3157891",
                            Name = "Felipe Abbott",
                            Password = "DN0otwkcSX"
                        },
                        new
                        {
                            Id = 7,
                            Email = "Genesis_Hansen@gmail.com",
                            IdentificationNumber = "5435463",
                            Name = "Forrest Abernathy",
                            Password = "G7EO2UcQ3j"
                        },
                        new
                        {
                            Id = 8,
                            Email = "Ferne.Bernier61@yahoo.com",
                            IdentificationNumber = "8546769",
                            Name = "Aditya Stanton",
                            Password = "jXvwCNOm97"
                        },
                        new
                        {
                            Id = 9,
                            Email = "Sabrina11@hotmail.com",
                            IdentificationNumber = "8776299",
                            Name = "Hank Runolfsson",
                            Password = "DpWHurmv8X"
                        },
                        new
                        {
                            Id = 10,
                            Email = "Esperanza.Kunde38@gmail.com",
                            IdentificationNumber = "6165654",
                            Name = "Jackson Hyatt",
                            Password = "Z9bMqk2Bo_"
                        });
                });

            modelBuilder.Entity("EmployAssesmentCSharp.Models.Appointment", b =>
                {
                    b.HasOne("EmployAssesmentCSharp.Models.AppointmentType", "AppointmentType")
                        .WithMany()
                        .HasForeignKey("AppointmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployAssesmentCSharp.Models.Diseas", "Diseas")
                        .WithMany()
                        .HasForeignKey("DiseasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployAssesmentCSharp.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployAssesmentCSharp.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentType");

                    b.Navigation("Diseas");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });
#pragma warning restore 612, 618
        }
    }
}
