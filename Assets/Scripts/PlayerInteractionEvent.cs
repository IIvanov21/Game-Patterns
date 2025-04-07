using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractionEvent : MonoBehaviour
{
    public UnityEvent interactionEvent;

    public void PlayInteraction()
    {
        interactionEvent.Invoke();
    }
}
