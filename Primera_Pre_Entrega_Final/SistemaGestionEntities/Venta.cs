using System;
using System.Collections.Generic;
//éste se agrega
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities;

public class Venta
{
    public int Id { get; set; }
    public string Comentarios { get; set; }
    public int IdUsuario { get; set; }
}
