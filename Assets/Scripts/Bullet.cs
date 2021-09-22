using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Update is called once per frame
    private void Start() 
    {
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
     {        
         //Wait for 5 secs.
         yield return new WaitForSeconds(5);
 
         gameObject.SetActive(false);
     }

    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
