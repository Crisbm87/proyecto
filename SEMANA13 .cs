using System;
using System.Collections.Generic;

public class Revista
{
    public string Titulo { get; set; }

    public Revista(string titulo)
    {
        Titulo = titulo;
    }
}

public class CatalogoRevistas
{
    private List<Revista> revistas;

    public CatalogoRevistas()
    {
        revistas = new List<Revista>();
    }

    public void AgregarRevista(Revista revista)
    {
        revistas.Add(revista);
    }

    public bool BuscarRevista(string titulo)
    {
        foreach (var revista in revistas)
        {
            if (revista.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    public void MostrarMenu()
    {
        Console.WriteLine("Catálogo de Revistas");
        Console.WriteLine("1. Buscar revista");
        Console.WriteLine("2. Salir");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CatalogoRevistas catalogo = new CatalogoRevistas();

        // Agregar 10 revistas al catálogo
        catalogo.AgregarRevista(new Revista("National Geographic"));
        catalogo.AgregarRevista(new Revista("Time"));
        cataligo.AgregarRevista(new Revista("Forbes"));
        catalogo.AgregarRevista(new Revista("Vogue"));
        catalogo.AgregarRevista(new Revista("Science"));
        catalogo.AgregarRevista(new Revista("Sports Illustrated"));
        catalogo.AgregarRevista(new Revista("The Economist"));
        catalogo.AgregarRevista(new Revista("Wired"));
        catalogo.AgregarRevista(new Revista("Rolling Stone"));
        catalogo.AgregarRevista(new Revista("People"));

        int opcion;
        do
        {
            catalogo.MostrarMenu();
            Console.Write("Seleccione una opción: ");
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el título de la revista a buscar: ");
                        string tituloBuscar = Console.ReadLine();
                        if (catalogo.BuscarRevista(tituloBuscar))
                        {
                            Console.WriteLine("Revista encontrada.");
                        }
                        else
                        {
                            Console.WriteLine("Revista no encontrada.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        } while (opcion != 2);
    }
}
