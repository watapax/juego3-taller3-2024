using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public KeyCode botonpausa = KeyCode.Escape;
    public GameObject menuPausa;
    public UnityEvent Esta_pausado, Esta_reanudado;
    private bool estaPausado = false;

    //private PlayerControl playerControl;

    private void Start()
    {
        //playerControl = FindObjectOfType<PlayerControl>();
    }

    void Update()
    {
        if (Input.GetKeyDown(botonpausa))
        {
            if (estaPausado)
            {
                Reanudar();
                Esta_reanudado.Invoke();
            }
            else
            {
                Pausar();
                Esta_pausado.Invoke();
            }
        }
    }

    void Pausar()
    {
        Time.timeScale = 0;
        menuPausa.SetActive(true);
        estaPausado = true;

        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Pause();
        }
    }

    public void Reanudar()
    {
        Time.timeScale = 1;
        menuPausa.SetActive(false);
        estaPausado = false;

        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }
    }

    public void no_freeze_time()
    {
        Time.timeScale = 1;
    }

    public void freeze_time()
    {
        Time.timeScale = 0;
    }
    public void ReiniciarJuego()
    {
        Time.timeScale = 1;

        /*if (playerControl != null)
        {
            playerControl.ResetToCheckpoint();
        }
        */
    }
}
