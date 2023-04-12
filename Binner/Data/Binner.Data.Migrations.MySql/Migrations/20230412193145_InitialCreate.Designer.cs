﻿// <auto-generated />
using System;
using Binner.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Binner.Data.Migrations.MySql.Migrations
{
    [DbContext(typeof(BinnerContext))]
    [Migration("20230412193145_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Binner.Data.Model.OAuthCredential", b =>
                {
                    b.Property<string>("Provider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("AccessToken")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreatedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateExpiresUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Provider");

                    b.ToTable("OAuthCredentials", "dbo");
                });

            modelBuilder.Entity("Binner.Data.Model.OAuthRequest", b =>
                {
                    b.Property<int>("OAuthRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AuthorizationCode")
                        .HasColumnType("longtext");

                    b.Property<bool>("AuthorizationReceived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("DateCreatedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModifiedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Error")
                        .HasColumnType("longtext");

                    b.Property<string>("ErrorDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ReturnToUrl")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OAuthRequestId");

                    b.ToTable("OAuthRequests", "dbo");
                });

            modelBuilder.Entity("Binner.Data.Model.Part", b =>
                {
                    b.Property<long>("PartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("ArrowPartNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("BinNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BinNumber2")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Currency")
                        .HasColumnType("longtext");

                    b.Property<string>("DatasheetUrl")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreatedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DigiKeyPartNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Keywords")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Location")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("LowStockThreshold")
                        .HasColumnType("int");

                    b.Property<string>("LowestCostSupplier")
                        .HasColumnType("longtext");

                    b.Property<string>("LowestCostSupplierUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ManufacturerPartNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("MountingTypeId")
                        .HasColumnType("int");

                    b.Property<string>("MouserPartNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PackageType")
                        .HasColumnType("longtext");

                    b.Property<string>("PartNumber")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<long>("PartTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductUrl")
                        .HasColumnType("longtext");

                    b.Property<long?>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PartId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("BinNumber", "UserId");

                    b.HasIndex("BinNumber2", "UserId");

                    b.HasIndex("Description", "UserId");

                    b.HasIndex("DigiKeyPartNumber", "UserId");

                    b.HasIndex("Keywords", "UserId");

                    b.HasIndex("Location", "UserId");

                    b.HasIndex("Manufacturer", "UserId");

                    b.HasIndex("ManufacturerPartNumber", "UserId");

                    b.HasIndex("MouserPartNumber", "UserId");

                    b.HasIndex("PartNumber", "UserId");

                    b.HasIndex("PartTypeId", "UserId");

                    b.ToTable("Parts", "dbo");
                });

            modelBuilder.Entity("Binner.Data.Model.PartSupplier", b =>
                {
                    b.Property<long>("PartSupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("DateCreatedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModifiedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<int>("MinimumOrderQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<long>("PartId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductUrl")
                        .HasColumnType("longtext");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("int");

                    b.Property<string>("SupplierPartNumber")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PartSupplierId");

                    b.HasIndex("PartId");

                    b.ToTable("PartSuppliers", "dbo");
                });

            modelBuilder.Entity("Binner.Data.Model.PartType", b =>
                {
                    b.Property<long>("PartTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreatedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<long?>("ParentPartTypeId")
                        .HasColumnType("bigint");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PartTypeId");

                    b.HasIndex("ParentPartTypeId");

                    b.HasIndex("Name", "UserId");

                    b.ToTable("PartTypes", "dbo");
                });

            modelBuilder.Entity("Binner.Data.Model.Pcb", b =>
                {
                    b.Property<long>("PcbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<DateTime>("DateCreatedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModifiedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("LastSerialNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumberFormat")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PcbId");

                    b.ToTable("Pcbs", "dbo");
                });

            modelBuilder.Entity("Binner.Data.Model.PcbStoredFileAssignment", b =>
                {
                    b.Property<long>("PcbStoredFileAssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreatedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModifiedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext");

                    b.Property<long>("PcbId")
                        .HasColumnType("bigint");

                    b.Property<long>("StoredFileId")
                        .HasColumnType("bigint");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PcbStoredFileAssignmentId");

                    b.HasIndex("PcbId");

                    b.HasIndex("StoredFileId");

                    b.ToTable("PcbStoredFileAssignments", "dbo");
                });

            modelBuilder.Entity("Binner.Data.Model.Project", b =>
                {
                    b.Property<long>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreatedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModifiedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("Name", "UserId");

                    b.ToTable("Projects", "dbo");
                });

            modelBuilder.Entity("Binner.Data.Model.ProjectPartAssignment", b =>
                {
                    b.Property<long>("ProjectPartAssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<string>("Currency")
                        .HasColumnType("longtext");

                    b.Property<string>("CustomDescription")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreatedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModifiedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext");

                    b.Property<long?>("PartId")
                        .HasColumnType("bigint");

                    b.Property<string>("PartName")
                        .HasColumnType("longtext");

                    b.Property<long?>("PcbId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceId")
                        .HasColumnType("longtext");

                    b.Property<string>("SchematicReferenceId")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectPartAssignmentId");

                    b.HasIndex("PartId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectPartAssignments", "dbo");
                });

            modelBuilder.Entity("Binner.Data.Model.ProjectPcbAssignment", b =>
                {
                    b.Property<long>("ProjectPcbAssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreatedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<long>("PcbId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectPcbAssignmentId");

                    b.HasIndex("PcbId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectPcbAssignments", "dbo");
                });

            modelBuilder.Entity("Binner.Data.Model.StoredFile", b =>
                {
                    b.Property<long>("StoredFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Crc32")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreatedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int>("FileLength")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OriginalFileName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("PartId")
                        .HasColumnType("bigint");

                    b.Property<int>("StoredFileType")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("StoredFileId");

                    b.HasIndex("PartId");

                    b.ToTable("StoredFiles", "dbo");
                });

            modelBuilder.Entity("Binner.Data.Model.Part", b =>
                {
                    b.HasOne("Binner.Data.Model.PartType", "PartType")
                        .WithMany("Parts")
                        .HasForeignKey("PartTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Binner.Data.Model.Project", "Project")
                        .WithMany("Parts")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("PartType");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Binner.Data.Model.PartSupplier", b =>
                {
                    b.HasOne("Binner.Data.Model.Part", "Part")
                        .WithMany("PartSuppliers")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Part");
                });

            modelBuilder.Entity("Binner.Data.Model.PartType", b =>
                {
                    b.HasOne("Binner.Data.Model.PartType", "ParentPartType")
                        .WithMany()
                        .HasForeignKey("ParentPartTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentPartType");
                });

            modelBuilder.Entity("Binner.Data.Model.PcbStoredFileAssignment", b =>
                {
                    b.HasOne("Binner.Data.Model.Pcb", "Pcb")
                        .WithMany("PcbStoredFileAssignments")
                        .HasForeignKey("PcbId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Binner.Data.Model.StoredFile", "StoredFile")
                        .WithMany("PcbStoredFileAssignments")
                        .HasForeignKey("StoredFileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pcb");

                    b.Navigation("StoredFile");
                });

            modelBuilder.Entity("Binner.Data.Model.ProjectPartAssignment", b =>
                {
                    b.HasOne("Binner.Data.Model.Part", "Part")
                        .WithMany("ProjectPartAssignments")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Binner.Data.Model.Project", "Project")
                        .WithMany("ProjectPartAssignments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Part");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Binner.Data.Model.ProjectPcbAssignment", b =>
                {
                    b.HasOne("Binner.Data.Model.Pcb", "Pcb")
                        .WithMany("ProjectPcbAssignments")
                        .HasForeignKey("PcbId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Binner.Data.Model.Project", "Project")
                        .WithMany("ProjectPcbAssignments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pcb");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Binner.Data.Model.StoredFile", b =>
                {
                    b.HasOne("Binner.Data.Model.Part", "Part")
                        .WithMany("StoredFiles")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Part");
                });

            modelBuilder.Entity("Binner.Data.Model.Part", b =>
                {
                    b.Navigation("PartSuppliers");

                    b.Navigation("ProjectPartAssignments");

                    b.Navigation("StoredFiles");
                });

            modelBuilder.Entity("Binner.Data.Model.PartType", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("Binner.Data.Model.Pcb", b =>
                {
                    b.Navigation("PcbStoredFileAssignments");

                    b.Navigation("ProjectPcbAssignments");
                });

            modelBuilder.Entity("Binner.Data.Model.Project", b =>
                {
                    b.Navigation("Parts");

                    b.Navigation("ProjectPartAssignments");

                    b.Navigation("ProjectPcbAssignments");
                });

            modelBuilder.Entity("Binner.Data.Model.StoredFile", b =>
                {
                    b.Navigation("PcbStoredFileAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
