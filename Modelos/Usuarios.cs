using SistemaRecetas.Modelos;

public class Usuario
{
    public string Nombre { get; set; }
    public Dictionary<string, List<Receta>> MisLibros { get; private set; }

    public Usuario(string nombre)
    {
        Nombre = nombre;
        MisLibros = new Dictionary<string, List<Receta>>();
    }

    public void CrearLibroRecetas(string nombreLibro)
    {
        if (!MisLibros.ContainsKey(nombreLibro))
            MisLibros.Add(nombreLibro, new List<Receta>());
    }

    public void AgregarRecetaALibro(string nombreLibro, Receta receta)
    {
        if (MisLibros.ContainsKey(nombreLibro))
            MisLibros[nombreLibro].Add(receta);
        else
            throw new ArgumentException("El libro no existe");
    }
    public void EliminarLibro(string nombreLibro)
    {
        if (MisLibros.ContainsKey(nombreLibro))
            MisLibros.Remove(nombreLibro);
        else
            throw new ArgumentException("El libro no existe");
    }

    public void ObtenerLibrosDeRecetas(string nombreLibro)
    {
        if (MisLibros.ContainsKey(nombreLibro))
        {
            Console.WriteLine($"Libro: {nombreLibro}");
            foreach (var receta in MisLibros[nombreLibro])
            {
                Console.WriteLine($"  - {receta}");
            }
        }
        else
        {
            throw new ArgumentException("El libro no existe");
        }
    }
    public void ContarRecetasEnLibro(string nombreLibro)
    {
        if (MisLibros.ContainsKey(nombreLibro))
        {
            int cantidad = MisLibros[nombreLibro].Count;
            Console.WriteLine($"El libro '{nombreLibro}' tiene {cantidad} receta(s).");
        }
        else
        {
            throw new ArgumentException("El libro no existe");
        }
    }
    public void MostrarLibros()
    {
        Console.WriteLine($"Usuario: {Nombre}");
        if (MisLibros.Count == 0)
        {
            Console.WriteLine("No tienes libros de recetas.");
            return;
        }
        Console.WriteLine("Libros de Recetas:");
        foreach (var libro in MisLibros.Keys)
        {
            Console.WriteLine($"- {libro}");
        }
    }
}