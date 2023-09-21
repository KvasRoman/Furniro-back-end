using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniro.DataAccess.Models.Api.Response
{
    public class ProductCards
    {
        public int Total;
        public IEnumerable<ProductCard> Cards;
    }
}
