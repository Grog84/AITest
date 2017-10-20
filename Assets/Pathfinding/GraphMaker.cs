using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Pathfinding
{

    public class GraphMaker : MonoBehaviour
    {
        public List<Node> nodes;
        public List<Edge> edges;

        public float radius = 1;

        void Start()
        {
            nodes = new List<Node>(FindObjectsOfType<Node>());
            edges = new List<Edge>();

            foreach (Node n in nodes)
            {
                foreach (Node other_n in nodes)
                {
                    // Check neighbours based on distance
                    if (other_n == n) continue;

                    if ((n.transform.position - other_n.transform.position).sqrMagnitude < radius * radius)
                    {
                        Edge newEdge = new Edge()
                        {
                            n1 = n,
                            n2 = other_n
                        };

                        if(!edges.Contains(newEdge))
                            edges.Add(newEdge);
                    }
                }
            }

            Debug.Log("Nodes: " + nodes.Count);
            Debug.Log("Edges: " + edges.Count);

        }

        public List<Node> GetNeighbours(Node n)
        {
            List<Node> neighs = new List<Node>();
            foreach (var e in edges)
            {
                if (e.n1 == n) neighs.Add(e.n2);
                else if (e.n2 == n) neighs.Add(e.n1);
            }
            return neighs;
        }

        public Edge GetEdge(Node n1, Node n2)
        {
            foreach (var e in edges)
            {
                if (e.n1 == n1 && e.n2 == n2) return e;
                if (e.n1 == n2 && e.n2 == n1) return e;
            }
            return null;
        }

        void Update ()
        {
            foreach (var edge in edges)
            {
                edge.Draw();
            }
		
	    }
    }

}

