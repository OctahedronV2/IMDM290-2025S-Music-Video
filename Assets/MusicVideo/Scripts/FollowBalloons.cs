using UnityEngine;

public class FollowBalloons : MonoBehaviour
{

    public float zoomDistance = 15f;
    public float smoothingFactor = 15f;

    private Vector3 targetPosition;

    private void Start()
    {
        GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");

        Vector3 positionSum = Vector3.zero;

        foreach (GameObject balloon in balloons)
        {
            positionSum += balloon.transform.position;
        }

        Vector3 proxyTarget = positionSum / balloons.Length;
        targetPosition = new Vector3(proxyTarget.x, proxyTarget.y, -zoomDistance);

        transform.position = targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");

        Vector3 positionSum = Vector3.zero;

        foreach(GameObject balloon in balloons)
        {
            positionSum += balloon.transform.position;
        }

        Vector3 proxyTarget = positionSum / balloons.Length;
        targetPosition = new Vector3(proxyTarget.x, proxyTarget.y, -zoomDistance);

        if (balloons.Length == 0) targetPosition = new Vector3(transform.position.x, transform.position.y - 0.01f, -zoomDistance);

        float distanceToTargetPos = Vector3.Distance(transform.position, targetPosition);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, distanceToTargetPos / smoothingFactor);
    }
}
