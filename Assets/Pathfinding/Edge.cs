using UnityEngine;

namespace AI.Pathfinding
{
    public class Edge
    {
        public Node n1;
        public Node n2;

        public override bool Equals(object obj)
        {
            var otherEdge = (Edge)obj;
            if (otherEdge == null) return false;

            return n1 == otherEdge.n1 && n2 == otherEdge.n2
                || n1 == otherEdge.n2 && n2 == otherEdge.n1;
        }

        public Color color = Color.white;
        public void Draw()
        {
            Debug.DrawLine(n1.transform.position, n2.transform.position, color);
        }

    }

}

