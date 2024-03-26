
namespace DanderiTV.Layer.DataAccess.Entities.Common
{
    public abstract class BaseEntity
    {
        public virtual int ID { get; set; }
        public string Name { get; set; }
        public DateTime? Created {  get; set; } = DateTime.Now;
    }
}
