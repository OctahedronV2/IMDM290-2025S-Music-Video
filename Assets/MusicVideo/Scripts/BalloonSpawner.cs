using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;
    public Color[] balloonColors;

    public GameObject SpawnBalloon()
    {
        var balloon = Instantiate(balloonPrefab);
        var audioFloat = balloon.GetComponent<AudioFloat>();
        balloon.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        audioFloat.ampCutoff = Random.Range(0.25f, 0.7f);

        var rend = balloon.GetComponent<Renderer>();
        rend.material.color = balloonColors[Random.Range(0, balloonColors.Length)];

        return balloon;
    }
}
