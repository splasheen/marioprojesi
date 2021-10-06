using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dusman : MonoBehaviour
{
    Rigidbody2D rgb;
    public LayerMask lyrp;
    public float hiz = 2;
    bool sag = true, shoulddie=false;
    public Collider2D cld;
    Vector2 isinbaslangic,konumkoru;
    public GameObject player;
    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        cld = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (!shoulddie)
        {
            if (sag)
            {
                rgb.velocity = new Vector2(hiz,rgb.velocity.y);
            }
            else
            {
                rgb.velocity = new Vector2(-hiz, rgb.velocity.y);
            }
        }
        CheckCrushed();
        konumkoru = transform.position;
        if (shoulddie)
        {
            transform.position = konumkoru;
        }
    }
    public void Crushed()
    {
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7);//DÜÞMANI ÖLDÜRÜNCE ZIPLAMALI
        shoulddie = true;
        GetComponent<Animator>().SetBool("isCrushed",true);
        rgb.velocity = new Vector2(0,0);
        rgb.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezeAll;
        cld.isTrigger = true;
        Invoke("aftertimedestroy", 5);
    }
    void CheckCrushed()
    {
        isinbaslangic = new Vector2(transform.position.x - 0.4f, transform.position.y + 0.5f);
        RaycastHit2D isin = Physics2D.Raycast(isinbaslangic, Vector2.right, 0.8f, lyrp);
        Color renk = Color.green;
        if (isin.collider != null)
        {
            renk = Color.green;
            Crushed();
        }
        if (isin.collider == null)
        {
            renk = Color.red;
        }
        Debug.DrawRay(isinbaslangic, Vector2.right * (0.8f), renk);
    }
    void yondegis()
    {
        if (sag)
        {
            sag = false;
        }
        else
        {
            sag = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "tup" || collision.gameObject.tag == "Enemy")
        {
            yondegis();
        }
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetFloat("olmesayisi", PlayerPrefs.GetFloat("olmesayisi") + 1);
            kale.sahnedurum();
        }
    }
    void aftertimedestroy()
    {
        Destroy(gameObject);
    }

}
