public abstract class Producto {  
        private decimal precio;
        private int cantidadEnStock;

        public string Id { get; set; }
        public string Nombre { get; set; }

        public decimal Precio
        {
            get { return precio; }   
            set 
            { 
                if (value >= 0)
                {
                    precio = value;
                }
                else
                {
                    throw new ArgumentException("El precio no puede ser un valor negativo.");
                }
            }
        }

        public int CantidadEnStock
        {
            get { return cantidadEnStock; }
            set 
            { 
                if (value >= 0)
                {
                    cantidadEnStock = value;
                }
                else
                {
                    throw new ArgumentException("La cantidad en stock no puede ser negativa.");
                }
            }
        }

        protected Producto(string id, string nombre, decimal precio, int cantidadEnStock)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            CantidadEnStock = cantidadEnStock;
        }

        public abstract void MostrarDetalles();
}