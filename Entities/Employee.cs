using MONACO_ASP.Infracstructures;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MONACO_ASP.Entities
{
        public class Employee : BaseEntity, IAuditEntity, ISoftDeleteEntity
        {
            [Key, Column(Order = 1)]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
            public string? Email { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 3)]
            public string? Firstname { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 3)]
            public string? Lastname { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 3)]
            public string? Middlename { get; set; }

            public string? Username { get; set; }

            public string? Address { get; set; }

            public bool Gender { get; set; } = false; // True: Male, False: Female

            public DateTime? Birthday { get; set; }

            public int? CreateAt { get; set; }

            public DateTime? CreatedYMD { get; set; }

            public bool IsBlocked { get; set; }

            public bool IsActived { get; set; }

            [Required]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
            public string? Password { get; set; }

            public int? Position { get; set; } = 1; // 1: Sale ; 2: Admin; 3: SuperAdmin

            #region FullAudit
            public string? UpdatedAt { get; set; }

            public DateTime? UpdatedYMD { get; set; }

            public bool IsDeleted { get; set; }

            public string? DeletedAt { get; set; }

            public DateTime? DeletedYMD { get; set; }
            #endregion
        }
    }
