using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Beer
    {
        //representacion de la tabla de la base de datos
        //especificar cual es el key de la tabla
        [Key]
        //Especificar que es autoincremental
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //creacion de modelo para represntar la tabla de la base de datos
        public int BeerID { get; set; }

        public string Name { get; set; }
        //caso especial para decimales
        [Column(TypeName = "decimal(18,2)")]
        public decimal Alcohol { get; set; }

        //relacion con la tabla de Brand
        public int BrandID { get; set; }
        //especificar llave foranea
        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }

    }
}
