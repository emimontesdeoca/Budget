using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations.Internal;

namespace BlazorApp1.Server.Data
{
    // Taken from this medium post https://medium.com/@emadalsous/migrate-sql-server-database-to-postgresql-using-ef-core-and-migrate-data-using-pentaho-981379327349
    // This is only to try to be in compliance with the convention
    public class LoweredCaseMigrationHistoryRepository : NpgsqlHistoryRepository
    {
        public LoweredCaseMigrationHistoryRepository(HistoryRepositoryDependencies dependencies) : base(dependencies)
        {
        }

        protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
        {
            base.ConfigureTable(history);
            history.Property(h => h.MigrationId).HasColumnName("migrationid");
            history.Property(h => h.ProductVersion).HasColumnName("productversion");
        }
    }
}
