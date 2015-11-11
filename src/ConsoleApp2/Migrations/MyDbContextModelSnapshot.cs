using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ConsoleApp2;

namespace ConsoleApp2.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta8-15964")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleApp2.Model.ChildA", b =>
                {
                    b.Property<int>("ChildAId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data");

                    b.HasKey("ChildAId");
                });

            modelBuilder.Entity("ConsoleApp2.Model.Parent", b =>
                {
                    b.Property<int>("ParentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChildAChildAId");

                    b.Property<string>("Data");

                    b.HasKey("ParentId");
                });

            modelBuilder.Entity("ConsoleApp2.Model.Parent", b =>
                {
                    b.HasOne("ConsoleApp2.Model.ChildA")
                        .WithMany()
                        .ForeignKey("ChildAChildAId");
                });
        }
    }
}
