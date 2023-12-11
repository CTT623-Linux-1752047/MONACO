namespace MONACO_ASP.Infracstructures
{
    public class BaseEntity : Entity
    {

    }

    public class Entity
    {
        public int Id { get; set; }

        public string? CreatedAt { get; set; }

        public DateTime? CreatedYMD { get; set; }
    }

    public interface IAuditEntity
    {
        public string? UpdatedAt { get; set; }

        public DateTime? UpdatedYMD { get; set; }
    }

    public interface ISoftDeleteEntity
    {
        public bool IsDeleted { get; set; }

        public string? DeletedAt { get; set; }

        public DateTime? DeletedYMD { get; set; }

    }
}
