    public interface IProductoRepository
    {
        void Agregar(Producto producto);
        Producto ObtenerPorId(string id);
        void Actualizar(Producto producto);
        void Eliminar(string id);
        List<Producto> ObtenerTodos();
    }
