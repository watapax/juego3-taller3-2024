using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LibreriaDeFiguras
{
    public string nombre;
    public COLORES color;
    public Color colorFigura;
    public List<Figura> figuras = new List<Figura>();

    public void QuitarDeLista(float _id)
    {
        for (int i = 0; i < figuras.Count; i++)
        {
            if(figuras[i].id == _id)
            {
                figuras.RemoveAt(i);
                break;
            }
        }
    }

    public bool EncontrarFigura(GestureRecognizer.GesturePattern pattern)
    {
        var figura = figuras.Find(f => f.pattern == pattern);
        if(figura!= null)
        {
            figura.LeAchunto();
            figuras.Remove(figura);
            return true;
        }
        return false;
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public List<LibreriaDeFiguras> libreriaDeFiguras = new List<LibreriaDeFiguras>();


 

    private void Awake()
    {
        instance = this;
    }
    public void AgregarALista(Figura _figura)
    {
        for (int i = 0; i < libreriaDeFiguras.Count; i++)
        {
            if(libreriaDeFiguras[i].color == _figura.colorFigura)
            {
                libreriaDeFiguras[i].figuras.Add(_figura);
                break;
            }
        }
    }

    public void QuitarDeLista(Figura _figura)
    {
        for (int i = 0; i < libreriaDeFiguras.Count; i++)
        {
            if (libreriaDeFiguras[i].color == _figura.colorFigura)
            {
                libreriaDeFiguras[i].QuitarDeLista(_figura.id);
            }
        }
    }

    public bool BuscarEnLibreria(COLORES colorFigura, GestureRecognizer.GesturePattern pattern)
    {
        for (int i = 0; i < libreriaDeFiguras.Count; i++)
        {
            if (libreriaDeFiguras[i].color == colorFigura)
            {
                if (libreriaDeFiguras[i].EncontrarFigura(pattern))
                {
                    return true;
                }

            }
        }
        return false;
    }



}
