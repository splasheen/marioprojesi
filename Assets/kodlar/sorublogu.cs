using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sorublogu : MonoBehaviour
{
    float ziplamahiz = 20;
    Vector3 baslangicpos;
    public LayerMask lyrp;
    Vector2 isinbaslangic;
    public Sprite sprt;
    public GameObject coin;
    bool ziplayabilirmi;

    private void Start()
    {
        coin.SetActive(false);
        coin.transform.position = transform.position;
        ziplayabilirmi = true;
        isinbaslangic = new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f);
        baslangicpos = transform.position;
    }
    private void Update()
    {
        kontrol();
    }
    void carpti()
    {
        if (ziplayabilirmi)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = sprt;/*
            while (true)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + ziplamahiz * Time.deltaTime);
                if (transform.position.y >= baslangicpos.y + ziplamahiz)
                {
                    break;
                }
            }
            while (true)                    SORU BLOGU ZIPLAMA KODU
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - ziplamahiz * Time.deltaTime);
                if (transform.position.y <= baslangicpos.y)
                {
                    transform.position = baslangicpos;
                    break;
                }
            }*/
            ziplayabilirmi = false;/*
            while (true)                          COÝN ZIPLAMA KODU
            {
                coin.transform.position = new Vector2(coin.transform.position.x,coin.transform.position.y + 3 * Time.deltaTime);
                if(coin.transform.position.y >= baslangicpos.y + 3)
                {
                    coin.SetActive(false);
                    break;
                }
            }*/
        }
    }
    void kontrol()
    {
        RaycastHit2D isin = Physics2D.Raycast(isinbaslangic, Vector2.right, 1, lyrp);
        Color renk = Color.green;
        if (isin.collider != null)
        {
            renk = Color.green;
            carpti();
        }
        if (isin.collider == null)
        {
            renk = Color.red;
        }
        Debug.DrawRay(isinbaslangic, Vector2.right * 1, renk);
    }
}
