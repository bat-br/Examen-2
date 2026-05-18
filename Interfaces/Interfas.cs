using SistemaRecetas.Modelos;

namespace SistemaGestorRecetas.Interfaces
{
    public interface IReceta
    {
        string Nombre { get; }
        string Chef { get; }
        int TiempoMinutos { get; }
        string ToString();
    }
    public interface IGestorRecetas
    {
        List<Receta> RecetasDisponibles { get; set; }
        void AgregarReceta(Receta receta);
        void EliminarReceta(Receta receta);
        void EliminarPorIndice(int indice);
        List<Receta> BuscarPorNombre(string nombre);
        void LimpiarCatalogo();
        void QuickSort(List<Receta> recetas);
        List<Receta> MergeSort(List<Receta> recetas);
        int BusquedaBinaria(string nombre);
    }
    public interface IExportador
    {
        void ExportarAtxt(Usuario usuario, string rutaArchvo);
    }



}