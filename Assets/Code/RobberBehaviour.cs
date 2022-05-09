using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobberBehaviour : Agent
{
    public GameObject diamond;
    public GameObject van;
    public GameObject backdoor;
    public GameObject frontdoor;


    [Range(0, 1000)]
    public int money = 800;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        Sequence steal = new Sequence("Steal Sequence ");
        Selector goToDoor = new Selector("Find Door Selector ");
        Leaf goToBackDoor = new Leaf("Go To Backdoor leaf ", GoToBackDoor);
        Leaf goToFrontDoor = new Leaf("Go To Frontdoor leaf ", GoToFrontDoor);
        Leaf goToDiamond = new Leaf("Go To Diamond leaf ", GoToDiamond);
        Leaf hasGotMoney = new Leaf("Has Got Money leaf ", HasMoney);
        Leaf goToVan = new Leaf("Go To Van leaf ", GoToVan);

        Inverter invertMoney = new Inverter("Invert Money");
        invertMoney.AddChild(hasGotMoney);

        goToDoor.AddChild(goToFrontDoor);
        goToDoor.AddChild(goToBackDoor);

        steal.AddChild(invertMoney);
        steal.AddChild(goToDoor);
        steal.AddChild(goToDiamond);

        steal.AddChild(goToVan);
        tree.AddChild(steal);

        tree.PrintTree();

    }

    public Node.Status HasMoney()
    {
        if (money < 500)
            return Node.Status.FAILURE;
        return Node.Status.SUCCESS;
    }

    public Node.Status GoToDiamond()
    {
        Node.Status s = GoToLocation(diamond.transform.position);
        if (s == Node.Status.SUCCESS)
        {
            diamond.transform.parent = this.gameObject.transform;
            diamond.transform.position = new Vector3(0, diamond.transform.position.y + 2, 0);
        }
        return s;
    }

    public Node.Status GoToBackDoor()
    {
        return GoToDoor(backdoor);
    }

    public Node.Status GoToFrontDoor()
    {
        return GoToDoor(frontdoor);
    }

    public Node.Status GoToVan()
    {
        Node.Status s = GoToLocation(van.transform.position);
        if (s == Node.Status.SUCCESS)
        {
            money += 300;
            diamond.SetActive(false);
        }
        return s;
    }

    public Node.Status GoToDoor(GameObject door)
    {
        Node.Status s = GoToLocation(door.transform.position);
        if(s == Node.Status.SUCCESS)
        {
            if (!door.GetComponent<Lock>().IsLocked)
            {
                door.SetActive(false);
                return Node.Status.SUCCESS;
            }
            else
            {
                return Node.Status.FAILURE;

            }
        }
        else
        {
            return s;
        }
       
    }

}
