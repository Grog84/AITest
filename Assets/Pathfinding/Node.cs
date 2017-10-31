using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Pathfinding
{
    public class Node : MonoBehaviour
    {

        public Color color = Color.white;

        private SpriteRenderer spriteRenderer;

        // Use this for initialization
        void Start()
        {

            spriteRenderer = GetComponent<SpriteRenderer>();

        }

        // Update is called once per frame
        void Update()
        {
            spriteRenderer.color = color;
        }

        // A* weights
        public float cost = float.MaxValue;
        public float heuristic;

    }
}
