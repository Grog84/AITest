using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AI.PCG
{

    public class DungeonGenerator : MonoBehaviour
    {
        public int mapSize = 11;
        public int step = 2;
        //public int seed = 10;

        public GameObject cellPrefab;

        Cell[,] grid;

        public enum Direction
        {
            N=0,
            E=1,
            S=2,
            W=3
        }

	    void Start ()
        {
            StartCoroutine(GenerateCO());
            //Random.InitState(seed);
            //Random.seed = seed;
            
	    }

        public List<Cell> GetNeighbours(Cell c)
        {
            List<Cell> neighs = new List<Cell>();
            // N
            if (c.y < mapSize - step)
                neighs.Add(grid[c.x, c.y + step]);
            else
                neighs.Add(null);

            // E
            if (c.x < mapSize - step)
                neighs.Add(grid[c.x + step, c.y]);
            else
                neighs.Add(null);

            // S
            if (c.y > step - 1)
                neighs.Add(grid[c.x, c.y- step]);
            else
                neighs.Add(null);

            // W
            if (c.x > step - 1)
                neighs.Add(grid[c.x - step, c.y]);
            else
                neighs.Add(null);

            return neighs;
        }

        public Cell GetNeighbour(Cell c, Direction d)
        {
            return grid[c.x - ((int)d - 2) % 2, c.y - ((int)d - 1) % 2];
        }

        IEnumerator GenerateCO()
        {
            // Create a full dungeon
            grid = new Cell[mapSize, mapSize];
            for (int x = 0; x < mapSize; x++)
            {
                for (int y = 0; y < mapSize; y++)
                {
                    var cellGo = Instantiate(cellPrefab);
                    cellGo.transform.position = new Vector3(x - (mapSize - 1)/2.0f, y - (mapSize - 1) / 2.0f, 0);

                    var cell = cellGo.GetComponent<Cell>();
                    cell.x = x;
                    cell.y = y;
                    grid[x, y] = cell;
                }
            }

            int startX = Random.Range(0, mapSize / 2) * 2;
            int startY = Random.Range(0, mapSize / 2) * 2;

            grid[startX, startY].spriteRenderer.color = Color.blue;
            grid[startX, startY].visited = true;

            Cell currentCell = grid[startX, startY];
            Stack<Cell> backtrackingCells = new Stack<Cell>();
            backtrackingCells.Push(currentCell);
            while (true)
            {
                // Get room cells
                List<Cell> neighs = GetNeighbours(currentCell);

                // Keep unvisited cells
                List<Cell> unvisitedNeighs = neighs.Where(c => c!=null && !c.visited).ToList();

                if (unvisitedNeighs.Count == 0)
                {
                    // Backtracking
                    currentCell = backtrackingCells.Pop();
                }
                else
                {
                    Cell randomNeigh;
                    int randIndex;
                    do
                    {
                        randIndex = Random.Range(0, neighs.Count);
                        randomNeigh = neighs[randIndex];

                    } while (!unvisitedNeighs.Contains(randomNeigh));

                    Direction rndDir = (Direction)randIndex;
                    randomNeigh.spriteRenderer.color = Color.black;
                    randomNeigh.visited = true;

                    Cell wallNeigh = GetNeighbour(currentCell, rndDir);
                    wallNeigh.spriteRenderer.color = Color.black;
                    wallNeigh.visited = true;

                    currentCell = randomNeigh;
                    backtrackingCells.Push(currentCell);
                }

                if (backtrackingCells.Count == 0)
                    break;

                yield return null;
            }

            yield return null;
        }

    }
}

