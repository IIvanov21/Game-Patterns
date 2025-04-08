using System.Collections;
using UnityEngine;

public class WaitStep: IEventStep
{
    private float waitTime;

    public WaitStep(float time)
    {
        waitTime = time;
    }

    public IEnumerator Execute(EventSequencer context)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
