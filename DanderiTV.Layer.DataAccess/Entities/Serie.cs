

using DanderiTV.Layer.DataAccess.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanderiTV.Layer.DataAccess.Entities
{
    [Table("Series")]
    public class Serie : BaseEntity
    {
        [Column("CoverUrl")]
        public string CoverUrlProperty { get; set; }
        [Column("VideoUrl")]
        public string VideoUrlProperty { get; set; }
        [Column("ProducerID")]
        public int ProducerID { get; set; }
        [Column("MainGenreID")]
        public int MainGenreID { get; set; }
        [Column("SecondaryGenreID")]
        public int SecondaryGenreID { get; set; }


    }
}
