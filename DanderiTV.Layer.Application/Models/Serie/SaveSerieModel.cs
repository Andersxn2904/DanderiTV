
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanderiTV.Layer.Application.Models.Serie
{
    public class SaveSerieModel
    {
        [Required(ErrorMessage = "You must enter a name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must enter an Image")]
        [DataType(DataType.Text)]
        public string CoverUrl { get; set; }
        [Required(ErrorMessage = "You must enter a Video Url")]
        [DataType(DataType.Text)]
        public string VideoUrl { get; set; }
        
        public int ProducerID { get; set; }
        
        public int MainGenreID { get; set; }
       
        public int SecondaryGenreID { get; set; }
    }
}
