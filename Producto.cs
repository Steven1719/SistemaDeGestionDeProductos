    using System.Text.Json.Serialization;
    
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "TipoProducto")]
    [JsonDerivedType(typeof(ProductoFisico), typeDiscriminator: "Fisico")]
    [JsonDerivedType(typeof(ProductoDigital), typeDiscriminator: "Digital")]
    public abstract class Producto
    {
        private decimal _precio;
        private int _cantidadEnStock;

        public string Id { get; set; }
        public string Nombre { get; set; }

        public decimal Precio
        {
            get => _precio;
            set 
            { 
                if (value < 0)
                    throw new ArgumentException("El precio no puede ser negativo.");
                _precio = value;
            }
        }

        public int CantidadEnStock
        {
            get => _cantidadEnStock;
            set 
            { 
                if (value < 0)
                    throw new ArgumentException("El stock no puede ser negativo.");
                _cantidadEnStock = value;
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
