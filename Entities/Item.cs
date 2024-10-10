using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDataBaseFirst.Entities
{
    [PrimaryKey("Id")]
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public string Name { get; set; }
        public int price { get; set; }
        public int Quantity { get; set; }




    }
}
