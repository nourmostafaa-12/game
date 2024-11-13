using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        print("Trigger");
        Destroy(gameObject);
    }
}
