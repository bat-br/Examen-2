using SistemaGestorRecetas.Interfaces;
using SistemaRecetas.Modelos;
using SistemaGestorRecetas.Gestores;

namespace SistemaGestorRecetas.Servicios
{
    public class ServicioRecetas
    {
        private IGestorRecetas gestor;
        private IExportador exportador;
        private List<Usuario> usuarios;

        public ServicioRecetas(IGestorRecetas gestor, IExportador exportador)
        {
            this.gestor = gestor;
            this.exportador = exportador;
            this.usuarios = new List<Usuario>();
        }

        public Usuario RegistrarUsuario(string nombre)
        {
            // CAMBIO AQUÍ: Usamos el constructor que tienes en tu clase
            Usuario nuevoUsuario = new Usuario(nombre);
            usuarios.Add(nuevoUsuario);
            return nuevoUsuario;
        }

        public Usuario BuscarUsuario(string nombre)
        {
            return usuarios.FirstOrDefault(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public bool EliminarUsuario(string nombre)
        {
            Usuario usuarioAEliminar = BuscarUsuario(nombre);
            if (usuarioAEliminar != null)
            {
                usuarios.Remove(usuarioAEliminar);
                return true;
            }
            return false;
        }

        public int ContarUsuarios()
        {
            return usuarios.Count;
        }

        public void OrdenarCatalogo(string tipo)
        {
            if (tipo.Equals("quick", StringComparison.OrdinalIgnoreCase))
            {
                gestor.QuickSort(gestor.RecetasDisponibles);
                Console.WriteLine("Catálogo ordenado exitosamente usando el método QuickSort.");
            }
            else if (tipo.Equals("merge", StringComparison.OrdinalIgnoreCase))
            {
                gestor.RecetasDisponibles = gestor.MergeSort(gestor.RecetasDisponibles);
                Console.WriteLine("Catálogo ordenado exitosamente usando el método MergeSort.");
            }
            else
            {
                Console.WriteLine("Criterio de ordenamiento no válido. Usa 'quick' o 'merge'.");
            }
        }

        public int OrdenarLibroYCalcularTiempo(Usuario usuario, string nombreLibro)
        {
            int tiempoTotal = 0;

            if (usuario.MisLibros != null && usuario.MisLibros.ContainsKey(nombreLibro))
            {
                var listaRecetas = usuario.MisLibros[nombreLibro];

                listaRecetas = listaRecetas.OrderBy(r => r.TiempoMinutos).ToList();
                usuario.MisLibros[nombreLibro] = listaRecetas;

                foreach (var receta in listaRecetas)
                {
                    tiempoTotal += receta.TiempoMinutos;
                }
            }

            return tiempoTotal;
        }
    }
    public class ExportadorTxt : IExportador
    {
        public void ExportarAtxt(Usuario usuario, string rutaArchvo)
        {
            using (StreamWriter writer = new StreamWriter(rutaArchvo))
            {
                writer.WriteLine($"--- REPORTE DE RECETAS ---");
                writer.WriteLine($"Usuario: {usuario.Nombre}");
                writer.WriteLine($"Fecha: {DateTime.Now}");

                if (usuario.MisLibros != null)
                {
                    foreach (var libro in usuario.MisLibros)
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
}