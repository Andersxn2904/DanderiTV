using DanderiTV.Layer.DataAccess.Entities.Common;

namespace DanderiTV.Layer.DataAccess.Entities
{
    public class Producer : BaseEntity
    {
        public ICollection<Serie>? Series { get; set; }
    }
}
