using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    void Update()
    {
        Destroy(gameObject, 3f); //Destroys the clone for the peformance
    }
}
