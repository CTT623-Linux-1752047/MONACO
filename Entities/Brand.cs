using MONACO_ASP.Infracstructures;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MONACO_ASP.Entities
{
    public class Brand : BaseEntity, IAuditEntity, ISoftDeleteEntity
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? name { get; set; }

        public string? description { get; set; }

        public string? img_background { get; set; }

        public string? img_logo { get; set; }

        public string? since { get; set; }

        public DateTime? CreatedYMD { get; set; }

        public string? CreatedAt { get; set; }

        public DateTime? UpdatedYMD { get; set; }

        public string? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public string? DeletedAt { get; set; }

        public DateTime? DeletedYMD { get; set; }

    }
}
