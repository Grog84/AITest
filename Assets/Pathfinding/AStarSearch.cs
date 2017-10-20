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

            StartCoroutine(Search(nodes, edges, startNode, endNode));

        }

        IEnumerator Search(List<Node> nodes, List<Edge> edges, Node startNode, Node endNode)
        {
            float waitTime = 0.1f;

            List<Node> openSet = new List<Node>();
            List<Node> closedSet = new List<Node>();

            startNode.cost = 0;
            startNode.heuristic = Vector2.Distance(startNode.transform.position, endNode.transform.position);

            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node n = GetBestNode(openSet);
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
                        e.color = Color.green;
                        yield return new WaitForSeconds(waitTime);

                        neigh.cost = n.cost + Vector2.Distance(neigh.transform.position, n.transform.position);
                        neigh.heuristic = Vector2.Distance(neigh.transform.position, endNode.transform.position);

                        openSet.Add(neigh);
                    }
                }
            }

            yield return null;
        }

        private Node GetBestNode(List<Node> set)
        {
            Node bestNode = null;
            float bestTotal = float.MaxValue;

            foreach (Node n in set)
            {
                if (n.cost + n.heuristic < bestTotal)
                {
                    bestTotal = n.cost + n.heuristic;
                    bestNode = n;
                }
            }

            return bestNode;
        }
    }

}
