using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameratakip : MonoBehaviour
{
    /*public GameObject hedef;
    public Vector3 hedefpoz;
    public Vector3 velocity = Vector3.zero;
    public Vector3 kameraOffset;
    public float kamerahiz = 0.2f;
    private void Late Update()
    {
        if (hedef.transform.position.x > -1 && hedef.transform.position.x < 42 && hedef.transform.position.y < -4.42 && hedef.transform.position.y > -5.1)
        {
            hedefpoz = hedef.transform.position + kameraOffset;
            hedefpoz.x = hedef.transform.position.x + 3;
            transform.position = Vector3.SmoothDamp(transform.position, hedefpoz, ref velocity, kamerahiz);
        }
    }*/
    public Transform target;
    public Transform leftBouns;
    public Transform rightBouns;

    public float smootdamptime = 0.15f;
    private float smootdampvelocity = 0;

    private float camwidth, camheight,Levelminx,Levelmaxx;

    private void Start()
    {
        camheight = Camera.main.orthographicSize * 2;
        camwidth = camheight * Camera.main.aspect;

        float leftBounswidht = leftBouns.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
        float rightBounswidht = rightBouns.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;

        Levelminx = leftBouns.position.x + leftBounswidht + (camwidth / 2);
        Levelmaxx = rightBouns.position.x - rightBounswidht - (camwidth / 2);
    }
    private void Update()
    {
        if (target)
        {
            float targetx = Mathf.Max(Levelminx,Mathf.Min(Levelmaxx,target.position.x));

            float x = Mathf.SmoothDamp(transform.position.x,targetx, ref smootdampvelocity,smootdamptime);

            transform.position = new Vector3(x,transform.position.y,transform.position.z);
        }
    }
}
