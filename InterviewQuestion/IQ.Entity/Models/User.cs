using System;
using System.Collections.Generic;

#nullable disable

namespace IQ.Entity.Models
{
    public partial class User
    {
        public User()
        {
            Invoices = new HashSet<Invoice>();
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }
        public int RoleId { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
