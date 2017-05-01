using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject[] obstaclePrefabs;
    public List<GameObject> xRefs;

    private int lastUsedIndex = 0;

    private void Start()
    {
        Time.timeScale = 2;
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            List<GameObject> curatedRefs = new List<GameObject>();
            foreach (GameObject item in xRefs)
            {
                curatedRefs.Add(item);
            }
            if(lastUsedIndex >= 0) curatedRefs.RemoveAt(lastUsedIndex);
            GameObject spawnedObject = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]);
            int randomLane = Random.Range(0, curatedRefs.Count);
            spawnedObject.transform.position = new Vector3(curatedRefs[randomLane].transform.position.x, transform.position.y, transform.position.z);
            lastUsedIndex = xRefs.IndexOf(curatedRefs[randomLane]);
            yield return new WaitForSeconds(Random.Range(0.6f, 1.75f));
        }
    }
}
