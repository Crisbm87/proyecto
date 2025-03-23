using System;

public class Nodo
{
    public int Dato;
    public Nodo Izquierda;
    public Nodo Derecha;

    public Nodo(int dato)
    {
        Dato = dato;
        Izquierda = null;
        Derecha = null;
    }
}

public class ArbolBinario
{
    public Nodo Raiz;

    public ArbolBinario()
    {
        Raiz = null;
    }

    public void Insertar(int dato)
    {
        Raiz = InsertarRecursivo(Raiz, dato);
    }

    private Nodo InsertarRecursivo(Nodo nodo, int dato)
    {
        if (nodo == null)
        {
            return new Nodo(dato);
        }

        if (dato < nodo.Dato)
        {
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, dato);
        }
        else if (dato > nodo.Dato)
        {
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, dato);
        }

        return nodo;
    }

    public bool Buscar(int dato)
    {
        return BuscarRecursivo(Raiz, dato);
    }

    private bool BuscarRecursivo(Nodo nodo, int dato)
    {
        if (nodo == null)
        {
            return false;
        }

        if (dato == nodo.Dato)
        {
            return true;
        }

        if (dato < nodo.Dato)
        {
            return BuscarRecursivo(nodo.Izquierda, dato);
        }
        else
        {
            return BuscarRecursivo(nodo.Derecha, dato);
        }
    }

    public void Inorden()
    {
        InordenRecursivo(Raiz);
        Console.WriteLine();
    }

    private void InordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            InordenRecursivo(nodo.Izquierda);
            Console.Write(nodo.Dato + " ");
            InordenRecursivo(nodo.Derecha);
        }
    }

    public void Preorden()
    {
        PreordenRecursivo(Raiz);
        Console.WriteLine();
    }

    private void PreordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Dato + " ");
            PreordenRecursivo(nodo.Izquierda);
            PreordenRecursivo(nodo.Derecha);
        }
    }

    public void Postorden()
    {
        PostordenRecursivo(Raiz);
        Console.WriteLine();
    }

    private void PostordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            PostordenRecursivo(nodo.Izquierda);
            PostordenRecursivo(nodo.Derecha);
            Console.Write(nodo.Dato + " ");
        }
    }

    public int Altura()
    {
        return AlturaRecursiva(Raiz);
    }

    private int AlturaRecursiva(Nodo nodo)
    {
        if (nodo == null)
        {
            return 0;
        }

        int alturaIzquierda = AlturaRecursiva(nodo.Izquierda);
        int alturaDerecha = AlturaRecursiva(nodo.Derecha);

        return Math.Max(alturaIzquierda, alturaDerecha) + 1;
    }

    public int NodosHoja()
    {
        return NodosHojaRecursivo(Raiz);
    }

    private int NodosHojaRecursivo(Nodo nodo)
    {
        if (nodo == null)
        {
            return 0;
        }

        if (nodo.Izquierda == null && nodo.Derecha == null)
        {
            return 1;
        }

        return NodosHojaRecursivo(nodo.Izquierda) + NodosHojaRecursivo(nodo.Derecha);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion = 0;

        while (opcion != 8)
        {
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Inorden");
            Console.WriteLine("4. Preorden");
            Console.WriteLine("5. Postorden");
            Console.WriteLine("6. Altura");
            Console.WriteLine("7. Nodos Hoja");
            Console.WriteLine("8. Salir");

            Console.Write("Elige una opción: ");
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingresa el dato a insertar: ");
                        if (int.TryParse(Console.ReadLine(), out int datoInsertar))
                        {
                            arbol.Insertar(datoInsertar);
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida.");
                        }
                        break;
                    case 2:
                        Console.Write("Ingresa el dato a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int datoBuscar))
                        {
                            Console.WriteLine("Resultado de la búsqueda: " + arbol.Buscar(datoBuscar));
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida.");
                        }
                        break;
                    case 3:
                        Console.Write("Recorrido Inorden: ");
                        arbol.Inorden();
                        break;
                    case 4:
                        Console.Write("Recorrido Preorden: ");
                        arbol.Preorden();
                        break;
                    case 5:
                        Console.Write("Recorrido Postorden: ");
                        arbol.Postorden();
                        break;
                    case 6:
                        Console.WriteLine("Altura del árbol: " + arbol.Altura());
                        break;
                    case 7:
                        Console.WriteLine("Número de nodos hoja: " + arbol.NodosHoja());
                        break;
                    case 8:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }
    }
}
