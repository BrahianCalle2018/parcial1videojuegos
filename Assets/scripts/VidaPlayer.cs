using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public float vida = 102;
    public Image barraDeVida;

    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 102);
        barraDeVida.fillAmount = vida / 102;
        if (vida == 0)
        {
            Destroy(gameObject);
            Application.LoadLevel(0);
        }
    }
    
}
