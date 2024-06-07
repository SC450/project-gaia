using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollision : MonoBehaviour
{
    void OnTriggerEnter (Collider collider) 
    {
        if (collider.tag == "Collidable") 
        {
            Pathfinder pf = collider.gameObject.GetComponent<Pathfinder>();
            pf.redirectAnimal = true;
        }
    }
}
