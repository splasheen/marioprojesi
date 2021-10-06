using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rg;
    bool yerdemibool;
    float hiz = 7;
    float ziplamahiz = 21;
    Vector2 lazer;
    public LayerMask lyr;
    Animator animasyoncu;
    bool soldancarpiyor, sagdancarpiyor;

    private void Start()
    {
        yerdemibool = true;
        soldancarpiyor = false;
        sagdancarpiyor = false;
        rg = GetComponent<Rigidbody2D>();
        animasyoncu = GetComponent<Animator>();
        animasyoncu.SetBool("Ground",true);
        animasyoncu.SetBool("isJumping", false);
        animasyoncu.SetBool("isRunning", false);
    }
    void Update()
    {
        gitmek();
        durumyoneticisi();
        yerdemi();
        isinlar();
    }

    void gitmek()
    {
            if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !soldancarpiyor)
            {
                rg.velocity = new Vector2(-hiz,rg.velocity.y);
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
            else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !sagdancarpiyor)
            {
                rg.velocity = new Vector2(hiz, rg.velocity.y);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                rg.velocity = new Vector2(0,rg.velocity.y);
            }
        if (Input.GetKeyDown(KeyCode.Space) && yerdemibool)
        {
            yerdemibool = false;
            rg.AddForce(Vector2.up * ziplamahiz, ForceMode2D.Impulse);
            animasyoncu.SetBool("isJumping",true);
            animasyoncu.SetBool("Ground", false);
            animasyoncu.SetBool("isRunning", false);
        }
    }
    void durumyoneticisi()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && yerdemibool)
        {
            animasyoncu.SetBool("Ground", true);
            animasyoncu.SetBool("isRunning", false);
            animasyoncu.SetBool("isJumping", false);
        }
        if (Input.GetAxisRaw("Horizontal") != 0 && yerdemibool)
        {
            animasyoncu.SetBool("isRunning", true);
            animasyoncu.SetBool("Ground", false);
            animasyoncu.SetBool("isJumping", false);
        }
        if (!yerdemibool)
        {
            animasyoncu.SetBool("isJumping", true);
            animasyoncu.SetBool("Ground", false);
            animasyoncu.SetBool("isRunning", false);
        }
    }
    void yerdemi()
    {
        lazer = new Vector2(transform.position.x - 0.4f,transform.position.y - 1.1f);
        RaycastHit2D isin = Physics2D.Raycast(lazer,Vector2.right,0.9f, lyr);
        if(isin.collider != null)
        {
            yerdemibool = true;
        }
        if (isin.collider == null)
        {
            yerdemibool = false;
        }
        Debug.DrawRay(lazer, Vector2.right * (0.9f),Color.green);
    }
    void isinlar()
    {
        //sag taraf
        lazer = new Vector2(transform.position.x + 0.5f, transform.position.y + 0.9f);
        RaycastHit2D isin = Physics2D.Raycast(lazer, Vector2.down, 1.9f, lyr);
        if (isin.collider != null)
        {
            sagdancarpiyor = true;
        }
        if (isin.collider == null)
        {
            sagdancarpiyor = false;
        }
        Debug.DrawRay(lazer, Vector2.down * 1.9f, Color.green);

        //sol taraf
        lazer = new Vector2(transform.position.x - 0.5f, transform.position.y + 0.9f);
        isin = Physics2D.Raycast(lazer, Vector2.down, 1.9f, lyr);
        if (isin.collider != null)
        {
            soldancarpiyor = true;
        }
        if (isin.collider == null)
        {
            soldancarpiyor = false;
        }
        Debug.DrawRay(lazer, Vector2.down * 1.9f, Color.green);
    }
}
