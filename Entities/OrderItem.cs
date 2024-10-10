using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDataBaseFirst.Entities
{
    [Keyless]
    public class OrderItem
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order order { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
       
        public virtual Item item { get; set; }
    }
}
