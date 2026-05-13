using SistemaRecetas.Modelos;

public class GestorRecetas : IGestorRecetas
{
    public List<Receta> CatálogoGlobal { get; set; }

    public void AgregarReceta(Receta receta)
    {
        if (CatálogoGlobal == null) CatálogoGlobal = new List<Receta>();
        CatálogoGlobal.Add(receta);
    }
    public void EliminarReceta(string nombre)
    {
        var receta = CatálogoGlobal.FirstOrDefault(r => r.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (receta != null) CatálogoGlobal.Remove(receta);
    }
    public void limpiarCatálogo()
    {
        CatálogoGlobal?.Clear();
    }

    public int BusquedaBinaria(List<Receta> recetas, string nombre)
    {
        int bajo = 0, alto = recetas.Count - 1;
        while (bajo <= alto)
        {
            int medio = (bajo + alto) / 2;
            int comparacion = string.Compare(recetas[medio].Nombre, nombre, StringComparison.OrdinalIgnoreCase);

            if (comparacion == 0) return medio;
            if (comparacion < 0) bajo = medio + 1;
            else alto = medio - 1;
        }
        return -1;
    }

    public void OrdenarQuickSort(List<Receta> recetas, int bajo, int alto)
    {
        if (bajo < alto)
        {
            int p = Particionar(recetas, bajo, alto);
            OrdenarQuickSort(recetas, bajo, p - 1);
            OrdenarQuickSort(recetas, p + 1, alto);
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
}