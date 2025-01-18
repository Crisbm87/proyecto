using System;

// Define the Student class
public class Student
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }
    public double NotaDefinitiva { get; set; }
    public Student Next { get; set; }

    public Student(string cedula, string nombre, string apellido, string correo, double nota)
    {
        Cedula = cedula;
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
        NotaDefinitiva = nota;
        Next = null;
    }
}

public class StudentList
{
    private Student headApproved;
    private Student headFailed;
    private int approvedCount;
    private int failedCount;

    public StudentList()
    {
        headApproved = null;
        headFailed = null;
        approvedCount = 0;
        failedCount = 0;
    }

    public void AddStudent(string cedula, string nombre, string apellido, string correo, double nota)
    {
        var newStudent = new Student(cedula, nombre, apellido, correo, nota);
        if (nota >= 6)
        {
            newStudent.Next = headApproved;
            headApproved = newStudent;
            approvedCount++;
        }
        else
        {
            if (headFailed == null)
            {
                headFailed = newStudent;
            }
            else
            {
                var current = headFailed;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newStudent;
            }
            failedCount++;
        }
    }

    public Student SearchStudent(string cedula)
    {
        var current = headApproved;
        while (current != null)
        {
            if (current.Cedula == cedula)
                return current;
            current = current.Next;
        }

        current = headFailed;
        while (current != null)
        {
            if (current.Cedula == cedula)
                return current;
            current = current.Next;
        }

        return null;
    }

    public bool DeleteStudent(string cedula)
    {
        if (DeleteFromList(ref headApproved, ref approvedCount, cedula))
            return true;

        if (DeleteFromList(ref headFailed, ref failedCount, cedula))
            return true;

        return false;
    }

    private bool DeleteFromList(ref Student head, ref int count, string cedula)
    {
        Student current = head;
        Student previous = null;

        while (current != null)
        {
            if (current.Cedula == cedula)
            {
                if (previous == null)
                    head = current.Next;
                else
                    previous.Next = current.Next;

                count--;
                return true;
            }

            previous = current;
            current = current.Next;
        }
        return false;
    }

    public int GetApprovedCount() => approvedCount;

    public int GetFailedCount() => failedCount;

    public void PrintAllStudents()
    {
        Console.WriteLine("Approved Students:");
        PrintList(headApproved);

        Console.WriteLine("Failed Students:");
        PrintList(headFailed);
    }

    private void PrintList(Student head)
    {
        var current = head;
        while (current != null)
        {
            Console.WriteLine($"Cédula: {current.Cedula}, Nombre: {current.Nombre}, Apellido: {current.Apellido}, Correo: {current.Correo}, Nota: {current.NotaDefinitiva}");
            current = current.Next;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        StudentList studentList = new StudentList();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Buscar estudiante por cédula");
            Console.WriteLine("3. Eliminar estudiante");
            Console.WriteLine("4. Mostrar total de estudiantes aprobados y reprobados");
            Console.WriteLine("5. Mostrar todos los estudiantes");
            Console.WriteLine("6. Salir");

            Console.Write("Seleccione una opción: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Ingrese la cédula: ");
                    string cedula = Console.ReadLine();
                    Console.Write("Ingrese el nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el apellido: ");
                    string apellido = Console.ReadLine();
                    Console.Write("Ingrese el correo: ");
                    string correo = Console.ReadLine();
                    Console.Write("Ingrese la nota definitiva: ");
                    if (double.TryParse(Console.ReadLine(), out double nota))
                    {
                        studentList.AddStudent(cedula, nombre, apellido, correo, nota);
                        Console.WriteLine("Estudiante agregado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Nota inválida.");
                    }
                    break;

                case "2":
                    Console.Write("Ingrese la cédula del estudiante a buscar: ");
                    string searchCedula = Console.ReadLine();
                    var student = studentList.SearchStudent(searchCedula);
                    if (student != null)
                    {
                        Console.WriteLine($"Estudiante encontrado: Cédula: {student.Cedula}, Nombre: {student.Nombre}, Apellido: {student.Apellido}, Correo: {student.Correo}, Nota: {student.NotaDefinitiva}");
                    }
                    else
                    {
                        Console.WriteLine("Estudiante no encontrado.");
                    }
                    break;

                case "3":
                    Console.Write("Ingrese la cédula del estudiante a eliminar: ");
                    string deleteCedula = Console.ReadLine();
                    if (studentList.DeleteStudent(deleteCedula))
                    {
                        Console.WriteLine("Estudiante eliminado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Estudiante no encontrado.");
                    }
                    break;

                case "4":
                    Console.WriteLine($"Total estudiantes aprobados: {studentList.GetApprovedCount()}");
                    Console.WriteLine($"Total estudiantes reprobados: {studentList.GetFailedCount()}");
                    break;

                case "5":
                    studentList.PrintAllStudents();
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}
