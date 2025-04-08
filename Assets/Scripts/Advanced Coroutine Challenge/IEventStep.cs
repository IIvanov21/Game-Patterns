using UnityEngine;
using System.Collections;

//This interface allows polymorphism for different types of steps
//Wait, Action, Branch, Chain
public interface IEventStep
{
    IEnumerator Execute(EventSequencer context);
}
