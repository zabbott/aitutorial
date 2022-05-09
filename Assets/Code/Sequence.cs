using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sequence : Node
{
    public AudioSource Source;
    public AudioClip Clip;
    public Image MyImage; 
    public void PlayAudioOrEndAudio()
    {
        if (Source.isPlaying)
        {
            Source.Stop(); 
        }
        else
        {
            Source.PlayOneShot(Clip); 
        }
    }

  
    public Sequence(string name)
    {
        DebugName = name;
    }
    public override Status Process()
    {

        Status childStatus = ChildrenNodes[CurrentChild].Process();


        if (childStatus == Status.RUNNING)
        {
            Debug.Log(DebugName + " is running " + ChildrenNodes[CurrentChild].DebugName
             + " and it's status is : Status " + childStatus + " so " + DebugName +
             " is at " + childStatus);
            return Status.RUNNING;
        }
        if (childStatus == Status.FAILURE)
        {
            Debug.Log(DebugName + "is running" + ChildrenNodes[CurrentChild].DebugName
            + "and it's status is : Status " + childStatus + "so " + DebugName +
            "is at RUNNING");
            return childStatus;
        }
        
        CurrentChild++;
        if(CurrentChild >= ChildrenNodes.Count)
        {
            CurrentChild = 0;
            Debug.Log(DebugName + " is running " + ChildrenNodes[CurrentChild].DebugName
         + " and it's status is : Status " + childStatus +   " so " + DebugName +
         " is COMPLETED!!!!!");
            return Status.SUCCESS;
        }
        Debug.Log(DebugName + " is running " + ChildrenNodes[CurrentChild].DebugName
         + " and it's status is : Status " + childStatus + " so " + DebugName +
         " is but the sequence is still RUNNING!!!!! ");
        return Status.RUNNING;
    }
}
