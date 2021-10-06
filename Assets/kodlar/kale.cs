using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kale : MonoBehaviour
{
    public LayerMask lyrp;
    Vector2 isinbaslangic;
    private void Update()
    {
        kontrol();
    }
    void kontrol()
    {
        isinbaslangic = new Vector2(transform.position.x+1.5f, transform.position.y+0.4f);
        RaycastHit2D isin = Physics2D.Raycast(isinbaslangic, Vector2.right, 1, lyrp);
        Color renk = Color.green;
        if (isin.collider != null)
        {
            renk = Color.green;
            PlayerPrefs.SetFloat("kacincisahne", PlayerPrefs.GetFloat("kacincisahne") + 1);
            sahnedurum();
        }
        if (isin.collider == null)
        {
            renk = Color.red;
        }
        Debug.DrawRay(isinbaslangic, Vector2.right * (1), renk);
    }
    public static void sahnedurum()
    {
        if (PlayerPrefs.GetFloat("kacincisahne") == 0)
        {
            SceneManager.LoadScene(0);
        }
        if (PlayerPrefs.GetFloat("kacincisahne") == 1)
        {
            SceneManager.LoadScene(1);//SceneManager.LoadScene(PlayerPrefs.GetFloat("kacincisahne")); --> olmuyor
        }
        else if (PlayerPrefs.GetFloat("kacincisahne") == 2)
        {
            SceneManager.LoadScene(2);
        }
        else if (PlayerPrefs.GetFloat("kacincisahne") == 3)
        {
            SceneManager.LoadScene(3);
        }
        else if (PlayerPrefs.GetFloat("kacincisahne") == 4)
        {
            SceneManager.LoadScene(4);
        }
        else if (PlayerPrefs.GetFloat("kacincisahne") == 5)
        {
            PlayerPrefs.SetFloat("kacincisahne",0);
            PlayerPrefs.SetFloat("olmesayisi", 0);
            SceneManager.LoadScene(5);
        }
    }
}
