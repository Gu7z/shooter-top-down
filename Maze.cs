using UnityEngine;

public class Maze : MonoBehaviour {
  public int width = 10;           // Width of the map in cells
  public int height = 10;          // Height of the map in cells
  public GameObject wallPrefab;    // Prefab for the wall sprite
  public GameObject floorPrefab;   // Prefab for the floor sprite
  private Vector3 playerPosition;
  private GameObject MazeParent;

  private GameObject[,] mapTiles;  // 2D array to store the map tiles

  private void Start() {
    playerPosition = GameObject.Find("Player").transform.position;
    MazeParent = GameObject.Find("Maze");
    GenerateMap();
  }

  private void GenerateMap() {
    // Calculate the starting position based on the width and height
    Vector3 startingPosition = transform.position - new Vector3((width - 1) / 2f, (height - 1) / 2f, 0f);

    // Initialize the map tiles array
    mapTiles = new GameObject[width, height];

    // Generate walls around the map borders
    GenerateBorderWalls(startingPosition);

    // Generate inner walls
    GenerateInnerWalls(startingPosition);

    // Generate floors for the entire map
    GenerateFloors(startingPosition);
  }

  private void GenerateBorderWalls(Vector3 startingPosition) {
    for (int x = 0; x < width; x++) {
      for (int y = 0; y < height; y++) {
        // Check if it's a border cell
        if (x == 0 || x == width - 1 || y == 0 || y == height - 1) {
          // Instantiate a wall prefab for border cells
          Vector3 position = startingPosition + new Vector3(x, y, 0f);
          mapTiles[x, y] = Instantiate(wallPrefab, position, Quaternion.identity);
          mapTiles[x, y].transform.parent = MazeParent.transform;
        }
      }
    }
  }

  private void GenerateInnerWalls(Vector3 startingPosition) {
    // Calculate the range of cells to generate walls within the room
    int minX = 1;
    int maxX = width - 1;
    int minY = 1;
    int maxY = height - 1;

    // Generate inner walls within the room
    for (int x = minX; x < maxX; x++) {
      for (int y = minY; y < maxY; y++) {
        // Check if it's not a border cell and randomly generate walls
        if (x > 0 && x < width - 1 && y > 0 && y < height - 1 && Random.value < 0.01f && mapTiles[x, y] == null &&
            mapTiles[x - 1, y] == null && mapTiles[x + 1, y] == null &&
            mapTiles[x, y - 1] == null && mapTiles[x, y + 1] == null &&
            (x != Mathf.RoundToInt(playerPosition.x) || y != Mathf.RoundToInt(playerPosition.y))) {
          // Randomize block size and position within the room
          int blockSizeX = Random.Range(2, 5);
          int blockSizeY = Random.Range(2, 5);
          int blockOffsetX = Random.Range(0, maxX - blockSizeX + 1);
          int blockOffsetY = Random.Range(0, maxY - blockSizeY + 1);

          // Generate walls within the block
          for (int bx = blockOffsetX; bx < blockOffsetX + blockSizeX; bx++) {
            for (int by = blockOffsetY; by < blockOffsetY + blockSizeY; by++) {
              // Instantiate a wall prefab for inner cells with the calculated position
              Vector3 position = startingPosition + new Vector3(bx, by, 0f);
              mapTiles[bx, by] = Instantiate(wallPrefab, position, Quaternion.identity);
              mapTiles[bx, by].transform.parent = MazeParent.transform;
            }
          }
        }
      }
    }
  }

  private void GenerateFloors(Vector3 startingPosition) {
    for (int x = 1; x < width - 1; x++) {
      for (int y = 1; y < height - 1; y++) {
        // Check if it's an empty cell (no wall)
        if (mapTiles[x, y] == null) {
          // Instantiate a floor prefab for empty cells
          Vector3 position = startingPosition + new Vector3(x, y, 0f);
          mapTiles[x, y] = Instantiate(floorPrefab, position, Quaternion.identity);
          mapTiles[x, y].transform.parent = MazeParent.transform;
        }
      }
    }
  }
}
