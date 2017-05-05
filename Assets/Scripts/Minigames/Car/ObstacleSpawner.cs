using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject[] obstaclePool;
    public List<GameObject> xRefs;
    public bool hardMode;
    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 1.5f;
    public float hardModeMinSpawnTime = 0.5f;

    private int lastUsedIndex = 0;
    private int lastSpawnedObstacleAmount;
    private bool spawnObjects;

    private void Start()
    {
        foreach(GameObject obstacle in obstaclePool)
        {
            obstacle.SetActive(false);
        }
        Time.timeScale = 2;
    }

    public void StartObstacleSpawn()
    {
        spawnObjects = true;
        StartCoroutine(SpawnObstacle());
    }

    public void StopObstacleSpawn()
    {
        spawnObjects = false;
    }

    private IEnumerator SpawnObstacle()
    {
        while (spawnObjects)
        {
            List<GameObject> curatedRefs = new List<GameObject>();
            for (int i = 0; i < xRefs.Count; i++)
            {
                if (i == lastUsedIndex)
                {
                    continue;
                }
                curatedRefs.Add(xRefs[i]);
            }
            GameObject[] objectsToSpawn = new GameObject[curatedRefs.Count];
            int obstacleAmount = (!hardMode || lastSpawnedObstacleAmount == xRefs.Count - 1) ? 1 : xRefs.Count;
            obstacleAmount = Random.Range(1, obstacleAmount);
            lastSpawnedObstacleAmount = obstacleAmount;
            int obstaclesToAdd = obstacleAmount;
            foreach (GameObject obstacle in obstaclePool)
            {
                if (!obstacle.activeSelf)
                {
                    obstaclesToAdd--;
                    objectsToSpawn[obstaclesToAdd] = obstacle;
                    if (obstaclesToAdd == 0) break;
                }
            }
            if (objectsToSpawn[0] == null)
            {
                Debug.LogWarning("Not enough pooled objects in the scene. Except a large gap between objects.");
            }
            else
            {
                for (int i = 0; i < obstacleAmount; i++)
                {
                    objectsToSpawn[i].SetActive(true);
                    int randomLane = Random.Range(0, curatedRefs.Count);
                    objectsToSpawn[i].transform.position = new Vector3(curatedRefs[randomLane].transform.position.x, transform.position.y, transform.position.z);
                    lastUsedIndex = xRefs.IndexOf(curatedRefs[randomLane]);
                    curatedRefs.RemoveAt(randomLane);
                }
            }
            float waitTime = Random.Range(!hardMode ? minSpawnTime : hardModeMinSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
