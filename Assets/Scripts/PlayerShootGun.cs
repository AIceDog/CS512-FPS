using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootGun : MonoBehaviour
{   
    public Transform exitPoint;
    private float timeElapsed = 0;
    public AudioSource gunshotAudio;    
    private GameObject bullet;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Fire_Update()
    {
        if(Input.GetMouseButton(0))
        {
            playerAnimator.SetBool("Fire", true);
            
            // controll bullets
            bullet = ObjectPool.SharedInstance.GetPooledObject();
            if(bullet != null && timeElapsed > 100)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.GetComponent<Rigidbody>().velocity = transform.up * 100;
                bullet.SetActive(true);
                timeElapsed = 0;
                gunshotAudio.Play();
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
