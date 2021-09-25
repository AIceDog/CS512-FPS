using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 

    private void Update()
    {
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
     {        
         //Wait for 5 secs.
         yield return new WaitForSeconds(4);
 
         gameObject.SetActive(false);
     }

    void OnCollisionEnter(Collision _collision)
    {
        if(_collision.gameObject.layer == 6)
        {
            _collision.gameObject.transform.root.gameObject.SetActive(false);   
        }
        gameObject.SetActive(false);
    }
}
