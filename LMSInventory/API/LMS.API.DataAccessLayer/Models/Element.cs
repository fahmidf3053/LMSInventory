using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static LMS.API.Utils.Constants;
using LMS.API.DataAccessLayer.Interfaces;

namespace LMS.API.DataAccessLayer.Models
{
    [Table("Element")]
    public class Element : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }

        public int RackId { get; set; }

        [ForeignKey("RackId")]
        public Rack Rack { get; set; }

        public EntityState EntityState { get; set; }

    }
}
