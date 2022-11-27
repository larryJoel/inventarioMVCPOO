using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioMVCPOO.Models
{
    public class Articulo
    {
        [Key]
      public int Id { get; set; }

      [Required(ErrorMessage ="El codigo del proveedor es obligatorio")]
      public int CodigoProveedor { get; set; }
      
      [Required(ErrorMessage ="El nombre es obligatorio")]
      public string? Nombre { get; set; }

     [Required(ErrorMessage ="la descripción es obligatoria")]
      public string? Descripcion { get; set; }
  
     [Required(ErrorMessage ="La categoria es obligatoria")]
      public string? Categoria { get; set; }

     [Required(ErrorMessage ="El precio unitario es obligatorio")]
      public double PrecioUnitario { get; set; }
      //[Display(Name = "Precio Unitario" )]

      [Required(ErrorMessage ="La unidad en stock es obligatorio")]
      public int UnidadStock { get; set; }
  
      [Required(ErrorMessage ="La unidad de compra es obligatorio")]
      public int UnidadCompra { get; set; }

      [Required(ErrorMessage ="El punto de reorden es obligatorio")]
      public int PtoReorden { get; set; }
  
      [Required(ErrorMessage ="Si el articulo esta descontinuado es obligatorio")]
      public string? descontinuado { get; set; }
    }
}