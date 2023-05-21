using UnityEngine;

public class Maze : MonoBehaviour
{
    public int width = 10;               // Width of the maze in cells
    public int height = 10;              // Height of the maze in cells
    public GameObject wallPrefab;        // Prefab for the wall sprite
    public GameObject floorPrefab;       // Prefab for the floor sprite

    private bool[,] mazeCells;           // Stores the state of each cell in the maze

    private void Start()
    {
        GenerateMaze();
    }

    private void GenerateMaze()
    {
        // Initialize mazeCells array
        mazeCells = new bool[width, height];

        // Generate maze layout
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Randomly set the state of each cell as either a wall or a floor
                bool isWall = Random.Range(0f, 1f) < 0.12;
                mazeCells[x, y] = isWall;

                // Instantiate the corresponding sprite tile based on the cell state
                GameObject tilePrefab = isWall ? wallPrefab : floorPrefab;
                GameObject tile = Instantiate(tilePrefab, new Vector3(x, y, -1f), Quaternion.identity, transform);
            }
        }
    }
}
