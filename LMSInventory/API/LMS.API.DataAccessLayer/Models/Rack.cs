using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static LMS.API.Utils.Constants;
using LMS.API.DataAccessLayer.Interfaces;

namespace LMS.API.DataAccessLayer.Models
{
    [Table("Rack")]
    public class Rack : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        public int QuantityOfRack { get; set; }

        public int StoreId { get; set; }

        [ForeignKey("StoreId")]
        public Store Store { get; set; }

        public ICollection<Element> Elements { get; set; }

        public EntityState EntityState { get; set; }

    }
}
