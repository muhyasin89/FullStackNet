namespace Backend.Data
{
    public interface IUserUpdateable
    {

         DateTime CreatedDate { get; set; }
         Guid CreatedBy { get; set; }
         DateTime UpdatedDate { get; set; }
        Guid UpdatedBy { get; set; }
        DateTime DeletedDate { get; set; }
        Guid DeletedBy { get; set; }
        bool IsDeleted { get; set; }
    }
}
