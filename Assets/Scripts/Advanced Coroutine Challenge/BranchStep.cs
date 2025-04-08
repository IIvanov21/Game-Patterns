using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchStep: IEventStep
{
    private Func<bool> condition;
    private List<IEventStep> trueBranch;
    private List<IEventStep> falseBranch;

    public BranchStep(Func<bool> condition, List<IEventStep> trueBranch,List<IEventStep> falseBranch)
    {
        this.condition = condition;
        this.trueBranch = trueBranch;
        this.falseBranch = falseBranch;
    }

    public IEnumerator Execute(EventSequencer context)
    {
        var branch = condition() ? trueBranch : falseBranch;
        foreach (var step in branch)
        {
            if (context.IsInterrupted) yield break;
            yield return step.Execute(context);
        }
    }
}
