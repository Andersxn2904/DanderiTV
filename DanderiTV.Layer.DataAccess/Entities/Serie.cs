

using DanderiTV.Layer.DataAccess.Entities.Common;

namespace DanderiTV.Layer.DataAccess.Entities
{
    public class Serie : BaseEntity
    {
        public string CoverUrl { get; set; }
        public string VideoUrl { get; set; }
        public int ProducerID { get; set; }
        public int MainGenreID { get; set; }
        public int SecondaryGenreID { get; set; }

        // Navigation properties
        public Genre Main { get; set; }
        public Genre? Secundary { get; set; }
        public Producer? Producers { get; set; }
    }
}
