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

    private void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > delay)
        {
            gameObject.tag = "Untagged";
            rb.AddForce(new Vector3(0.6f, 2.4f, 1.2f));
        }
    }
}
