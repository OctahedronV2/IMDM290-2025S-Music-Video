using System.Collections.Generic;
using UnityEngine;

public class Forcefield : MonoBehaviour
{

    public float forcefieldDistance = 2f;
    public float forcefieldStrength = 1f;
    public float minDistance = 0.2f;

    private List<GameObject> objectsInField;

    private void Start()
    {
        objectsInField = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        objectsInField.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        objectsInField.Remove(other.gameObject);
    }

    private void FixedUpdate()
    {
        foreach(GameObject obj in objectsInField)
        {
            var rb = obj.GetComponent<Rigidbody>();
            if (rb == null) return;

            Vector3 dir = obj.transform.position - transform.position;
            dir.Normalize();

            float distance = Vector3.Distance(transform.position, obj.transform.position);
            float force = forcefieldStrength / Mathf.Max(distance, minDistance);

            rb.AddForce(dir * force);
        }
    }
}
