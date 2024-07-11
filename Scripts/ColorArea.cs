using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum COLORES
{
    ROJO, AMARILLO, AZUL
}

public class ColorArea : MonoBehaviour
{
    public Image imageHp;
    public COLORES colorArea;
    
    public float hp;
    public float maxHp;
    [SerializeField]
    private UnityEvent loHizoBien, loHizoMal;


    public void ModificarHp(int _valor)
    {
        hp += _valor;
        hp = Mathf.Clamp(hp, 0, maxHp);
        imageHp.fillAmount = hp / maxHp;
    }

    public void LoHizoBien()
    {
        print("lo hizo bien");
        loHizoBien.Invoke();
    }
    public void LoHizoMal()
    {
        print("lo hizo mal");
        loHizoMal.Invoke();
    }
}
