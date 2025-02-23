using UnityEngine;

public class Pop : MonoBehaviour
{
    public float delay;

    private float timeElapsed;

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed > delay)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
