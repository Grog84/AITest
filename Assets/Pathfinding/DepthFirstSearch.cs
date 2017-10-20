using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Pathfinding
{
    public class DepthFirstSearch : MonoBehaviour
    {

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

            Stack<Node> stack = new Stack<Node>();
            stack.Push(startNode);

            List<Node> visitedNodes = new List<Node>();

            while (stack.Count > 0)
            {
                Node n = stack.Pop();
                visitedNodes.Add(n);

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
                    if (!visitedNodes.Contains(neigh) && !stack.Contains(neigh))
                    {
                        Edge e = graphMaker.GetEdge(n, neigh);
                        e.color = Color.green;
                        yield return new WaitForSeconds(waitTime);

                        stack.Push(neigh);
                    }
                }
            }

            yield return null;
        }
    }
}
