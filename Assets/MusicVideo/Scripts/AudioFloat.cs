using UnityEngine;

public class AudioFloat : MonoBehaviour
{

    public float floatForce = 1f;
    public Vector3 maxPosition;
    public Vector3 minPosition;

    private Vector3 targetPosition;

    private void Update()
    {
        Debug.Log(AudioSpectrum.audioAmp);

        targetPosition = Vector3.Lerp(minPosition, maxPosition, AudioSpectrum.audioAmp);

        float moveDistance = Vector3.Distance(transform.position, targetPosition) / 360;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveDistance);
    }
}
