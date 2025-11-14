using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        [StringLength(70)]
        public string NameUsername { get; set; }

        [StringLength(60)]
        public string Mail {  get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(350)]
        public string Message { get; set; }

        public DateTime MessageDate { get; set; }

    }
}
