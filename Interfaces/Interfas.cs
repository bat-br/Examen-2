namespace SistemaGestorRecetas.Modelos
{
    public interface IReceta
    {
        string Nombre { get; }
        string Chef { get; }
        int TiempoMinutos { get; }
        string ToString();
    }

    public interface IExportador
    {
        void ExportarATxt(Modelos.Usuario usuario, string rutaArchivo);
    }
    
}