using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oerlikon.Core.Databases
{
    [Table("vehicles")]
    public class Vehicle
    {
        [Key]
        public Guid UID { get; set; }

        [Column("plate_no")]
        public string PlateNo { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }

        

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

    }
}
