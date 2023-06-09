namespace Backend.Data
{
    public class IUpdateable
    {

         DateTime CreatedDate { get; set; }
         int CreatedBy { get; set; }
         DateTime UpdatedDate { get; set; }
         int UpdatedBy { get; set; }
    }
}
