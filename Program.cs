
            IProductoRepository repository = new ProductoJsonRepository("productos.json");
            ProductoService service = new ProductoService(repository);
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== GESTOR DE PRODUCTOS ===");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Buscar producto");
                Console.WriteLine("3. Actualizar producto");
                Console.WriteLine("4. Eliminar producto");
                Console.WriteLine("5. Listar productos");
                Console.WriteLine("6. Filtrar productos");
                Console.WriteLine("7. Ordenar productos");
                Console.WriteLine("8. Mostrar total de productos");
                Console.WriteLine("9. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine() ?? "";

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            Console.Write("Tipo (1: Físico, 2: Digital): ");
                            string tipo = Console.ReadLine() ?? "";
                            Console.Write("ID: ");
                            string id = Console.ReadLine()!;
                            Console.Write("Nombre: ");
                            string nom = Console.ReadLine()!;
                            Console.Write("Precio: ");
                            decimal pre = decimal.Parse(Console.ReadLine()!);
                            Console.Write("Stock: ");
                            int stock = int.Parse(Console.ReadLine()!);

                            if (tipo == "1")
                            {
                                Console.Write("Peso (kg): ");
                                double peso = double.Parse(Console.ReadLine()!);
                                service.AgregarProductoFisico(id, nom, pre, stock, peso);
                            }
                            else if (tipo == "2")
                            {
                                Console.Write("Tamaño (MB): ");
                                double tamano = double.Parse(Console.ReadLine()!);
                                service.AgregarProductoDigital(id, nom, pre, stock, tamano);
                            }
                            else
                            {
                                Console.WriteLine("Tipo no válido.");
                                break;
                            }
                            Console.WriteLine("Producto agregado con éxito.");
                            break;

                        case "2":
                            Console.Write("Ingrese el ID a buscar: ");
                            Producto p = service.BuscarPorId(Console.ReadLine()!);
                            p.MostrarDetalles();
                            break;

                        case "3":
                            Console.Write("Ingrese el ID a actualizar: ");
                            string idAct = Console.ReadLine()!;
                            Producto pAct = service.BuscarPorId(idAct);
                            
                            Console.Write("Nuevo Nombre: ");
                            string nomAct = Console.ReadLine()!;
                            Console.Write("Nuevo Precio: ");
                            decimal preAct = decimal.Parse(Console.ReadLine()!);
                            Console.Write("Nuevo Stock: ");
                            int stockAct = int.Parse(Console.ReadLine()!);

                            if (pAct is ProductoFisico)
                            {
                                Console.Write("Nuevo Peso (kg): ");
                                double pesoAct = double.Parse(Console.ReadLine()!);
                                service.ActualizarProductoFisico(idAct, nomAct, preAct, stockAct, pesoAct);
                            }
                            else if (pAct is ProductoDigital)
                            {
                                Console.Write("Nuevo Tamaño (MB): ");
                                double tamanoAct = double.Parse(Console.ReadLine()!);
                                service.ActualizarProductoDigital(idAct, nomAct, preAct, stockAct, tamanoAct);
                            }
                            Console.WriteLine("Producto actualizado con éxito.");
                            break;

                        case "4":
                            Console.Write("Ingrese el ID a eliminar: ");
                            service.EliminarProducto(Console.ReadLine()!);
                            Console.WriteLine("Producto eliminado con éxito.");
                            break;

                        case "5":
                            List<Producto> todos = service.ObtenerTodos();
                            if (todos.Count == 0) Console.WriteLine("No existen productos registrados.");
                            else foreach (Producto item in todos) item.MostrarDetalles();
                            break;

                        case "6":
                            Console.Write("Criterio (mayor, menor, igual): ");
                            string criterio = Console.ReadLine()!.ToLower();
                            Console.Write("Valor de referencia: ");
                            decimal valorFiltro = decimal.Parse(Console.ReadLine()!);
                            List<Producto> filtrados = service.FiltrarPorPrecio(valorFiltro, criterio);
                            
                            if (filtrados.Count == 0) Console.WriteLine("Ningún producto cumple el criterio.");
                            else foreach (Producto item in filtrados) item.MostrarDetalles();
                            break;

                        case "7":
                            List<Producto> ordenados = service.OrdenarPorPrecio();
                            if (ordenados.Count == 0) Console.WriteLine("No existen productos registrados.");
                            else foreach (Producto item in ordenados) item.MostrarDetalles();
                            break;

                        case "8":
                            Console.WriteLine($"Total de productos registrados: {service.ContarProductos()}");
                            break;

                        case "9":
                            salir = true;
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: El valor ingresado no tiene el formato correcto.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione la tecla Enter para continuar...");
                    Console.ReadLine();
                }
            }