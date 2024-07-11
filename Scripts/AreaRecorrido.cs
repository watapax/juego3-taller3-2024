using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaRecorrido : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("figura"))
        {
            GameManager.instance.AgregarALista(collision.GetComponent<Figura>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("figura"))
        {
            collision.GetComponent<Figura>().Destruir();
        }
    }
}
