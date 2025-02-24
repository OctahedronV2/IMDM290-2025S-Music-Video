using System.Collections.Generic;
using UnityEngine;

public class CloudPlacer : MonoBehaviour
{

    public GameObject[] cloudPrefabs;

    private List<Vector3> spawnedCloudPositions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnedCloudPositions = new List<Vector3>();
        for(int i = 0; i < 750; i++)
        {

            float randomX = Random.Range(-100, 100);
            float randomY = Random.Range(-200, 200);
            float randomZ = Random.Range(8, 35);

            Vector3 cloudPosition = new Vector3(randomX, randomY, randomZ);

            bool validPos = false;

            while(validPos == false)
            {
                validPos = true;

                randomX = Random.Range(-100, 100);
                randomY = Random.Range(-200, 200);
                randomZ = Random.Range(10, 35);

                cloudPosition = new Vector3(randomX, randomY, randomZ);

                foreach (Vector3 pastPos in spawnedCloudPositions)
                {
                    if (Vector3.Distance(pastPos, cloudPosition) <= 12f)
                    {
                        validPos = false;
                    }
                }
            }

            spawnedCloudPositions.Add(cloudPosition);

            int randIndex = Random.Range(0, cloudPrefabs.Length);

            var cloud = Instantiate(cloudPrefabs[randIndex]);
            cloud.transform.position = cloudPosition;
            cloud.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

            float randomYAngle = Random.Range(0f, 360f);
            float randomXAngle = Random.Range(-15f, 15f);

            cloud.transform.rotation = Quaternion.Euler(randomXAngle, randomYAngle, 0);
        }
    }
}
