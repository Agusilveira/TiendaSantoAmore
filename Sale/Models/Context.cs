using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sale.Models
{
    public class Context: DbContext
    {
        public Context() : base("name=Context")
        {

        }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
    }
}