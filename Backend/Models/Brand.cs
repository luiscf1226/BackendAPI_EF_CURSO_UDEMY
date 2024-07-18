using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Models
{
    public class Brand
    {
        //especificar cual es el key de la tabla
        [Key]
        //Especificar que es autoincremental
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //creacion de modelo para represntar la tabla de la base de datos
        public int BrandID { get; set; }
        public string Name { get; set; }
    }
}
