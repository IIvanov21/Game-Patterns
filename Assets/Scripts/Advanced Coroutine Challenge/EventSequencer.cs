using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSequencer : MonoBehaviour
{
    private Coroutine currentSequence;
    private bool isInterrupted = false;
    public bool IsInterrupted => isInterrupted;


    public void StartSequence(List<IEventStep> steps)
    {
        StopSequence();
        isInterrupted = false;
        currentSequence = StartCoroutine(RunSequence(steps));
    }

    public void StopSequence()
    {
        if(currentSequence != null)
        {
            StopCoroutine(currentSequence);
            currentSequence = null;
        }
        isInterrupted = true;
        Debug.Log("Stoping the sequence!");
    }

    private IEnumerator RunSequence(List<IEventStep> steps)
    {
        foreach (var step in steps)
        {
            if(isInterrupted) yield break;
            yield return step.Execute(this);
        }
    }

}
