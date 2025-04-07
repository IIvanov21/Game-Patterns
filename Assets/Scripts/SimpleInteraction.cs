using UnityEngine;
using UnityEngine.Events;

public class SimpleInteraction : MonoBehaviour
{
    public string objectName;
    public UnityEvent triggerEnter;
    public UnityEvent triggerExit;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(objectName))
        {
            triggerEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(objectName))
        {
            triggerExit?.Invoke();
        }
    }
}
