namespace Lab5
{
    public class Graph
    {
        public Graph(int size)
        {
            Verticles = new int[size, size];
        }

        public int[,] Verticles { get; set; }

        public int VerticlesCount => Verticles.GetLength(0);

        public int this[int point, int weight]
        {
            get => Verticles[point, weight];
            set => Verticles[point, weight] = value;
        }
    }
}
