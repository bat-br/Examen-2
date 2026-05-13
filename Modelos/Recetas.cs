namespace SistemaRecetas.Modelos
{
    public class Receta
    {
        public string Nombre { get; set; }
        public string Chef { get; set; }
        public int TiempoMinutos { get; set; }

        public Receta(string nombre, string chef, int tiempo)
        {
            Nombre = nombre;
            Chef = chef;
            // Validación solicitada en el PDF
            TiempoMinutos = tiempo > 0 ? tiempo : throw new ArgumentException("El tiempo debe ser mayor a 0");
        }

        public override string ToString() => $"{Nombre} - {Chef} ({TiempoMinutos} min)";
    }
}