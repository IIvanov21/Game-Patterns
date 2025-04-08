using UnityEngine;
using System;
using System.Collections;

public class ActionStep: IEventStep
{
    private Action action;
    
    public ActionStep(Action action)
    {
        this.action = action;
    }

    public IEnumerator Execute(EventSequencer sequencer)
    {
        action?.Invoke();
        yield return null;
    }
}
