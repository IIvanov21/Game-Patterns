using UnityEngine;
using UnityEngine.Events;

public class SimpleInteraction : MonoBehaviour
{
    public string objectName;
    public UnityEvent triggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(objectName))
        {
            triggerEnter?.Invoke();
        }
    }
}
