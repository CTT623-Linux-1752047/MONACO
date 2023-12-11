using MONACO_ASP.Infracstructures;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MONACO_ASP.Entities
{
    public class Category : BaseEntity, IAuditEntity
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? name { get; set; }

        public DateTime? CreatedYMD { get; set; }

        public int? CreatedAt { get; set; }

        public DateTime? UpdatedYMD { get; set; }

        public string? UpdatedAt { get; set; }

        public string? URL { get; set; }
    }
}
