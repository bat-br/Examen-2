namespace SistemaGestorRecetas.Modelos
{
    public interface IReceta
    {
        string Nombre { get; }
        string Chef { get; }
        int TiempoMinutos { get; }
        string ToString();
    }

    public class Receta : IReceta
    {
        public string Nombre { get; private set; }
        public string Chef { get; private set; }
        public int TiempoMinutos { get; private set; }

    }
   
}