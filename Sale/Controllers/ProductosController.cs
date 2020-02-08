using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sale.Models;
using System.IO;

namespace Sale.Controllers
{
    public class ProductosController : Controller
    {
        private Context db = new Context();

        // GET: Producto
        public async Task<ActionResult> Index()
        {
            var productos = db.Productos.Include(p => p.Categoria);
            return View(await db.Productos.ToListAsync());
        }

        // GET: Producto/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = await db.Productos.FindAsync(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categorias, "idCategoria", "nombre");
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                if(Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    string pictureName = Path.GetFileName(file.FileName);
                    if(pictureName != "")
                    {
                        string serverPath = Path.Combine(HttpContext.Server.MapPath("~/Content/img/productos"), pictureName);
                        string[] paths = serverPath.Split('.');
                        string time = DateTime.UtcNow.ToString();
                        time = time.Replace(" ", "_").Replace(":", "_").Replace(".", "").Replace("/", "_");
                        string url = paths[0] + "-" + time + Path.GetExtension(pictureName);
                        file.SaveAs(url);
                        producto.img = "~\\Content\\img\\productos" + Path.GetFileNameWithoutExtension(file.FileName) + "-" + time + Path.GetExtension(pictureName);
                    }
                }

                db.Productos.Add(producto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.Categorias, "idCategoria", "nombre", producto.idCategoria);
            return View(producto);
        }

        // GET: Producto/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = await db.Productos.FindAsync(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.Categorias, "idCategoria", "nombre", producto.idCategoria);
            return View(producto);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idProducto,codigo,nombre,descripcion,stock,stockMin,precioCosto,precioVenta,idCategoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.Categorias, "idCategoria", "nombre", producto.idCategoria);
            return View(producto);
        }

        // GET: Producto/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = await db.Productos.FindAsync(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Producto producto = await db.Productos.FindAsync(id);
            db.Productos.Remove(producto);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
