﻿using System;
using System.Collections.Generic;
//éste se agrega
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities;

public class ProductoVendido
{
    public int Id { get; set; }
    public int IdProducto { get; set; }
    public int Stock { get; set; }
    public int IdVenta { get; set; }
}
