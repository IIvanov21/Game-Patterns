using UnityEngine;
using System.Collections.Generic;

public class EventSequenceTrigger : MonoBehaviour
{
    private EventSequencer sequencer;
    public GameObject enemy;
    public Light simpleLight;
    public AudioSource audioSource;

    public  int bossHealth = 50;

    private void Start()
    {
        sequencer = GetComponent<EventSequencer>();

        if (sequencer == null)
        {
            Debug.LogError("EventSequencer component missing!");
            return;
        }

        /*var sequence = new List<IEventStep>
        {
            new WaitStep(1f),
            new ActionStep(() => Debug.Log("Step 1")),

            new BranchStep(
                () => Time.time % 2 == 0,
                new List<IEventStep> { new ActionStep(() => Debug.Log("Even branch")) },
                new List<IEventStep> { new ActionStep(() => Debug.Log("Odd branch")) }
            ),

            new ChainStep(new List<IEventStep>
            {
                new WaitStep(0.5f),
                new ActionStep(() => Debug.Log("Chained Step"))
            })
        };*/

        var sequence = new List<IEventStep>
        {
            new ActionStep(()=>
            {
                Instantiate(enemy);
            }),
            new WaitStep(10f),
            new ActionStep(()=>simpleLight.color=Color.cyan),
            new ActionStep(()=>audioSource.Play()),

            new BranchStep(
                () => bossHealth<=50,
                new List<IEventStep> { new ActionStep(() => Debug.Log("Change Attack Pattern")) },
                new List<IEventStep> { new ActionStep(() => Debug.Log("Do nothing")) }
            ),
            new BranchStep(
                () => bossHealth<48,
                new List<IEventStep> { new ChainStep(new List<IEventStep>
                                        {
                                            new WaitStep(0.5f),
                                            new ActionStep(() =>{ Debug.Log("You died!"); sequencer.StopSequence(); })}) },
                new List<IEventStep> { new ActionStep(() => Debug.Log("Do nothing")) }
            ),
            

        };

        sequencer.StartSequence(sequence);
    }
}

