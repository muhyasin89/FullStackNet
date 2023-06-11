using Backend.Data;
using Backend.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public class LogActivity 
    {
        [Key]
        public Guid Id { get; set; }
      

        public DateTime CreatedDate { get; set; }
   


    }
}
