class Program
{
    static void Hanoi(int n, char from_rod, char to_rod, char aux_rod)
    {
        if (n == 1)
        {
            Console.WriteLine("Move disk 1 from rod " + from_rod + " to rod " + to_rod);
            return;
        }
        Hanoi(n - 1, from_rod, aux_rod, to_rod);
        Console.WriteLine("Move disk " + n + " from rod " + from_rod + " to rod " + to_rod);
        Hanoi(n - 1, aux_rod, to_rod, from_rod);
    }

    static void Main(string[] args)
    {
        int n = 3; // Número de discos
        Hanoi(n, 'A', 'C', 'B'); // A, B y C son los nombres de las torres
    }
}
