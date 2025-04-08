using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainStep : IEventStep
{
    private List<IEventStep> chainedSteps;

    public ChainStep(List<IEventStep> chainedSteps)
    {
        this.chainedSteps = chainedSteps;
    }

    public IEnumerator Execute(EventSequencer context)
    {
        foreach (var step in chainedSteps)
        {
            if (context.IsInterrupted) yield break;
            yield return step.Execute(context);
        }
    }
}

