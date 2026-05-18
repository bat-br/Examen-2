using SistemaGestorRecetas.Interfaces;
using SistemaRecetas.Modelos;
using SistemaGestorRecetas.Servicios;
using SistemaGestorRecetas.Gestores;


        IGestorRecetas gestor = new GestorRecetas();
        IExportador exportador = new ExportadorTxt();
        ServicioRecetas servicio = new ServicioRecetas(gestor, exportador);

        // Añadir 8 recetas de ejemplo según el diagrama
        gestor.AgregarReceta(new Receta("Paella", "Chef Ramirez", 45));
        gestor.AgregarReceta(new Receta("Tacos", "Chef Carlos", 30));
        gestor.AgregarReceta(new Receta("Risotto", "Chef Luigi", 50));
        gestor.AgregarReceta(new Receta("Ceviche", "Chef Maria", 20));
        gestor.AgregarReceta(new Receta("Ramen", "Chef Kenji", 90));
        gestor.AgregarReceta(new Receta("Guacamole", "Chef Ana", 10));
        gestor.AgregarReceta(new Receta("Croissant", "Chef Pierre", 120));
        gestor.AgregarReceta(new Receta("Tiramisu", "Chef Mario", 40));

        Console.WriteLine("SISTEMA DE GESTIÓN DE RECETAS DE COCINA\n");
        Console.WriteLine("--- REGISTRO DE USUARIO ---");
        Console.Write("Por favor, ingrese su nombre de usuario: ");
        string nombreUsuario = Console.ReadLine();
        Usuario usuarioActual = servicio.RegistrarUsuario(nombreUsuario);

        Console.Write("Ingrese un nombre para su libro de recetas: ");
        string nombreLibroActual = Console.ReadLine();
        usuarioActual.CrearLibroRecetas(nombreLibroActual);

        bool salir = false;
        while (!salir)
        {
    int cantidad = usuarioActual.MisLibros.ContainsKey(nombreLibroActual) ? usuarioActual.MisLibros[nombreLibroActual].Count : 0;
            Console.WriteLine($"\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine($"Libro actual: '{nombreLibroActual}' ({cantidad} recetas en total)");
            Console.WriteLine("1. Mostrar Recetas disponibles en catálogo");
            Console.WriteLine("2. Ordenar libro actual");
            Console.WriteLine("3. Búsqueda binaria en catálogo");
            Console.WriteLine("4. Crear nuevo libro de recetas");
            Console.WriteLine("5. Cambiar de libro actual");
            Console.WriteLine("6. Ver mis Libros");
            Console.WriteLine("7. Exportar a .txt");
            Console.WriteLine("8. Salir");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Catálogo de Recetas:");
                    for (int i = 0; i < gestor.RecetasDisponibles.Count; i++)
                    {
                        Console.WriteLine($"[{i}] {gestor.RecetasDisponibles[i].ToString()}");
                    }
                    break;
                case "2":
                    Console.WriteLine("1. QuickSort");
                    Console.WriteLine("2. MergeSort");
                    string optOrden = Console.ReadLine();
                    if (optOrden == "1") servicio.OrdenarCatalogo("quick");
                    else if (optOrden == "2") servicio.OrdenarCatalogo("merge");
                    break;
                case "3":
                    Console.Write("Ingrese el nombre de la receta a buscar: ");
                    string busqueda = Console.ReadLine();
                    int indice = gestor.BusquedaBinaria(busqueda);
                    if (indice != -1)
                    {
                        Console.WriteLine($"Receta encontrada: {gestor.RecetasDisponibles[indice].ToString()}");
                        Console.Write("¿Desea agregarla a su libro actual? (s/n): ");
                        if (Console.ReadLine().ToLower() == "s")
                        {
                            usuarioActual.AgregarRecetaALibro(nombreLibroActual, gestor.RecetasDisponibles[indice]);
                            Console.WriteLine("Receta agregada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Receta no encontrada en el catálogo.");
                    }
                    break;
                case "4":
                    Console.Write("Nombre del nuevo libro: ");
                    string nuevoLibro = Console.ReadLine();
                    try
                    {
                        usuarioActual.CrearLibroRecetas(nuevoLibro);
                        nombreLibroActual = nuevoLibro;
                        Console.WriteLine("Libro creado y seleccionado.");
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    break;
                case "5":
                    Console.Write("Ingrese el nombre del libro al que desea cambiar: ");
                    string cambioLibro = Console.ReadLine();
                     if (usuarioActual.MisLibros.ContainsKey(cambioLibro))
                         {
                            nombreLibroActual = cambioLibro;
                            Console.WriteLine("Libro cambiado.");
                         }
            else
                    {
                        Console.WriteLine("El libro no existe.");
                    }
                    break;
                case "6":
                    usuarioActual.MostrarLibros();
                    break;
                case "7":
                    Console.Write("Nombre del archivo (ej. misrecetas.txt): ");
                    string ruta = Console.ReadLine();
                    exportador.ExportarAtxt(usuarioActual, ruta);
                    Console.WriteLine("Archivo exportado exitosamente.");
                    break;
                case "8":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
