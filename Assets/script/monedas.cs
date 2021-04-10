using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monedas : MonoBehaviour
{
    public Conteo conteo;

    void Start()
    {
        conteo = GameObject.FindGameObjectWithTag("Player").GetComponent<Conteo>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            conteo.Puntaje = conteo.Puntaje + 1;
            Destroy(gameObject);
        }
    }

}
