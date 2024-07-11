using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public bool viajando;
    public float speed;
    Vector2 input;

    GameObject elClon;
    Vector3 direccionEntrada;
    
    
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        
    }

    private void FixedUpdate()
    {
        transform.Translate(input * speed * Time.deltaTime, Space.Self);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("portal")&& !viajando)
        {

            viajando = true;
            
            transform.parent = collision.transform;
            Vector3 pos = transform.localPosition;
            Vector3 angles = transform.localEulerAngles;
            transform.parent = null;

            GameObject clon = Instantiate(this.gameObject);
            
            clon.transform.parent = collision.GetComponent<ElPortal>().elOtroPortal.transform;
            clon.transform.localPosition = pos;
            clon.transform.localEulerAngles = angles;
            elClon = clon;

            direccionEntrada = collision.transform.position - transform.position;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("portal"))
        {
            if(elClon != null)
            {

                Vector3 direccionSalida = collision.transform.position - transform.position;
                float dp = Vector3.Dot(direccionEntrada, direccionSalida);

                if(dp < 0)
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
        transform.parent = null;
        viajando = false;
        Destroy(elClon);
        elClon = null;
    }
}
