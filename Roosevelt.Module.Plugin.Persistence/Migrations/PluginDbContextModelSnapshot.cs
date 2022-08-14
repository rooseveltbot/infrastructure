// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Roosevelt.Module.Plugin.Persistence;

#nullable disable

namespace Roosevelt.Module.Plugin.Persistence.Migrations
{
    [DbContext(typeof(PluginDbContext))]
    partial class PluginDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Roosevelt.Module.Plugin.Persistence.Entities.PluginDeveloperEntity", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PluginId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "PluginId");

                    b.HasIndex("PluginId");

                    b.ToTable("plugin_developer", "plugin");
                });

            modelBuilder.Entity("Roosevelt.Module.Plugin.Persistence.Entities.PluginEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("plugin", "plugin");
                });

            modelBuilder.Entity("Roosevelt.Module.Plugin.Persistence.Entities.PluginDeveloperEntity", b =>
                {
                    b.HasOne("Roosevelt.Module.Plugin.Persistence.Entities.PluginEntity", "Plugin")
                        .WithMany("Authors")
                        .HasForeignKey("PluginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plugin");
                });

            modelBuilder.Entity("Roosevelt.Module.Plugin.Persistence.Entities.PluginEntity", b =>
                {
                    b.Navigation("Authors");
                });
#pragma warning restore 612, 618
        }
    }
}