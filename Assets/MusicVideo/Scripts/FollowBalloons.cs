using UnityEngine;

public class FollowBalloons : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");

        Vector3 positionSum = Vector3.zero;

        foreach(GameObject balloon in balloons)
        {
            positionSum += balloon.transform.position;
        }

        Vector3 targetPosition = positionSum / balloons.Length;

        transform.position = new Vector3(targetPosition.x, targetPosition.y, -30);
    }
}
