using System;
using System.Collections.Generic;
using System.Linq;

namespace EjerciciosListas
{
    public class Curso
    {
        public string Nombre { get; set; }
        public List<string> Asignaturas { get; set; }

        public Curso(string nombre)
        {
            Nombre = nombre;
            Asignaturas = new List<string>();
        }

        public void AgregarAsignatura(string asignatura)
        {
            Asignaturas.Add(asignatura);
        }

        public void MostrarAsignaturas()
        {
            Console.WriteLine($"Asignaturas del curso {Nombre}:");
            foreach (string asignatura in Asignaturas)
            {
                Console.WriteLine($"- {asignatura}");
            }
        }
    }

    public class ManejadorListas
    {
        public List<string> OrdenarPalabras(List<string> palabras)
        {
            return palabras.OrderBy(p => p).ToList();
        }

        public List<int> EliminarDuplicados(List<int> numeros)
        {
            return numeros.Distinct().ToList();
        }

        public int ContarOcurrencias(List<int> numeros, int elemento)
        {
            return numeros.Count(n => n == elemento);
        }

        public List<int> ElementosComunes(List<int> lista1, List<int> lista2)
        {
            return lista1.Intersect(lista2).ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 2:
            Curso miCurso = new Curso("Tercer Semestre Primer Parcial");
            miCurso.AgregarAsignatura("Estructuras de Datos");
            miCurso.AgregarAsignatura("Desarrollo de Aplicaciones Web");
            miCurso.AgregarAsignatura("Caleado Estructurado");
            miCurso.MostrarAsignaturas();

            Console.WriteLine("\n");

            // Ejercicio 5:
            ManejadorListas manejador = new ManejadorListas();
            List<string> palabras = new List<string>() { "Saludos", "Jhon", "McCLane" };
            List<string> palabrasOrdenadas = manejador.OrdenarPalabras(palabras);
            Console.WriteLine("Palabras ordenadas:");
            foreach (string palabra in palabrasOrdenadas)
            {
                Console.WriteLine(palabra);
            }

            Console.WriteLine("\n");

            // Ejercicio 10:
            List<int> numeros = new List<int>() { 8, 4, 4, 7, 9, 9, 3 };
            List<int> numerosSinDuplicados = manejador.EliminarDuplicados(numeros);
            Console.WriteLine("Números sin duplicados:");
            foreach (int numero in numerosSinDuplicados)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine("\n");

            // Ejercicio 14:
            List<int> numeros2 = new List<int>() { 1, 2, 2, 3, 4, 4, 5 };
            int elemento = 2;
            int ocurrencias = manejador.ContarOcurrencias(numeros2, elemento);
            Console.WriteLine($"El elemento {elemento} aparece {ocurrencias} veces en la lista.");

            Console.WriteLine("\n");

            // Ejercicio 18 Elementos Comunes:
            List<int> lista1 = new List<int>() { 20, 22, 24, 26, 30 };
            List<int> lista2 = new List<int>() { 30, 22, 22, 36, 42 };
            List<int> elementosComunes = manejador.ElementosComunes(lista1, lista2);
            Console.WriteLine("Elementos comunes:");
            foreach (int numero in elementosComunes)
            {
                Console.WriteLine(numero);
            }
        }
    }
} 
