using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeJogo : MonoBehaviour
{
    public GameObject ganharJogoPainel;
    public AudioSource ganharJogoSom;
    public GameObject perderJogoPainel;
    public AudioSource perderJogoSom;
    public GameObject jogoPausadoPainel;

    private void Start()
    {
        ContinuarJogo();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                PausarJogo();
            }
        }
    }

    public void PausarJogo()
    {
        Time.timeScale = 0;

        if (jogoPausadoPainel == true)
        {
            jogoPausadoPainel.SetActive(true);
        }
    }

    public void ContinuarJogo()
    {
        Time.timeScale = 1;
        
        if (jogoPausadoPainel == true)
        {
            jogoPausadoPainel.SetActive(false);
        }
    }

    public void GanharJogo()
    {
        PausarJogo();
        
        if (ganharJogoSom == true)
        {
            ganharJogoSom.Play();
        }
        
        if (ganharJogoPainel == true)
        {
            ganharJogoPainel.SetActive(true);
        }
    }

    public void PerderJogo()
    {
        if (perderJogoPainel == true)
        {
            perderJogoPainel.SetActive(true);
        }
        
        if (perderJogoSom == true)
        {
            perderJogoSom.Play();
        }
        
        Time.timeScale = 0;
    }
}
