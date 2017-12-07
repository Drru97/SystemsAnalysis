using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    public static class Dijkstra
    {
        public static int CalculateLength(Graph graph, IList<int> path)
        {
            var pathLength = 0;
            for (var i = 0; i < path.Count - 1; i++)
            {
                pathLength += graph[path[i], path[i + 1]];
            }

            return pathLength;
        }

        public static IList<int> CalculatePath(Graph graph, int fromVertex, int toVertex)
        {
            var verticlesCount = graph.VerticlesCount;
            var distance = new int[verticlesCount];
            var used = new bool[verticlesCount];
            var previous = new int?[verticlesCount];

            for (var i = 0; i < verticlesCount; i++)
            {
                distance[i] = int.MaxValue;
            }

            distance[fromVertex] = 0;

            while (true)
            {
                var minDistance = int.MaxValue;
                var minNode = 0;
                for (var i = 0; i < verticlesCount; i++)
                {
                    if (!used[i] && minDistance > distance[i])
                    {
                        minDistance = distance[i];
                        minNode = i;
                    }
                }

                if (minDistance == int.MaxValue)
                {
                    break;
                }

                used[minNode] = true;

                for (var i = 0; i < verticlesCount; i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        var shortestToMinNode = distance[minNode];
                        var distanceToNextNode = graph[minNode, i];

                        var totalDistance = shortestToMinNode + distanceToNextNode;

                        if (totalDistance < distance[i])
                        {
                            distance[i] = totalDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }

            var path = new LinkedList<int>();
            int? currentNode = toVertex;
            while (currentNode != null)
            {
                path.AddFirst(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }

            return path.ToList();
        }
    }
}
