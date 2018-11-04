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
    [Migration("20181104234635_MinorFix")]
    partial class MinorFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NetHub.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("Age")
                        .HasColumnName("age");

                    b.Property<string>("CustName")
                        .HasColumnName("cust_name");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnName("expire_date");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnName("join_date");

                    b.Property<int>("PayStatus")
                        .HasColumnName("pay_status");

                    b.HasKey("ID")
                        .HasName("pk_accounts");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("NetHub.Models.Actor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnName("birthdate");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name");

                    b.HasKey("ID")
                        .HasName("pk_actors");

                    b.ToTable("actors");
                });

            modelBuilder.Entity("NetHub.Models.Director", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnName("birthdate");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name");

                    b.HasKey("ID")
                        .HasName("pk_directors");

                    b.ToTable("directors");
                });

            modelBuilder.Entity("NetHub.Models.Episode", b =>
                {
                    b.Property<int>("EpisodeID")
                        .HasColumnName("episode_id");

                    b.Property<int>("EpisodeNum")
                        .HasColumnName("episode_num");

                    b.Property<int>("SeasonID")
                        .HasColumnName("season_id");

                    b.Property<int?>("SeriesID")
                        .HasColumnName("series_id");

                    b.HasKey("EpisodeID")
                        .HasName("pk_episodes");

                    b.HasIndex("SeasonID")
                        .HasName("ix_episodes_season_id");

                    b.HasIndex("SeriesID")
                        .HasName("ix_episodes_series_id");

                    b.ToTable("episodes");
                });

            modelBuilder.Entity("NetHub.Models.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_genres");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("NetHub.Models.History", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("AccountID")
                        .HasColumnName("account_id");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date");

                    b.Property<int>("MediumID")
                        .HasColumnName("medium_id");

                    b.Property<int>("Rating")
                        .HasColumnName("rating");

                    b.HasKey("ID")
                        .HasName("pk_history");

                    b.HasIndex("AccountID")
                        .HasName("ix_history_account_id");

                    b.HasIndex("MediumID")
                        .HasName("ix_history_medium_id");

                    b.ToTable("history");
                });

            modelBuilder.Entity("NetHub.Models.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_languages");

                    b.ToTable("languages");
                });

            modelBuilder.Entity("NetHub.Models.MediaDirector", b =>
                {
                    b.Property<int>("MediaID")
                        .HasColumnName("media_id");

                    b.Property<int>("DirectorID")
                        .HasColumnName("director_id");

                    b.Property<int?>("MediumID")
                        .HasColumnName("medium_id");

                    b.HasKey("MediaID", "DirectorID");

                    b.HasIndex("DirectorID")
                        .HasName("ix_media_directors_director_id");

                    b.HasIndex("MediumID")
                        .HasName("ix_media_directors_medium_id");

                    b.ToTable("media_directors");
                });

            modelBuilder.Entity("NetHub.Models.Medium", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<int>("Runtime")
                        .HasColumnName("runtime");

                    b.Property<string>("Title")
                        .HasColumnName("title");

                    b.HasKey("ID")
                        .HasName("pk_media");

                    b.ToTable("media");
                });

            modelBuilder.Entity("NetHub.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .HasColumnName("movie_id");

                    b.Property<string>("ImgPath")
                        .HasColumnName("img_path");

                    b.Property<int>("RatingID")
                        .HasColumnName("rating_id");

                    b.Property<int>("Year")
                        .HasColumnName("year");

                    b.HasKey("MovieID")
                        .HasName("pk_movies");

                    b.HasIndex("RatingID")
                        .HasName("ix_movies_rating_id");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("NetHub.Models.MovieActor", b =>
                {
                    b.Property<int>("MovieID")
                        .HasColumnName("movie_id");

                    b.Property<int>("ActorID")
                        .HasColumnName("actor_id");

                    b.HasKey("MovieID", "ActorID");

                    b.HasIndex("ActorID")
                        .HasName("ix_movies_actors_actor_id");

                    b.ToTable("movies_actors");
                });

            modelBuilder.Entity("NetHub.Models.MovieCaptioning", b =>
                {
                    b.Property<int>("MovieID")
                        .HasColumnName("movie_id");

                    b.Property<int>("LanguageID")
                        .HasColumnName("language_id");

                    b.HasKey("MovieID", "LanguageID");

                    b.HasIndex("LanguageID")
                        .HasName("ix_movies_captions_language_id");

                    b.ToTable("movies_captions");
                });

            modelBuilder.Entity("NetHub.Models.MovieGenre", b =>
                {
                    b.Property<int>("MovieID")
                        .HasColumnName("movie_id");

                    b.Property<int>("GenreID")
                        .HasColumnName("genre_id");

                    b.HasKey("MovieID", "GenreID");

                    b.HasIndex("GenreID")
                        .HasName("ix_movies_genres_genre_id");

                    b.ToTable("movies_genres");
                });

            modelBuilder.Entity("NetHub.Models.MovieLanguage", b =>
                {
                    b.Property<int>("MovieID")
                        .HasColumnName("movie_id");

                    b.Property<int>("LanguageID")
                        .HasColumnName("language_id");

                    b.HasKey("MovieID", "LanguageID");

                    b.HasIndex("LanguageID")
                        .HasName("ix_movies_languages_language_id");

                    b.ToTable("movies_languages");
                });

            modelBuilder.Entity("NetHub.Models.MovieProdcompany", b =>
                {
                    b.Property<int>("MovieID")
                        .HasColumnName("movie_id");

                    b.Property<int>("ProdCompanyID")
                        .HasColumnName("prod_company_id");

                    b.HasKey("MovieID", "ProdCompanyID");

                    b.HasIndex("ProdCompanyID")
                        .HasName("ix_movies_prodcompanies_prod_company_id");

                    b.ToTable("movies_prodcompanies");
                });

            modelBuilder.Entity("NetHub.Models.ProdCompany", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_prod_companies");

                    b.ToTable("prod_companies");
                });

            modelBuilder.Entity("NetHub.Models.Rating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("AgeLimit")
                        .HasColumnName("age_limit");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_ratings");

                    b.ToTable("ratings");
                });

            modelBuilder.Entity("NetHub.Models.Season", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("SeriesID")
                        .HasColumnName("series_id");

                    b.HasKey("ID")
                        .HasName("pk_seasons");

                    b.HasIndex("SeriesID")
                        .HasName("ix_seasons_series_id");

                    b.ToTable("seasons");
                });

            modelBuilder.Entity("NetHub.Models.Series", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<string>("ImgPath")
                        .HasColumnName("img_path");

                    b.Property<int>("RatingID")
                        .HasColumnName("rating_id");

                    b.Property<string>("Title")
                        .HasColumnName("title");

                    b.Property<int>("Year")
                        .HasColumnName("year");

                    b.HasKey("ID")
                        .HasName("pk_series");

                    b.HasIndex("RatingID")
                        .HasName("ix_series_rating_id");

                    b.ToTable("series");
                });

            modelBuilder.Entity("NetHub.Models.SeriesActor", b =>
                {
                    b.Property<int>("SeriesID")
                        .HasColumnName("series_id");

                    b.Property<int>("ActorID")
                        .HasColumnName("actor_id");

                    b.HasKey("SeriesID", "ActorID");

                    b.HasIndex("ActorID")
                        .HasName("ix_series_actors_actor_id");

                    b.ToTable("series_actors");
                });

            modelBuilder.Entity("NetHub.Models.SeriesCaptioning", b =>
                {
                    b.Property<int>("SeriesID")
                        .HasColumnName("series_id");

                    b.Property<int>("LanguageID")
                        .HasColumnName("language_id");

                    b.HasKey("SeriesID", "LanguageID");

                    b.HasIndex("LanguageID")
                        .HasName("ix_series_captions_language_id");

                    b.ToTable("series_captions");
                });

            modelBuilder.Entity("NetHub.Models.SeriesGenre", b =>
                {
                    b.Property<int>("SeriesID")
                        .HasColumnName("series_id");

                    b.Property<int>("GenreID")
                        .HasColumnName("genre_id");

                    b.HasKey("SeriesID", "GenreID");

                    b.HasIndex("GenreID")
                        .HasName("ix_series_genres_genre_id");

                    b.ToTable("series_genres");
                });

            modelBuilder.Entity("NetHub.Models.SeriesLanguage", b =>
                {
                    b.Property<int>("SeriesID")
                        .HasColumnName("series_id");

                    b.Property<int>("LanguageID")
                        .HasColumnName("language_id");

                    b.HasKey("SeriesID", "LanguageID");

                    b.HasIndex("LanguageID")
                        .HasName("ix_series_languages_language_id");

                    b.ToTable("series_languages");
                });

            modelBuilder.Entity("NetHub.Models.SeriesProdcompany", b =>
                {
                    b.Property<int>("SeriesID")
                        .HasColumnName("series_id");

                    b.Property<int>("ProdCompanyID")
                        .HasColumnName("prod_company_id");

                    b.HasKey("SeriesID", "ProdCompanyID");

                    b.HasIndex("ProdCompanyID")
                        .HasName("ix_series_prodcompanies_prod_company_id");

                    b.ToTable("series_prodcompanies");
                });

            modelBuilder.Entity("NetHub.Models.Episode", b =>
                {
                    b.HasOne("NetHub.Models.Medium", "Medium")
                        .WithMany()
                        .HasForeignKey("EpisodeID")
                        .HasConstraintName("fk_episodes_media_episode_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Season", "Season")
                        .WithMany("Episodes")
                        .HasForeignKey("SeasonID")
                        .HasConstraintName("fk_episodes_seasons_season_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Series")
                        .WithMany("Episodes")
                        .HasForeignKey("SeriesID")
                        .HasConstraintName("fk_episodes_series_series_id");
                });

            modelBuilder.Entity("NetHub.Models.History", b =>
                {
                    b.HasOne("NetHub.Models.Account", "Customer")
                        .WithMany("History")
                        .HasForeignKey("AccountID")
                        .HasConstraintName("fk_history_accounts_account_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Medium", "Medium")
                        .WithMany("History")
                        .HasForeignKey("MediumID")
                        .HasConstraintName("fk_history_media_medium_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.MediaDirector", b =>
                {
                    b.HasOne("NetHub.Models.Director", "Director")
                        .WithMany("MediaDirectors")
                        .HasForeignKey("DirectorID")
                        .HasConstraintName("fk_media_directors_directors_director_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Medium", "Medium")
                        .WithMany("MediaDirectors")
                        .HasForeignKey("MediumID")
                        .HasConstraintName("fk_media_directors_media_medium_id");
                });

            modelBuilder.Entity("NetHub.Models.Movie", b =>
                {
                    b.HasOne("NetHub.Models.Medium", "Medium")
                        .WithMany()
                        .HasForeignKey("MovieID")
                        .HasConstraintName("fk_movies_media_movie_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingID")
                        .HasConstraintName("fk_movies_ratings_rating_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.MovieActor", b =>
                {
                    b.HasOne("NetHub.Models.Actor", "Actor")
                        .WithMany("MoviesActors")
                        .HasForeignKey("ActorID")
                        .HasConstraintName("fk_movies_actors_actors_actor_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Movie", "Movie")
                        .WithMany("MoviesActors")
                        .HasForeignKey("MovieID")
                        .HasConstraintName("fk_movies_actors_movies_movie_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.MovieCaptioning", b =>
                {
                    b.HasOne("NetHub.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .HasConstraintName("fk_movies_captions_languages_language_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Movie", "Movie")
                        .WithMany("MoviesCaptionings")
                        .HasForeignKey("MovieID")
                        .HasConstraintName("fk_movies_captions_movies_movie_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.MovieGenre", b =>
                {
                    b.HasOne("NetHub.Models.Genre", "Genre")
                        .WithMany("MoviesGenres")
                        .HasForeignKey("GenreID")
                        .HasConstraintName("fk_movies_genres_genres_genre_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Movie", "Movie")
                        .WithMany("MoviesGenres")
                        .HasForeignKey("MovieID")
                        .HasConstraintName("fk_movies_genres_movies_movie_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.MovieLanguage", b =>
                {
                    b.HasOne("NetHub.Models.Language", "Language")
                        .WithMany("MoviesLanguages")
                        .HasForeignKey("LanguageID")
                        .HasConstraintName("fk_movies_languages_languages_language_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Movie", "Movie")
                        .WithMany("MoviesLanguages")
                        .HasForeignKey("MovieID")
                        .HasConstraintName("fk_movies_languages_movies_movie_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.MovieProdcompany", b =>
                {
                    b.HasOne("NetHub.Models.Movie", "Movie")
                        .WithMany("MoviesProdCompanies")
                        .HasForeignKey("MovieID")
                        .HasConstraintName("fk_movies_prodcompanies_movies_movie_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.ProdCompany", "ProdCompany")
                        .WithMany("MoviesProdcompanies")
                        .HasForeignKey("ProdCompanyID")
                        .HasConstraintName("fk_movies_prodcompanies_prod_companies_prod_company_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.Season", b =>
                {
                    b.HasOne("NetHub.Models.Series", "Series")
                        .WithMany("Seasons")
                        .HasForeignKey("SeriesID")
                        .HasConstraintName("fk_seasons_series_series_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.Series", b =>
                {
                    b.HasOne("NetHub.Models.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingID")
                        .HasConstraintName("fk_series_ratings_rating_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.SeriesActor", b =>
                {
                    b.HasOne("NetHub.Models.Actor", "Actor")
                        .WithMany("SeriesActors")
                        .HasForeignKey("ActorID")
                        .HasConstraintName("fk_series_actors_actors_actor_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Series", "Series")
                        .WithMany("SeriesActors")
                        .HasForeignKey("SeriesID")
                        .HasConstraintName("fk_series_actors_series_series_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.SeriesCaptioning", b =>
                {
                    b.HasOne("NetHub.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .HasConstraintName("fk_series_captions_languages_language_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Series", "Series")
                        .WithMany("SeriesCaptionings")
                        .HasForeignKey("SeriesID")
                        .HasConstraintName("fk_series_captions_series_series_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.SeriesGenre", b =>
                {
                    b.HasOne("NetHub.Models.Genre", "Genre")
                        .WithMany("SeriesGenres")
                        .HasForeignKey("GenreID")
                        .HasConstraintName("fk_series_genres_genres_genre_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Series", "Series")
                        .WithMany("SeriesGenres")
                        .HasForeignKey("SeriesID")
                        .HasConstraintName("fk_series_genres_series_series_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.SeriesLanguage", b =>
                {
                    b.HasOne("NetHub.Models.Language", "Language")
                        .WithMany("SeriesLanguages")
                        .HasForeignKey("LanguageID")
                        .HasConstraintName("fk_series_languages_languages_language_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Series", "Series")
                        .WithMany("SeriesLanguages")
                        .HasForeignKey("SeriesID")
                        .HasConstraintName("fk_series_languages_series_series_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetHub.Models.SeriesProdcompany", b =>
                {
                    b.HasOne("NetHub.Models.ProdCompany", "ProdCompany")
                        .WithMany("SeriesProdcompanies")
                        .HasForeignKey("ProdCompanyID")
                        .HasConstraintName("fk_series_prodcompanies_prod_companies_prod_company_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NetHub.Models.Series", "Series")
                        .WithMany("SeriesProdCompanies")
                        .HasForeignKey("SeriesID")
                        .HasConstraintName("fk_series_prodcompanies_series_series_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
