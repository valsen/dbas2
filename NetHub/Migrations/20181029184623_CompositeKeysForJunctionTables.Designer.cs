﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetHub.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetHub.Migrations
{
    [DbContext(typeof(NetHubContext))]
    [Migration("20181029184623_CompositeKeysForJunctionTables")]
    partial class CompositeKeysForJunctionTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NetHub.Models.Actor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("NetHub.Models.ActsIn", b =>
                {
                    b.Property<int>("MovieID");

                    b.Property<int>("ActorID");

                    b.HasKey("MovieID", "ActorID");

                    b.HasIndex("ActorID");

                    b.ToTable("ActsIn");
                });

            modelBuilder.Entity("NetHub.Models.Director", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("NetHub.Models.DirectorOf", b =>
                {
                    b.Property<int>("MovieID");

                    b.Property<int>("DirectorID");

                    b.HasKey("MovieID", "DirectorID");

                    b.HasIndex("DirectorID");

                    b.ToTable("DirectorOf");
                });

            modelBuilder.Entity("NetHub.Models.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("NetHub.Models.GenreOf", b =>
                {
                    b.Property<int>("MovieID");

                    b.Property<int>("GenreID");

                    b.HasKey("MovieID", "GenreID");

                    b.HasIndex("GenreID");

                    b.ToTable("GenreOf");
                });

            modelBuilder.Entity("NetHub.Models.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("NetHub.Models.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImgPath");

                    b.Property<int>("Runtime");

                    b.Property<string>("Title");

                    b.Property<int>("Year");

                    b.HasKey("ID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("NetHub.Models.MovieHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountID");

                    b.Property<DateTime>("Date");

                    b.Property<int>("MovieID");

                    b.Property<int>("Rating");

                    b.HasKey("ID");

                    b.HasIndex("MovieID");

                    b.ToTable("MovieHistory");
                });

            modelBuilder.Entity("NetHub.Models.MovieLanguage", b =>
                {
                    b.Property<int>("MovieID");

                    b.Property<int>("LanguageID");

                    b.HasKey("MovieID", "LanguageID");

                    b.HasIndex("LanguageID");

                    b.ToTable("MovieLanguage");
                });

            modelBuilder.Entity("NetHub.Models.ProdCompany", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("ProdCompanies");
                });

            modelBuilder.Entity("NetHub.Models.ProdCompanyFor", b =>
                {
                    b.Property<int>("MovieID");

                    b.Property<int>("ProdCompanyID");

                    b.HasKey("MovieID", "ProdCompanyID");

                    b.HasIndex("ProdCompanyID");

                    b.ToTable("ProdCompanyFor");
                });

            modelBuilder.Entity("NetHub.Models.ActsIn", b =>
                {
                    b.HasOne("NetHub.Models.Actor", "Actor")
                        .WithMany("ActsIn")
                        .HasForeignKey("ActorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Movie", "Movie")
                        .WithMany("ActsIns")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.DirectorOf", b =>
                {
                    b.HasOne("NetHub.Models.Director", "Director")
                        .WithMany("DirectorOf")
                        .HasForeignKey("DirectorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Movie", "Movie")
                        .WithMany("DirectorOf")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.GenreOf", b =>
                {
                    b.HasOne("NetHub.Models.Genre", "Genre")
                        .WithMany("GenreOf")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Movie", "Movie")
                        .WithMany("GenreOf")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.MovieHistory", b =>
                {
                    b.HasOne("NetHub.Models.Movie", "Movie")
                        .WithMany("MovieHistory")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.MovieLanguage", b =>
                {
                    b.HasOne("NetHub.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Movie", "Movie")
                        .WithMany("MovieLanguages")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.ProdCompanyFor", b =>
                {
                    b.HasOne("NetHub.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.ProdCompany", "ProdCompany")
                        .WithMany("ProdCompanyFor")
                        .HasForeignKey("ProdCompanyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
