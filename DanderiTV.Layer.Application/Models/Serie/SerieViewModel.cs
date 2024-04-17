
using System.ComponentModel.DataAnnotations;

namespace DanderiTV.Layer.Application.Models.Serie
{
    public class SerieViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string CoverUrl { get; set; }
  
        public string VideoUrl { get; set; }

        public string? Producer { get; set; }

        public int? ProducerID { get; set; }

        public string? MainGenre { get; set; }
		public int? MainGenreID { get; set; }

		public string? SecondaryGenre { get; set; }
		public int? SecondaryGenreID { get; set; }
	}
}
