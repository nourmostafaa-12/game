using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    public int numberOfCubes {get;private set;}
    public void CubeCollected()
    {
        numberOfCubes++;
    }
}
