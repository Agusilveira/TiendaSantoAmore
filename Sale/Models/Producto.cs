using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sale.Models
{
    [Table("Productos")]
    public class Producto
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProducto { get; set; }

        [Required]
        [Display(Name = "Codigo")]
        public string codigo { get; set; }

        [Required]
        [Display(Name = "Producto")]
        public string nombre { get; set; }
        
        [Required]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int stock { get; set; }

        [Required]
        [Display(Name = "Cantidad Minima")]
        public int stockMin { get; set; }

        [Required]
        [Display(Name = "Precio Costo")]
        [DataType("decimal(18,2)")]
        public decimal precioCosto { get; set; }

        [Required]
        [Display(Name = "Precio Venta")]
        [DataType("decimal(18,2)")]
        public decimal precioVenta { get; set; }

        [Display(Name = "Imagen")]
        public string img { get; set; }

        [ForeignKey("idCategoria")]        
        public Categoria Categoria { get; set; }

        [Display(Name = "Categoria")]
        public int idCategoria { get; set; }
    }
}