using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniro.DataAccess.Models.DataAccess
{
    [PrimaryKey("Id")]
    public class ProductImage
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public int OrderNumber { get; set; }
        public Guid? ProductId { get; set; }
        public virtual Product ProductRef { get; set; }

    }
}
