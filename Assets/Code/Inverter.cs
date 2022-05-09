using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node
{
    public Inverter(string name)
    {
        DebugName = name;
    }
    public override Status Process()
    {

        Status childStatus = ChildrenNodes[CurrentChild].Process();


        if (childStatus == Status.RUNNING)
        {       
            return Status.RUNNING;
        }
        if (childStatus == Status.FAILURE)
        {
            return Status.SUCCESS;
        }
        else return Status.FAILURE;
    
    }
}
