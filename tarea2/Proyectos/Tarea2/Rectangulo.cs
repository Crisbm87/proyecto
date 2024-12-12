
using System;

namespace FigurasGeometricas
{
    // Clase base abstracta para representar una figura geométrica
    public abstract class FiguraGeometrica
    {
        // Método abstracto para calcular el área
        public abstract double CalcularArea();

        // Método abstracto para calcular el perímetro
        public abstract double CalcularPerimetro();
    }

    // Clase que representa un círculo
    public class Circulo : FiguraGeometrica
    {
        private double radio;

        // Constructor para inicializar el radio del círculo
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        // Implementación del método abstracto para calcular el área del círculo
        public override double CalcularArea()
        {
            return Math.PI * Math.Pow(radio, 2);
        }

        // Implementación del método abstracto para calcular el perímetro del círculo
        public override double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    // Clase que representa un cuadrado
    public class Cuadrado : FiguraGeometrica
    {
        private double lado;

        // Constructor para inicializar el lado del cuadrado
        public Cuadrado(double lado)
        {
            this.lado = lado;
        }

        // Implementación del método abstracto para calcular el área del cuadrado
        public override double CalcularArea()
        {
            return lado * lado;
        }

        // Implementación del método abstracto para calcular el perímetro del cuadrado
        public override double CalcularPerimetro()
        {
            return 4 * lado;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear un círculo con radio 5
            Circulo miCirculo = new Circulo(5);

            // Crear un cuadrado con lado 3
            Cuadrado miCuadrado = new Cuadrado(3);

            // Calcular y mostrar el área y perímetro del círculo
            Console.WriteLine("Área del círculo: " + miCirculo.CalcularArea());
            Console.WriteLine("Perímetro del círculo: " + miCirculo.CalcularPerimetro());

            // Calcular y mostrar el área y perímetro del cuadrado
            Console.WriteLine("Área del cuadrado: " + miCuadrado.CalcularArea());
            Console.WriteLine("Perímetro del cuadrado: " + miCuadrado.CalcularPerimetro());
        }
    }
}