using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public enum Status
    {
        SUCCESS,
        RUNNING,
        FAILURE
    }
    public Status NodeStatus;
    public List<Node> ChildrenNodes = new List<Node>();
    public int CurrentChild = 0;
    public string DebugName;


    public Node(string debugName)
    {
        DebugName = debugName;
    }

    public Node()
    {

    }

    public virtual Status Process()
    {

        return ChildrenNodes[CurrentChild].Process();
    }
    public void AddChild(Node node)
    {
        ChildrenNodes.Add(node);
    }

   
}
