    public class ProductoFisico : Producto
    {
        private double _peso;

        public double Peso
        {
            get => _peso;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El peso no puede ser negativo.");
                _peso = value;
            }
        }

        public ProductoFisico(string id, string nombre, decimal precio, int cantidadEnStock, double peso) 
            : base(id, nombre, precio, cantidadEnStock)
        {
            Peso = peso;
        }

        public override void MostrarDetalles()
        {
            Console.WriteLine($"[Físico] ID: {Id} | Nombre: {Nombre} | Precio: ${Precio:F2} | Stock: {CantidadEnStock} | Peso: {Peso}kg");
        }
    }
