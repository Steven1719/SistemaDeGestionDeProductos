    public class ProductoDigital : Producto
    {
        public double TamanoMB { get; set; }

        public ProductoDigital(string id, string nombre, decimal precio, int cantidadEnStock, double tamanoMB) 
            : base(id, nombre, precio, cantidadEnStock)
        {
            TamanoMB = tamanoMB;
        }

        public override void MostrarDetalles()
        {
            Console.WriteLine($"[Digital] ID: {Id} | Nombre: {Nombre} | Precio: ${Precio:F2} | Stock: {CantidadEnStock} | Tamaño: {TamanoMB}MB");
        }
    }
