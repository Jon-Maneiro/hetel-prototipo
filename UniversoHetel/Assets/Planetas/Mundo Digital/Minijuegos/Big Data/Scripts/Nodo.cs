using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //to determine whether the space can be filled with potions or not.
    public bool isUsable;

    public GameObject potion;

    public Node(bool isUsable, GameObject potion)
    {
        this.isUsable = isUsable;
        this.potion = potion;
    }
}