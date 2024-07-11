using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFiguras : MonoBehaviour
{
    public bool puedeSpawnear;
    Vector3 spawnPoint;
    public float tiempoDeSpawn;
    public GameObject figuraPrefab;

    public GestureRecognizer.GesturePattern[] pattern;
    float t;

    

    private void Awake()
    {
        spawnPoint = transform.position;
    }

    void Spawner()
    {
        t += Time.deltaTime;

        if (t >= tiempoDeSpawn)
        {
            // CREAR UNA FIGURA
            GameObject figuraObject = Instantiate(figuraPrefab, spawnPoint, Quaternion.identity);
            Figura figuraTemp = figuraObject.GetComponent<Figura>();
            figuraTemp.id = Time.realtimeSinceStartup;

            // asignarle el sprite de la figura y el pattern
            int index = Random.Range(0, pattern.Length);
            figuraTemp.pattern = pattern[index];
            figuraTemp.spriteGesto.sprite = pattern[index].spriteGesture;

            // asigarle el color de la figura y el color del srite 
            int indexLibreria = Random.Range(0, GameManager.instance.libreriaDeFiguras.Count);
            figuraTemp.spriteFondo.color = GameManager.instance.libreriaDeFiguras[indexLibreria].colorFigura;
            figuraTemp.colorFigura = GameManager.instance.libreriaDeFiguras[indexLibreria].color;

            // dejar de spawnear
            t = 0;
        }
    }

    private void Update()
    {
        if(puedeSpawnear)
        {
            Spawner();
        }
    }
}
