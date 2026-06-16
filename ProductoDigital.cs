    public class ProductoDigital : Producto
    {
        private double _tamanoMB;

        public double TamanoMB
        {
            get => _tamanoMB;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El tamaño en MB no puede ser negativo.");
                _tamanoMB = value;
            }
        }

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
