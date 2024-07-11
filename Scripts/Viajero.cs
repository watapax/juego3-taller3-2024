using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viajero : MonoBehaviour
{
    public bool viajando;

    GameObject elClon;
    Vector3 direccionEntrada;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("portal") && !viajando)
        {
            viajando = true;


            transform.parent = collision.transform;
            Vector3 pos = transform.localPosition;
            Vector3 angles = transform.localEulerAngles;
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            transform.parent = null;
            //GetComponent<Collider2D>().enabled = false;

            GameObject clon = Instantiate(this.gameObject);


            clon.transform.parent = collision.GetComponent<ElPortal>().elOtroPortal.transform;
            clon.transform.localPosition = pos;
            clon.transform.localEulerAngles = angles;
            clon.GetComponent<Rigidbody2D>().velocity = velocity;
            elClon = clon;

            direccionEntrada = collision.transform.position - transform.position;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("portal"))
        {
            if (elClon != null)
            {

                Vector3 direccionSalida = collision.transform.position - transform.position;
                float dp = Vector3.Dot(direccionEntrada, direccionSalida);

                if (dp < 0)
                {
                    print("Atraveso el portal");
                    elClon.GetComponent<Movimiento>().ResetearVar();
                    Destroy(gameObject);
                }
                else
                {
                    print("Se devolvio ");
                    ResetearVar();
                    elClon = null;
                }



            }

            print("peo");
            viajando = false;
        }
    }

    public void ResetearVar()
    {
        GetComponent<Collider2D>().enabled = true;
        transform.parent = null;
        viajando = false;
        Destroy(elClon);
        elClon = null;
    }
}
