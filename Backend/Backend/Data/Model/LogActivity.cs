using Backend.Data.Enums;

namespace Backend.Data.Model
{
    public class ActivityLog : IUpdateable
    {
        public Guid Id { get; set; }
        public AuthCategory AuthCategory { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
