using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.DataAccess.Contexts;
using DanderiTV.Layer.DataAccess.Entities;
using Dapper;
using System.Data;
using DanderiTV.Layer.Application.Enums;
using DanderiTV.Layer.Application.Models.Serie;


namespace DanderiTV.Layer.Application.Repositories
{
    public class SerieRepository : GenericRepository<Serie>, ISerieRepository
    {
        private readonly IDbConnection _dbConnection;
        public SerieRepository(DapperContext context) : base(context) { _dbConnection = context.CreateConnection(); }

        public async Task<IEnumerable<SerieViewModel>> GetAllWithInclude()
        {
            IEnumerable<SerieViewModel> result = null;

            try
            {
                string tableName = Tables.Series.ToString();
                string query = $"SELECT s.*, g1.Name AS MainGenre, g2.Name AS SecondaryGenre, p.Name AS Producer " +
                               $"FROM {tableName} s " +
                               $"LEFT JOIN Genres g1 ON s.MainGenreID = g1.ID " +
                               $"LEFT JOIN Genres g2 ON s.SecondaryGenreID = g2.ID " +
                               $"LEFT JOIN Producers p ON s.ProducerID = p.ID";

                result = await _dbConnection.QueryAsync<SerieViewModel>(query);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

            return result;
        }

        public async Task<SerieViewModel> FindByIDWithAll(int id)
        {
            SerieViewModel result = null;

            try
            {
                string tableName = Tables.Series.ToString();
                string query = $"SELECT s.*, g1.Name AS MainGenre, g2.Name AS SecondaryGenre, p.Name AS Producer " +
                               $"FROM {tableName} s " +
                               $"LEFT JOIN Genres g1 ON s.MainGenreID = g1.ID " +
                               $"LEFT JOIN Genres g2 ON s.SecondaryGenreID = g2.ID " +
                               $"LEFT JOIN Producers p ON s.ProducerID = p.ID " +
                               $"WHERE s.ID = @id";

                result = await _dbConnection.QueryFirstOrDefaultAsync<SerieViewModel>(query, new { id });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }


    }
}
