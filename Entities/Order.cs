using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDataBaseFirst.Entities
{
    [PrimaryKey("OrderNumber")]
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNumber { get; set; }
        [ForeignKey("Customer")]

        public int CustomerId { get; set; }
        public virtual Customer customer { get; set; }
        public string Amount { get; set; }
      
    }
}
