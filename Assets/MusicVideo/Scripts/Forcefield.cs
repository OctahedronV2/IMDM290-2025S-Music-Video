using System.Collections.Generic;
using UnityEngine;

public class Forcefield : MonoBehaviour
{

    List<GameObject> objectsInField;

    private void OnTriggerEnter(Collider other)
    {
        objectsInField.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        objectsInField.Remove(other.gameObject);
    }

    private void Update()
    {
        
    }
}
