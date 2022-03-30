using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject playerPrefab;
    public GameObject[] enemyPrefabs;
    const int rows = 10, cols = 10;
    public GameObject[,] grid = new GameObject[rows, cols];
    Vector3 firstCube;
    bool isSafe;
    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
        PlacePlayer();
        PlaceEnemies();
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnGrid()
    {
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
            {
                var cube = Instantiate(cubePrefab, new Vector3(i, j, 0), Quaternion.identity);
                grid[i, j] = cube;
                if (i == 0 && j == 0)
                    firstCube = cube.transform.position;
            }
    }
    private void PlaceEnemies()
    {
        //place enemies on random cubes
        foreach (GameObject enemy in enemyPrefabs)
        {
            int randomX = Random.Range(0, rows-1);
            int randomY = Random.Range(0, cols-1);
            enemy.transform.position = grid[randomX, randomY].transform.position + new Vector3(0, 0, -0.5f);
        }
    }

    private void PlacePlayer()
    {
        //place player on a random cube
        playerPrefab.transform.position = firstCube + new Vector3(0, 0, -0.5f);
    }

    public int NumberOfCubes()
    {
        return grid.Length;
    }


}
