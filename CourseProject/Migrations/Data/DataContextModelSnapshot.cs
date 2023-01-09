﻿// <auto-generated />
using CourseProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseProject.Migrations.Data
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CommentReview", b =>
                {
                    b.Property<long>("CommentsId")
                        .HasColumnType("bigint");

                    b.Property<long>("ReviewsId")
                        .HasColumnType("bigint");

                    b.HasKey("CommentsId", "ReviewsId");

                    b.HasIndex("ReviewsId");

                    b.ToTable("CommentReview");
                });

            modelBuilder.Entity("CourseProject.Models.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ReviewId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CourseProject.Models.LikedUsersId", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("ReviewId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.ToTable("LikedUsersId");
                });

            modelBuilder.Entity("CourseProject.Models.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LikesCount")
                        .HasColumnType("bigint");

                    b.Property<string>("RiviewName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StarsCount")
                        .HasColumnType("bigint");

                    b.Property<long>("StarsSum")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("CourseProject.Models.ReviewedUsersId", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("ReviewId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.ToTable("ReviewedUsersId");
                });

            modelBuilder.Entity("CourseProject.Models.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ReviewId")
                        .HasColumnType("bigint");

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("CommentReview", b =>
                {
                    b.HasOne("CourseProject.Models.Comment", null)
                        .WithMany()
                        .HasForeignKey("CommentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseProject.Models.Review", null)
                        .WithMany()
                        .HasForeignKey("ReviewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseProject.Models.LikedUsersId", b =>
                {
                    b.HasOne("CourseProject.Models.Review", "Review")
                        .WithMany("LikedUsersIds")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");
                });

            modelBuilder.Entity("CourseProject.Models.ReviewedUsersId", b =>
                {
                    b.HasOne("CourseProject.Models.Review", "Review")
                        .WithMany("ReviewedUsersIds")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");
                });

            modelBuilder.Entity("CourseProject.Models.Tag", b =>
                {
                    b.HasOne("CourseProject.Models.Review", "Review")
                        .WithMany("Tags")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");
                });

            modelBuilder.Entity("CourseProject.Models.Review", b =>
                {
                    b.Navigation("LikedUsersIds");

                    b.Navigation("ReviewedUsersIds");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}