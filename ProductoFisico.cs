    public class ProductoFisico : Producto
    {
        public double Peso { get; set; }

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
