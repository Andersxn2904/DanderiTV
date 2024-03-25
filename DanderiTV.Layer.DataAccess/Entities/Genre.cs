

using DanderiTV.Layer.DataAccess.Entities.Common;

namespace DanderiTV.Layer.DataAccess.Entities
{
    public class Genre : BaseEntity
    {
        public ICollection<Serie>? SeriesMainGenres { get; set; }
        public ICollection<Serie>? SeriesSecondaryGenres { get; set; }
    }
}
