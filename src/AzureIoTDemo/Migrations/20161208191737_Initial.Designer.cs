using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AzureIoTDemo.Data;

namespace AzureIoTDemo.Migrations
{
    [DbContext(typeof(TemperatureContext))]
    [Migration("20161208191737_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AzureIoTDemo.Models.TemperatureRead", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Place");

                    b.Property<float>("Value");

                    b.HasKey("ID");

                    b.ToTable("TemperatureReads");
                });
        }
    }
}
