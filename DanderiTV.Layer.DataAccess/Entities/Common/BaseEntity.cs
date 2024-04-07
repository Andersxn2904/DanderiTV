using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DanderiTV.Layer.DataAccess.Entities.Common
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("ID")]
        public virtual int ID { get; set; }
        [Column("Name")]
        public string Name{ get; set; }

        [Column("Created")]
        public DateTime? Created {  get; set; } = DateTime.Now;
    }
}
