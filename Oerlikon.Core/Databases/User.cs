using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oerlikon.Core.Databases
{
    [Table("users")]
    public class User
    {
        [Key]
        public Guid UID { get; set; }
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("hashed_password")]
        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public string Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
