﻿using Backend.Data;
using Backend.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public class AuthActivity : IUpdateable
    {
        [Key]
        public Guid Id { get; set; }
        public AuthCategory AuthCategory { get; set; }

        public List<User_Auth_Activity>? User_Auth_Activity { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }

        public int DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
