using UnityEngine;

public class DelayedEntrance : MonoBehaviour
{

    public GameObject followTarget;
    public float enterSpeed = 1f;

    public enum Mode
    {
        Follow,
        Enter,
        Disabled
    }

    public Mode mode;

    // Update is called once per frame
    void Update()
    {
        if (mode == Mode.Follow)
        {
            transform.position = new Vector3(followTarget.transform.position.x + 30, followTarget.transform.position.y + 10, followTarget.transform.position.z + 1);
        }
        else if (mode == Mode.Enter)
        {

            float distance = Vector3.Distance(followTarget.transform.position, transform.position);

            if (distance < 4f)
            {
                tag = "Balloon";
                mode = DelayedEntrance.Mode.Disabled;
            }

            Vector3 dir = followTarget.transform.position - transform.position;

            dir.Normalize();

            GetComponent<Rigidbody>().AddForce(dir * enterSpeed);
        }
    }
}
