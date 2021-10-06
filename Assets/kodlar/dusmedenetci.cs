using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dusmedenetci : MonoBehaviour
{
    public LayerMask lyrp;
    Vector2 isinbaslangic;

    void Start()
    {
        isinbaslangic = new Vector2(transform.position.x-9,transform.position.y + 1);
    }
    void Update()
    {
        kontrol();
    }
    void kontrol()
    {
        RaycastHit2D isin = Physics2D.Raycast(isinbaslangic, Vector2.right, 17, lyrp);
        if (isin.collider != null)
        {
            PlayerPrefs.SetFloat("olmesayisi", PlayerPrefs.GetFloat("olmesayisi") + 1);
            kale.sahnedurum();
        }
        Debug.DrawRay(isinbaslangic, Vector2.right * 17, Color.green);
        if (PlayerPrefs.GetFloat("olmesayisi") >= 3)
        {
            PlayerPrefs.SetFloat("olmesayisi", 0);
            PlayerPrefs.SetFloat("kacincisahne", 0);
            SceneManager.LoadScene("olmeekrani");
        }
    }
}
