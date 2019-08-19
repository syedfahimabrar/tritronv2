﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tritronAPI.Data;

namespace tritronAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("tritronAPI.Model.Contest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackgroundImage");

                    b.Property<int>("ContestType");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.ToTable("Contests");
                });

            modelBuilder.Entity("tritronAPI.Model.Language", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Extension");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("tritronAPI.Model.Problem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName");

                    b.Property<int?>("Contest_Id");

                    b.Property<bool>("IsPublished");

                    b.Property<int>("MemoryLimit");

                    b.Property<string>("ProblemAuthorId");

                    b.Property<string>("ProblemDescription");

                    b.Property<string>("ProblemName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<short>("Score");

                    b.Property<int?>("SourceCodeLimit");

                    b.Property<string>("Tags");

                    b.Property<int>("TimeLimit");

                    b.HasKey("Id");

                    b.HasIndex("Contest_Id");

                    b.HasIndex("ProblemAuthorId");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("tritronAPI.Model.ProblemLanguage", b =>
                {
                    b.Property<int>("ProblemId");

                    b.Property<int>("LanguageId");

                    b.Property<string>("LanguageId1");

                    b.HasKey("ProblemId", "LanguageId");

                    b.HasIndex("LanguageId1");

                    b.ToTable("ProblemLanguages");
                });

            modelBuilder.Entity("tritronAPI.Model.Submission", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.Property<string>("Language");

                    b.Property<int?>("ProblemId");

                    b.Property<int>("Problem_Id");

                    b.Property<string>("User_Id");

                    b.HasKey("Id");

                    b.HasIndex("ProblemId");

                    b.HasIndex("User_Id");

                    b.ToTable("Submission");
                });

            modelBuilder.Entity("tritronAPI.Model.TestFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("InputData");

                    b.Property<byte[]>("OutputData");

                    b.Property<int>("Problem_Id");

                    b.HasKey("Id");

                    b.HasIndex("Problem_Id");

                    b.ToTable("TestFile");
                });

            modelBuilder.Entity("tritronAPI.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePicUrl");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("tritronAPI.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("tritronAPI.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("tritronAPI.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("tritronAPI.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("tritronAPI.Model.Problem", b =>
                {
                    b.HasOne("tritronAPI.Model.Contest", "Contest")
                        .WithMany("Problems")
                        .HasForeignKey("Contest_Id");

                    b.HasOne("tritronAPI.Model.User", "ProblemAuthor")
                        .WithMany()
                        .HasForeignKey("ProblemAuthorId");
                });

            modelBuilder.Entity("tritronAPI.Model.ProblemLanguage", b =>
                {
                    b.HasOne("tritronAPI.Model.Language", "Language")
                        .WithMany("ProblemLanguages")
                        .HasForeignKey("LanguageId1");

                    b.HasOne("tritronAPI.Model.Problem", "Problem")
                        .WithMany("ProblemLanguages")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("tritronAPI.Model.Submission", b =>
                {
                    b.HasOne("tritronAPI.Model.Problem", "Problem")
                        .WithMany("Submissions")
                        .HasForeignKey("ProblemId");

                    b.HasOne("tritronAPI.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id");
                });

            modelBuilder.Entity("tritronAPI.Model.TestFile", b =>
                {
                    b.HasOne("tritronAPI.Model.Problem", "Problem")
                        .WithMany("TestFiles")
                        .HasForeignKey("Problem_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
