using Backend.Entities;

namespace Backend.Data
{
    public class IUpdateable
    {
        DateTime CreatedDate { get; set; }
        User? CreatedBy { get; set; }
        DateTime UpdatedDate { get; set; }
        User? UpdatedBy { get; set; }
        DateTime DeletedDate { get; set; }
        User? DeletedBy { get; set; }
        bool IsDeleted { get; set; } = false;
    }
}
