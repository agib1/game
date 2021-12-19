using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public Material usedMaterial;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            //removing bloom special effect if powerup is used.
            GameObject parent = gameObject.transform.parent.gameObject;
            
            foreach (Transform child in parent.transform)
            {
                if (child.gameObject.name == "Cube")
                {
                    child.gameObject.GetComponent<MeshRenderer>().material = usedMaterial;
                }
            }

            gameObject.SetActive(false);
        }
        
    }
}
