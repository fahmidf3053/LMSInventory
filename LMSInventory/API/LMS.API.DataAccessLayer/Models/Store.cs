using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static LMS.API.Utils.Constants;
using LMS.API.DataAccessLayer.Interfaces;

namespace LMS.API.DataAccessLayer.Models
{
    [Table("Store")]
    public class Store : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }

        public ICollection<Rack> Racks { get; set; }

        public EntityState EntityState { get; set; }

    }
}
