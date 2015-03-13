using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            var myGraph = new Graph();
            var sourceNode = myGraph.getNode(1);
            var targetNode = myGraph.getNode(5);
            Console.WriteLine(findShortestPath(sourceNode, targetNode, myGraph));
            Console.ReadLine();
        }

        static int findShortestPath(Node sourceNode, Node targetNode, Graph graph)
        {
            Dictionary<Node, int> nodeDistances = new Dictionary<Node, int>();
            List<Node> visitedNodes = new List<Node>();

            //1) Assign to every node a tentative distance value: set it to zero for our initial node and to infinity for all other nodes.
            graph.nodes.ToList().ForEach(x => nodeDistances.Add(x,int.MaxValue));
            nodeDistances[sourceNode] = 0;

            //2) Set the initial node as current. Mark all other nodes unvisited. Create a set of all the unvisited nodes called the unvisited set.
            visitedNodes.Add(sourceNode);

            djikstra(sourceNode, targetNode, nodeDistances, visitedNodes);
           
            return nodeDistances[targetNode];
        }

        private static void djikstra(Node currentNode, Node targetNode, Dictionary<Node,int> nodeDistances, List<Node> visitedNodes )
        {
            //3) For the current node, consider all of its unvisited neighbors and calculate their tentative distances. Compare the newly 
            //   calculated tentative distance to the current assigned value and assign the smaller one. For example, if the current node A is 
            //   marked with a distance of 6, and the edge connecting it with a neighbor B has length 2, then the distance to B (through A) 
            //   will be 6 + 2 = 8. If B was previously marked with a distance greater than 8 then change it to 8. Otherwise, keep the current value.            
            foreach (var neighborNode in currentNode.neighbors)
            {
                if (visitedNodes.FirstOrDefault(x => x.id == neighborNode.Item1.id) == null)
                {
                    int currentDistance = nodeDistances[neighborNode.Item1];
                    int tentativeDistance = nodeDistances[currentNode] + neighborNode.Item2;
                    if (tentativeDistance < currentDistance )
                        nodeDistances[neighborNode.Item1] = tentativeDistance;
                }
            }

            //4) When we are done considering all of the neighbors of the current node, mark the current node as visited and remove 
            //   it from the unvisited set. A visited node will never be checked again.
            visitedNodes.Add(currentNode);

            //5) If the destination node has been marked visited (when planning a route between two specific nodes) or if the smallest tentative 
            //   distance among the nodes in the unvisited set is infinity (when planning a complete traversal; occurs when there is no connection 
            //   between the initial node and remaining unvisited nodes), then stop. The algorithm has finished.
            if (currentNode == targetNode)
                return;

            //6) Select the unvisited node that is marked with the smallest tentative distance, and set it as the new "current node" then go back to step 3.
            var shortestNode = new Node(-1);
            int shortest = int.MaxValue;
            foreach (var neighborNode in currentNode.neighbors)
            {
                if (visitedNodes.FirstOrDefault(x => x.id == neighborNode.Item1.id) == null && nodeDistances[neighborNode.Item1] < shortest)
                {
                    shortest = nodeDistances[neighborNode.Item1];
                    shortestNode = neighborNode.Item1;
                }
            }
            djikstra(shortestNode, targetNode, nodeDistances, visitedNodes);
        }

    
    }

    class Node
    {
        public Node(int _id)
        {
            id = _id;
            neighbors = new List<Tuple<Node, int>>();
        }

        public void AddNeighbor(Node neighbor, int distance)
        {
            neighbors.Add(new Tuple<Node, int>(neighbor, distance));
        }

        public int id { get; set; }
        public IList<Tuple<Node, int>> neighbors { get; set; }
    }

    class Graph
    {
        public Graph()
        {
            nodes = new List<Node>();
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);

            node1.AddNeighbor(node2, 7);
            node1.AddNeighbor(node3, 9);
            node1.AddNeighbor(node6, 14);

            node2.AddNeighbor(node1, 7);
            node2.AddNeighbor(node3, 10);
            node2.AddNeighbor(node4, 15);

            node3.AddNeighbor(node1, 9);
            node3.AddNeighbor(node2, 10);
            node3.AddNeighbor(node6,2);
            node3.AddNeighbor(node4, 11);

            node4.AddNeighbor(node2, 15);
            node4.AddNeighbor(node3, 11);
            node4.AddNeighbor(node5, 6);

            node5.AddNeighbor(node4,  6);
            node5.AddNeighbor(node6, 9);
            
            node6.AddNeighbor(node1, 14);
            node6.AddNeighbor(node3, 2);
            node6.AddNeighbor(node5, 9);

            nodes.Add(node1);
            nodes.Add(node2);
            nodes.Add(node3);
            nodes.Add(node4);
            nodes.Add(node5);
            nodes.Add(node6);
        }
        public IList<Node> nodes { get; set; }

        public Node getNode(int id)
        {
            return nodes.First(x => x.id == id);
        }
    }
}
