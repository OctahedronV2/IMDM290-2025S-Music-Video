using UnityEngine;

public class BalloonAudioFloat : MonoBehaviour
{
    private Rigidbody rb;
    public float liftForce = 2.0f; // Base upward force
    public AudioSource audioSource;
    public float audioSensitivity = 5.0f; // How much the audio affects movement

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Apply constant floating force
        rb.AddForce(Vector3.up * liftForce, ForceMode.Acceleration);

        // Apply audio-based movement
        if (audioSource && audioSource.isPlaying)
        {
            float[] spectrumData = new float[256];
            audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);
            
            float intensity = 0f;
            foreach (float sample in spectrumData)
            {
                intensity += sample;
            }
            
            intensity *= audioSensitivity;

            // Add random movement based on audio intensity
            Vector3 audioForce = new Vector3(
                Random.Range(-intensity, intensity), 
                Random.Range(0, intensity), 
                Random.Range(-intensity, intensity)
            );

            rb.AddForce(audioForce, ForceMode.Acceleration);
        }
    }
}
