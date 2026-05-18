using SistemaGestorRecetas.Interfaces;
using SistemaRecetas.Modelos;
namespace SistemaGestorRecetas.Gestores
{
    public class GestorRecetas : IGestorRecetas
    {
      
        public List<Receta> RecetasDisponibles { get; set; }

        public GestorRecetas()
        {
            RecetasDisponibles = new List<Receta>();
        }

        public void AgregarReceta(Receta receta)
        {
            if (RecetasDisponibles == null) RecetasDisponibles = new List<Receta>();
            RecetasDisponibles.Add(receta);
        }

        public void EliminarReceta(Receta receta)
        {
            RecetasDisponibles.Remove(receta);
        }

        public void EliminarPorIndice(int indice)
        {
            if (indice >= 0 && indice < RecetasDisponibles.Count)
            {
                RecetasDisponibles.RemoveAt(indice);
            }
        }

        public void LimpiarCatalogo()
        {
            RecetasDisponibles?.Clear();
        }

        public int BusquedaBinaria(string nombre)
        {
            RecetasDisponibles = RecetasDisponibles.OrderBy(r => r.Nombre).ToList();
            int inicio = 0;
            int fin = RecetasDisponibles.Count - 1;

            while (inicio <= fin)
            {
                int medio = (inicio + fin) / 2;
                int comparacion = string.Compare(RecetasDisponibles[medio].Nombre, nombre, StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0) return medio;
                if (comparacion < 0) inicio = medio + 1;
                else fin = medio - 1;
            }
            return -1;
        }

        public void QuickSort(List<Receta> recetas)
        {
            if (recetas != null && recetas.Count > 1)
            {
                EjecutarQuickSort(recetas, 0, recetas.Count - 1);
            }
        }

        private void EjecutarQuickSort(List<Receta> recetas, int bajo, int alto)
        {
            if (bajo < alto)
            {
                int p = Particionar(recetas, bajo, alto);
                EjecutarQuickSort(recetas, bajo, p - 1);
                EjecutarQuickSort(recetas, p + 1, alto);
            }
        }

        private int Particionar(List<Receta> recetas, int bajo, int alto)
        {
            int pivote = recetas[alto].TiempoMinutos;
            int i = bajo - 1;
            for (int j = bajo; j < alto; j++)
            {
                if (recetas[j].TiempoMinutos <= pivote)
                {
                    i++;
                    var temp = recetas[i];
                    recetas[i] = recetas[j];
                    recetas[j] = temp;
                }
            }
            var temp2 = recetas[i + 1];
            recetas[i + 1] = recetas[alto];
            recetas[alto] = temp2;
            return i + 1;
        }

        public List<Receta> MergeSort(List<Receta> recetas)
        {
            if (recetas.Count <= 1) return new List<Receta>(recetas);

            int medio = recetas.Count / 2;
            List<Receta> izquierda = MergeSort(recetas.GetRange(0, medio));
            List<Receta> derecha = MergeSort(recetas.GetRange(medio, recetas.Count - medio));

            return CombinarMerge(izquierda, derecha);
        }

        private List<Receta> CombinarMerge(List<Receta> izquierda, List<Receta> derecha)
        {
            List<Receta> resultado = new List<Receta>();
            int i = 0, j = 0;

            while (i < izquierda.Count && j < derecha.Count)
            {
                if (izquierda[i].TiempoMinutos <= derecha[j].TiempoMinutos)
                {
                    resultado.Add(izquierda[i]);
                    i++;
                }
                else
                {
                    resultado.Add(derecha[j]);
                    j++;
                }
            }

            while (i < izquierda.Count) resultado.Add(izquierda[i++]);
            while (j < derecha.Count) resultado.Add(derecha[j++]);

            return resultado;
        }

        public List<Receta> BuscarPorNombre(string nombre)
        {
            List<Receta> sublista = new List<Receta>();

            foreach (Receta receta in RecetasDisponibles)
            {
                if (receta.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    sublista.Add(receta);
                }
            }
            return sublista;
        }
    }
}