using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Figura : MonoBehaviour
{
    public COLORES colorFigura;
    public GestureRecognizer.GesturePattern pattern;
    public SpriteRenderer spriteFondo, spriteGesto;
    public float velocidadHorizontal;

    public UnityEvent leAchunto;

    [HideInInspector] public float id;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * velocidadHorizontal * Time.deltaTime);
    }

    public void Destruir()
    {
        velocidadHorizontal = 0;
        GameManager.instance.QuitarDeLista(this);
        Destroy(gameObject);
    }

    public void LeAchunto()
    {
        leAchunto.Invoke();
        velocidadHorizontal = 0;
        print("LE ACHUNTO!");
        Destroy(gameObject);
    }
}
