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

    public void CrearLibro(string nombreLibro)
    {
        if (!MisLibros.ContainsKey(nombreLibro))
            MisLibros.Add(nombreLibro, new List<Receta>());
    }
}