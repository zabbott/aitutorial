using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Node
{
    public delegate Status Tick();

    public Tick ProcessMethod;

    public Leaf() { }
    public Leaf(string name, Tick tick)
    {
        DebugName = name;
        ProcessMethod = tick; 
    }
    public override Status Process()
    {

        if (ProcessMethod != null)
        {
         
            var test =  ProcessMethod();
               Debug.Log(DebugName + "is a leaf and it's running" + ProcessMethod.Method.Name + "which is at " +
                test + " so this leaf is at" + test);
            return test;
        }
        else
        {
            return Status.FAILURE;
        }
    }
}
