
using System.Text.Json;
    public class ProductoJsonRepository : IProductoRepository
    {
        private readonly string _archivo;
        private readonly JsonSerializerOptions _opciones;

        public ProductoJsonRepository(string archivo)
        {
            _archivo = archivo;
            _opciones = new JsonSerializerOptions 
            { 
                WriteIndented = true 
            };

            if (!File.Exists(_archivo))
                File.WriteAllText(_archivo, "[]");
        }

        private List<Producto> LeerArchivo()
        {
            string json = File.ReadAllText(_archivo);
            return JsonSerializer.Deserialize<List<Producto>>(json, _opciones) ?? new List<Producto>();
        }

        private void GuardarArchivo(List<Producto> productos)
        {
            string json = JsonSerializer.Serialize(productos, _opciones);
            File.WriteAllText(_archivo, json);
        }

        public void Agregar(Producto producto)
        {
            List<Producto> productos = LeerArchivo();
            
            if (productos.Any(p => p.Id.Equals(producto.Id, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Ya existe un producto con ese ID.");
                
            productos.Add(producto);
            GuardarArchivo(productos);
        }

        public Producto ObtenerPorId(string id)
        {
            return LeerArchivo().FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                ?? throw new KeyNotFoundException("Producto no encontrado.");
        }

        public void Actualizar(Producto productoActualizado)
        {
            List<Producto> productos = LeerArchivo();
            Producto producto = productos.FirstOrDefault(p => p.Id.Equals(productoActualizado.Id, StringComparison.OrdinalIgnoreCase))
                ?? throw new KeyNotFoundException("Producto no encontrado.");

            producto.Nombre = productoActualizado.Nombre;
            producto.Precio = productoActualizado.Precio;
            producto.CantidadEnStock = productoActualizado.CantidadEnStock;

            if (producto is ProductoFisico pf && productoActualizado is ProductoFisico pfa)
                pf.Peso = pfa.Peso;
            else if (producto is ProductoDigital pd && productoActualizado is ProductoDigital pda)
                pd.TamanoMB = pda.TamanoMB;

            GuardarArchivo(productos);
        }

        public void Eliminar(string id)
        {
            List<Producto> productos = LeerArchivo();
            Producto producto = productos.FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                ?? throw new KeyNotFoundException("El producto que intenta eliminar no existe.");

            productos.Remove(producto);
            GuardarArchivo(productos);
        }

        public List<Producto> ObtenerTodos()
        {
            return LeerArchivo();
        }
    }
