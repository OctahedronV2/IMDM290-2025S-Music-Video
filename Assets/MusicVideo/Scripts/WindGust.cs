using UnityEngine;

public class WindGust : MonoBehaviour
{
   public AudioSource audioSource;
    public float[] frequencythresholds = new float[5];
    public float movementForce = 5f; // Base force applied to the balloons
    public float breakPeriod = .0001f; // Time in seconds before switching direction
    private float[] spectrumData = new float[256];
    private bool moveRight = true;
    private float lastSwitchTime;

    void Update()
    {
        AnalyzeAudio();
        ApplyMovement();
        CheckDirectionSwitch();
    }

    void AnalyzeAudio()
    {
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);
    }

    void ApplyMovement()
    {
        GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");
        foreach (GameObject balloon in balloons)
        {
            Rigidbody rb = balloon.GetComponent<Rigidbody>();
            if (rb == null) continue;

            float frequencyValue = spectrumData[5];
            float forceIntensity = 0f;

            if (frequencyValue >= frequencythresholds[0] && frequencyValue < frequencythresholds[1])
                forceIntensity = movementForce * 0.25f;
            else if (frequencyValue >= frequencythresholds[1] && frequencyValue < frequencythresholds[2])
                forceIntensity = movementForce * 0.5f;
            else if (frequencyValue >= frequencythresholds[2] && frequencyValue < frequencythresholds[3])
                forceIntensity = movementForce * 0.75f;
            else if (frequencyValue >= frequencythresholds[3])
                forceIntensity = movementForce;

            Vector3 forceDirection = moveRight ? Vector3.right : Vector3.left;
            rb.AddForce(forceDirection * forceIntensity);
        }
    }

    void CheckDirectionSwitch()
    {
        if (Time.time - lastSwitchTime >= breakPeriod)
        {
            moveRight = !moveRight;
            lastSwitchTime = Time.time;
        }
    }
}
