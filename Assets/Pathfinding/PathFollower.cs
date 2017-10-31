using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Pathfinding;

namespace AI.Movement
{
    public class PathFollower : MonoBehaviour {

        public SeekBehaviour seekBehaviour;
        public AStarSearch aStarSearch;
        public Node startNode, endNode;

        public float nextTargetRadius = 1f;

        List<Node> path;

        Node nextTarget;

        void Start()
        {

            StartCoroutine(FindPath());
  
        }

        IEnumerator FindPath()
        {
            var graphMaker = FindObjectOfType<GraphMaker>();
            var nodes = graphMaker.nodes;
            var edges = graphMaker.edges;
            List<Node> bestPath = new List<Node>();
            yield return aStarSearch.StartCoroutine(aStarSearch.Search(nodes, edges, startNode, endNode, bestPath));
            path = bestPath;
            nextTarget = path[0];
            seekBehaviour.targetTransform = nextTarget.transform;
        }

	    // Update is called once per frame
	    void Update ()
        {
            if (path != null && path.Count > 0)
            {
                var distSqr = Vector2.SqrMagnitude(nextTarget.transform.position - transform.position);
                if (distSqr < nextTargetRadius * nextTargetRadius)
                {
                    path.RemoveAt(0);
                    nextTarget = path[0];
                    seekBehaviour.targetTransform = nextTarget.transform;
                }


            }
	    }
    }

}
