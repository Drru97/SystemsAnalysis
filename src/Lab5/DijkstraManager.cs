using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Lab5
{
    public class DijkstraManager
    {
        public Graph Graph { get; private set; }
        public DijkstraParameters Parameters { get; private set; }

        public void InputData()
        {
            Console.WriteLine("Dijkstra algorithm");

            string jsonGraph;
            using (var reader = new StreamReader("graph.json"))
            {
                jsonGraph = reader.ReadToEnd();
            }
            Graph = JsonConvert.DeserializeObject<Graph>(jsonGraph);

            string jsonDijkstraParameters;
            using (var reader = new StreamReader("parameters.json"))
            {
                jsonDijkstraParameters = reader.ReadToEnd();
            }
            Parameters = JsonConvert.DeserializeObject<DijkstraParameters>(jsonDijkstraParameters);
        }

        public void Calculate()
        {
            var path = Dijkstra.CalculatePath(Graph, Parameters.FromVertex, Parameters.ToVertex);

            Console.WriteLine($"Shortest path from {Parameters.FromVertex} to {Parameters.ToVertex}: ");
            foreach (var pathItem in path)
            {
                Console.Write(pathItem != path.Last() ? $"{pathItem} -> " : $"{pathItem}");
            }

            var pathLength = Dijkstra.CalculateLength(Graph, path);
            Console.WriteLine($"\nPath length = {pathLength}");
        }
    }
}
