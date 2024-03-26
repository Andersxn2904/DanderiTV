using DanderiTV.Layer.DataAccess.Enums;
using FluentMigrator;
    
namespace DanderiTV.Layer.DataAccess.Migrations
{
    [Migration(2410230001)]

    public class _2410230001_Migration : Migration
    {
        public override void Up()
        {
            //Based on Class Serie defined on DanderiTV.Layer.DataAccess.Entities
            #region Tables
            Create.Table(Tables.Series.ToString())
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100)
                .WithColumn("CoverUrl").AsString(100)
                .WithColumn("VideoUrl").AsString(100)
                .WithColumn("ProducerID").AsInt32()
                .WithColumn("MainGenreID").AsInt32()
                .WithColumn("SecondaryGenreID").AsInt32()
                .WithColumn("Created").AsDateTime();

            Create.Table(Tables.Producers.ToString())
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("Name").AsString(100)
               .WithColumn("Created").AsDateTime();

            Create.Table(Tables.Genres.ToString())
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("Name").AsString(100)
               .WithColumn("Created").AsDateTime();



            #endregion

            #region RelationShips

            #region Series
            Create.ForeignKey("FK_Producer_Serie")
                .FromTable(Tables.Series.ToString()).ForeignColumn("ProducerID")
                .ToTable(Tables.Producers.ToString()).PrimaryColumn("Id");

            Create.ForeignKey("FK_Serie_Genre_MainG")
                .FromTable(Tables.Series.ToString()).ForeignColumn("MainGenreID")
                .ToTable(Tables.Genres.ToString()).PrimaryColumn("Id");

            Create.ForeignKey("FK_Serie_Genre_SecG")
               .FromTable(Tables.Series.ToString()).ForeignColumn("SecondaryGenreID")
               .ToTable(Tables.Genres.ToString()).PrimaryColumn("Id");

            #endregion

            #endregion
        }

        public override void Down()
        {
            Delete.Table("Producto");
        }
    }
}
