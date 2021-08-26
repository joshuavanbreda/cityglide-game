using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;
    
    private GameObject[] columns;
    private Vector3 objectPoolPosition= new Vector3 (-15f, -25f, 100f);     //A holding position for our unused blocks offscreen.
    private float timeSinceLastSpawned;
    private float spawnXPosition = 211f;                                     //position in the distance to spawn and loop buildings/environment (forward x axis)\
    private float spawnZPosition = 0;                                     //position of the buildings to the side to line up next to the road
    private int currentColumn = 0;

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameEngine.instance.isStarted == true)
        {
            timeSinceLastSpawned += Time.deltaTime;
            if (GameEngine.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
            {
                timeSinceLastSpawned = 0;
                //float spawnYPosition = Random.Range(columnMin, columnMax);
                columns[currentColumn].transform.position = new Vector3(spawnXPosition, 0, spawnZPosition);
                currentColumn++;
                if (currentColumn >= columnPoolSize)
                {
                    currentColumn = 0;
                }
            }
        }
    }
}
