﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sail.EntityFramework.DbContexts;

namespace Sail.Administration.Migrations.ConfigurationDb
{
    [DbContext(typeof(ConfigurationDbContext))]
    partial class ConfigurationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Sail.EntityFramework.Storage.Entities.AccessControl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BlackList")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ClientIpFlowLimit")
                        .HasColumnType("int");

                    b.Property<int>("OpenAuth")
                        .HasColumnType("int");

                    b.Property<int>("ServiceFlowLimit")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("WhiteHostName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("WhiteList")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("access_control");
                });

            modelBuilder.Entity("Sail.EntityFramework.Storage.Entities.GrpcRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("HeaderTransform")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("grpc_rule");
                });

            modelBuilder.Entity("Sail.EntityFramework.Storage.Entities.HttpRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("HeaderTransform")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("NeedHttps")
                        .HasColumnType("int");

                    b.Property<int>("NeedStripUri")
                        .HasColumnType("int");

                    b.Property<int>("NeedWebsocket")
                        .HasColumnType("int");

                    b.Property<string>("Rule")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("RuleType")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("UrlRewrite")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("http_rule");
                });

            modelBuilder.Entity("Sail.EntityFramework.Storage.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<int>("LoadType")
                        .HasColumnType("int");

                    b.Property<string>("ServiceDesc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ServiceName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("service");
                });

            modelBuilder.Entity("Sail.EntityFramework.Storage.Entities.TcpRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tcp_rule");
                });

            modelBuilder.Entity("Sail.EntityFramework.Storage.Entities.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Qpd")
                        .HasColumnType("int");

                    b.Property<int>("Qps")
                        .HasColumnType("int");

                    b.Property<string>("Secret")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("WhiteIps")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("tenant");
                });
#pragma warning restore 612, 618
        }
    }
}