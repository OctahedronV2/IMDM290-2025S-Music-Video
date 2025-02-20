using UnityEngine;

public class FloatAway : MonoBehaviour
{
    public float delay;

    private float timeElapsed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > delay)
        {
            gameObject.tag = "Untagged";
            rb.AddForce(new Vector3(0.2f, 0.8f, 0.4f));
        }
    }
}
