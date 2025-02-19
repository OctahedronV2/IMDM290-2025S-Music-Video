using UnityEngine;

public class AudioFloat : MonoBehaviour
{

    public float floatStrength = 5f;
    public float ampCutoff = 0.4f;

    public float randomnessIntensity = 0.1f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        floatStrength += Random.Range(-2f, 2f);
        ampCutoff = Random.Range(0.25f, 0.7f);

        if(ampCutoff <= 0.4f)
        {
            ampCutoff += 0.1f;
        }
    }

    private void Update()
    {
        Debug.Log(AudioSpectrum.audioAmp);


        if(AudioSpectrum.audioAmp > ampCutoff)
        {
            // Incorporate randomness to make each balloon slightly different
            float randomX = Random.Range(-randomnessIntensity, randomnessIntensity);
            float randomY = Random.Range(0, randomnessIntensity);
            float randomZ = Random.Range(-randomnessIntensity, randomnessIntensity);

            float distanceToMaxHeight = 11 - transform.position.y;
            float curStrength = Mathf.Max(0, floatStrength / 10 * distanceToMaxHeight);

            Vector3 forceDirection = new Vector3(randomX, AudioSpectrum.audioAmp * curStrength + randomY, randomZ);
            rb.AddForce(forceDirection, ForceMode.Acceleration);
        }
        
    }
}
