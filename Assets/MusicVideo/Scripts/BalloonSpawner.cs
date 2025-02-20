using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;

    public GameObject SpawnBalloon()
    {
        var balloon = Instantiate(balloonPrefab);
        var audioFloat = balloon.GetComponent<AudioFloat>();
        balloon.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        audioFloat.ampCutoff = Random.Range(0.25f, 0.7f);

        return balloon;
    }
}
