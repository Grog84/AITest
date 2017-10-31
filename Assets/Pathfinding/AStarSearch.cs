using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Pathfinding
{

    public class AStarSearch : MonoBehaviour {

        public Node startNode;
        public Node endNode;

        private GraphMaker graphMaker;

        void Start()
        {
            graphMaker = FindObjectOfType<GraphMaker>();

            var nodes = graphMaker.nodes;
            var edges = graphMaker.edges;

            List<Node> bestPath = new List<Node>();

            StartCoroutine(Search(nodes, edges, startNode, endNode, bestPath));

        }

        public IEnumerator Search(List<Node> nodes, List<Edge> edges, Node startNode, Node endNode, List<Node> bestPath)
        {
            float waitTime = 0.01f;

            List<Node> openSet = new List<Node>();
            List<Node> closedSet = new List<Node>();

            startNode.cost = 0;
            startNode.heuristic = Vector2.Distance(startNode.transform.position, endNode.transform.position);

            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node n = GetBestNode(openSet, true);
                openSet.Remove(n);
                closedSet.Add(n);

                n.color = Color.red;
                yield return new WaitForSeconds(waitTime);

                if (n == endNode)
                {
                    Debug.Log("We found the end node!");
                    break;
                }

                List<Node> neighs = graphMaker.GetNeighbours(n);
                foreach (var neigh in neighs)
                {
                    if (!closedSet.Contains(neigh) && !openSet.Contains(neigh))
                    {
                        Edge e = graphMaker.GetEdge(n, neigh);
                        e.color = Color.red;
                        yield return new WaitForSeconds(waitTime);

                        neigh.cost = n.cost + Vector2.Distance(neigh.transform.position, n.transform.position);
                        neigh.heuristic = Vector2.Distance(neigh.transform.position, endNode.transform.position);

                        openSet.Add(neigh);
                    }
                }
            }

            Debug.Log("SEARCH FINISHED");

            bestPath.Add(endNode);
            var currentNode = endNode;

            while (currentNode != startNode)
            {
                // Get the neighbours of the current node
                List<Node> neighs = graphMaker.GetNeighbours(currentNode);

                //Find shortest path
                Node bestNeigh = GetBestNode(neighs, false);

                Edge e = graphMaker.GetEdge(currentNode, bestNeigh);

                bestPath.Add(bestNeigh);
                currentNode = bestNeigh;

                currentNode.color = Color.green;
                e.color = Color.green;

                yield return new WaitForSeconds(waitTime);

            }

            bestPath.Reverse();

            yield return null;
        }

        private Node GetBestNode(List<Node> set, bool useHeuristic)
        {
            Node bestNode = null;
            float bestTotal = float.MaxValue;

            foreach (Node n in set)
            {
                var totalCost = useHeuristic ? n.cost + n.heuristic : n.cost; 
                if (totalCost < bestTotal)
                {
                    bestTotal = totalCost;
                    bestNode = n;
                }
            }

            return bestNode;
        }
    }

}
