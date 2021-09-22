using System.Collections;
using System.Collections.Generic;
 using UnityEngine.UI;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public Transform EnemyDetect;

    // four crosshair quarter
    public RectTransform CHQuarter1;
    public RectTransform CHQuarter2;
    public RectTransform CHQuarter3;
    public RectTransform CHQuarter4;

    public Image CHImage1;
    public Image CHImage2;
    public Image CHImage3;
    public Image CHImage4;

    private float offset = 20;

    // expansion velocity
    private float Evelocity = 190.0f;
    // shrink velocity
    private float Svelocity = 90.0f;

    // when crosshair over enemy color become bright
    private Color32 brightColor;
    // when crosshair over enemy color become dark
    private Color32 darkColor;

    // get enemy mask
    private int enemyRayMask = 1 << 6;

    private void Start() 
    {
        brightColor = new Color32(0, 255, 61, 255);
        darkColor = new Color32(0, 123, 30, 255);
    }

    private void FixedUpdate() 
    {
        RaycastHit hit;

        // change crosshair color when over enemy
        if (Physics.Raycast(EnemyDetect.position, EnemyDetect.up, out hit, Mathf.Infinity, enemyRayMask))
        {
            CHImage1.color = CHImage2.color = CHImage3.color = CHImage4.color = brightColor;
        }
        else
        {
            CHImage1.color = CHImage2.color = CHImage3.color = CHImage4.color = darkColor;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        { 
            if(offset < 45)
            {
                offset += Time.deltaTime * Evelocity;
                CHQuarter1.localPosition = new Vector3(0, offset, 0);
                CHQuarter2.localPosition = new Vector3(0, -offset, 0);
                CHQuarter3.localPosition = new Vector3(offset, 0, 0);
                CHQuarter4.localPosition = new Vector3(-offset, 0, 0);
            }
        }
        else if(offset > 20)
        {
            offset -= Time.deltaTime * Svelocity;
            CHQuarter1.localPosition = new Vector3(0, offset, 0);
            CHQuarter2.localPosition = new Vector3(0, -offset, 0);
            CHQuarter3.localPosition = new Vector3(offset, 0, 0);
            CHQuarter4.localPosition = new Vector3(-offset, 0, 0);
        }
    }
}
