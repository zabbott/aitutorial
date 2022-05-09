using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    public Selector(string name)
    {
        DebugName = name;
    }
    public override Status Process()
    {
        Status childStatus = ChildrenNodes[CurrentChild].Process();
        Debug.Log(DebugName + "is running" + ChildrenNodes[CurrentChild].DebugName
           + "and it's status is : Status " + childStatus + "so " + DebugName +
           "is at" + childStatus);
        if (childStatus == Status.RUNNING) return Status.RUNNING;
        if (childStatus == Status.SUCCESS)
        {
            CurrentChild = 0; 
            Debug.Log(DebugName + "is running" + ChildrenNodes[CurrentChild].DebugName
            + "and it's status is : Status " + childStatus + "so " + DebugName +
            "is at" + childStatus);
            return Status.SUCCESS;
        }
        CurrentChild++;
        if (CurrentChild >= ChildrenNodes.Count)
        {
            CurrentChild = 0;
            Debug.Log(DebugName + "is running" + ChildrenNodes[CurrentChild].DebugName
           + "and it's status is : Status " + childStatus + "so " + DebugName +
           "has bombed out becasue it's all out of options!");
            return Status.FAILURE;
        }
        Debug.Log(DebugName + "is running" + ChildrenNodes[CurrentChild].DebugName
        + "and it's status is : Status " + childStatus + "so " + DebugName +
        "BUT ITS STILL TRYING!");
        return Status.RUNNING;

    }
}
