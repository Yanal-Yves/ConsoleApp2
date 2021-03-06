using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ConsoleApp2;

namespace ConsoleApp2.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20151111143606_Migration1")]
    partial class Migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("ConsoleApp2.Model.ChildB", b =>
                {
                    b.Property<int>("ChildBId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data");

                    b.Property<int?>("ParentParentId");

                    b.HasKey("ChildBId");
                });

            modelBuilder.Entity("ConsoleApp2.Model.Parent", b =>
                {
                    b.Property<int>("ParentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChildAChildAId");

                    b.Property<string>("Data");

                    b.HasKey("ParentId");
                });

            modelBuilder.Entity("ConsoleApp2.Model.ChildB", b =>
                {
                    b.HasOne("ConsoleApp2.Model.Parent")
                        .WithMany()
                        .ForeignKey("ParentParentId");
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
