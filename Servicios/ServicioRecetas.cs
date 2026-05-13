using System.IO;

namespace SistemaGestorRecetas.Servicios
{
    public interface IExportador
    {
        void ExportarATxt(Modelos.Usuario usuario, string rutaArchivo);
    }

    public class ExportadorTxt : IExportador
    {
        public void ExportarATxt(Modelos.Usuario usuario, string rutaArchivo)
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                writer.WriteLine($"--- REPORTE DE RECETAS ---");
                writer.WriteLine($"Usuario: {usuario.Nombre}");
                writer.WriteLine($"Fecha: {DateTime.Now}");


                foreach (var libro in usuario.LibrosRecetas)
                {
                    writer.WriteLine($"\nLibro: {libro.Key}");
                    foreach (var receta in libro.Value)
                    {
                        writer.WriteLine($"- {receta.ToString()}");
                    }
                }
            }
        }
    }
}