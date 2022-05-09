using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : Node
{
    public BehaviourTree()
    {
        DebugName = "Tree";
    }

    public BehaviourTree(string debugName)
    {
        DebugName = debugName;
    }

    public override Status Process()
    {
        return ChildrenNodes[CurrentChild].Process();
    }
    private  int currentPrintIndentLevel = 0;

    struct NodeLevel
    {
        public int level;
        public Node node;
    }

    public void PrintTree()
    {
        string treePrintout = "";
        Stack<NodeLevel> nodeStack = new Stack<NodeLevel>();
        Node currentNode = this;
        nodeStack.Push(new NodeLevel { level = 0, node = currentNode });

        while (nodeStack.Count != 0)
        {
            NodeLevel nextNode = nodeStack.Pop();
            treePrintout += new string('-', nextNode.level) + nextNode.node.DebugName + "\n";
            for (int i = nextNode.node.ChildrenNodes.Count - 1; i >= 0; i--)
            {
                nodeStack.Push(new NodeLevel { level = nextNode.level + 1, node = nextNode.node.ChildrenNodes[i] });
            }
        }

        Debug.Log(treePrintout);

    }

    string PrintTreeRecursive(Node node)

    {

        var treePrint = new string('-', currentPrintIndentLevel) + node.DebugName + "\n";

        if (ChildrenNodes.Count > 0)

        {

            currentPrintIndentLevel++;

            foreach (var child in node.ChildrenNodes)

            {

                treePrint += PrintTreeRecursive(child);

            }

            currentPrintIndentLevel--;

        }

        return treePrint;

    }
}
