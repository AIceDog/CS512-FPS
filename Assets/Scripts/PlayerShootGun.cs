using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootGun : MonoBehaviour
{   
    public ParticleSystem shootEffect;
    public AudioSource shootAduio;
    public Transform exitPoint;
    private float timeElapsed = 0;
    private GameObject bullet;
    public Animator playerAnimator;


    void Fire_Update()
    {
        if(Input.GetMouseButton(0))
        {
            playerAnimator.SetBool("Fire", true);
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Walk", false);

            // controll bullets
            bullet = ObjectPool.SharedInstance.GetPooledObject();
            if(bullet != null && timeElapsed > 100)
            {
                bullet.SetActive(true);
                bullet.transform.position = exitPoint.position;
                bullet.transform.rotation = exitPoint.rotation;
                bullet.GetComponent<Rigidbody>().velocity = exitPoint.up * 300; 
                timeElapsed = 0;
                shootEffect.Play();
                shootAduio.Play();
            }
        }
        else
        {
             playerAnimator.SetBool("Fire", false);
        }
        timeElapsed += Time.deltaTime * 1000;
    }

    // Update is called once per frame
    void Update()
    {
        Fire_Update();
    }
}
