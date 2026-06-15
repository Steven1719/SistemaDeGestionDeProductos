public class ProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public void AgregarProductoFisico(string id, string nombre, decimal precio, int stock, double peso)
        {
            ProductoFisico nuevo = new ProductoFisico(id, nombre, precio, stock, peso);
            _repository.Agregar(nuevo);
        }

        public void AgregarProductoDigital(string id, string nombre, decimal precio, int stock, double tamanoMB)
        {
            ProductoDigital nuevo = new ProductoDigital(id, nombre, precio, stock, tamanoMB);
            _repository.Agregar(nuevo);
        }

        public Producto BuscarPorId(string id)
        {
            return _repository.ObtenerPorId(id);
        }

        public void ActualizarProductoFisico(string id, string nombre, decimal precio, int stock, double peso)
        {
            ProductoFisico actualizado = new ProductoFisico(id, nombre, precio, stock, peso);
            _repository.Actualizar(actualizado);
        }

        public void ActualizarProductoDigital(string id, string nombre, decimal precio, int stock, double tamanoMB)
        {
            ProductoDigital actualizado = new ProductoDigital(id, nombre, precio, stock, tamanoMB);
            _repository.Actualizar(actualizado);
        }

        public void EliminarProducto(string id)
        {
            _repository.Eliminar(id);
        }

        public List<Producto> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public List<Producto> FiltrarPorPrecio(decimal valor, string criterio)
        {
            List<Producto> productos = _repository.ObtenerTodos();

            return criterio switch
            {
                "mayor" => productos.Where(p => p.Precio > valor).ToList(),
                "menor" => productos.Where(p => p.Precio < valor).ToList(),
                "igual" => productos.Where(p => p.Precio == valor).ToList(),
                _ => throw new ArgumentException("Criterio de filtro no válido.")
            };
        }

        public List<Producto> OrdenarPorPrecio()
        {
            return _repository.ObtenerTodos().OrderBy(p => p.Precio).ToList();
        }

        public int ContarProductos()
        {
            return _repository.ObtenerTodos().Count;
        }
    }
