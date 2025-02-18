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


            Vector3 forceDirection = new Vector3(randomX, AudioSpectrum.audioAmp * floatStrength + randomY, randomZ);
            rb.AddForce(forceDirection, ForceMode.Acceleration);
        }
        
    }
}
