using System;
using UnityEngine;
using UnityEngine.UI;

public class JogadorVida : MonoBehaviour
{
    // Variaveis publicas.
    public int vidas = 5;
    public GerenciadorDeJogo gerenciadorDeJogo;
    public Image imagemBarraDeVida;
    
    // Variaveis privadas.
    private int totalDeVidas;

    // Este metódo é chamado pela Unity no incio do jogo.
    private void Start()
    {
        totalDeVidas = vidas;
        AtualizarBarraDeVida();
    }

    private void OnCollisionEnter2D(Collision2D outroObjeto)
    {
        switch (outroObjeto.gameObject.tag)
        {
            case "Projetil":
                MudarVida(-1);
                break;
            case "Inimigo":
                MudarVida(-1);
                break;
            case "Morte":
                MudarVida(-vidas);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D outroObjeto)
    {
        switch (outroObjeto.gameObject.tag)
        {
            case "Ganhar":
                Ganhar();
                break;
            case "Vida":
                Destroy(outroObjeto.gameObject);
                MudarVida(+1);
                break;
        }
    }

    private void MudarVida(int dano)
    {
        vidas = vidas + dano;

        AtualizarBarraDeVida();
        
        Debug.Log("Vidas restantes para o " + gameObject.name + ": " + vidas);
        
        if (vidas <= 0)
        {
            Morrer();
        }
    }

    private void AtualizarBarraDeVida()
    {
        if (imagemBarraDeVida == true)
        {
            imagemBarraDeVida.fillAmount = (float)vidas / totalDeVidas;
        }
    }

    private void Morrer()
    {   
        Debug.Log(gameObject.name + " morreu!");
        
        if (gerenciadorDeJogo == true)
        {
            gerenciadorDeJogo.PerderJogo();
        }
        
        gameObject.SetActive(false);
    }

    private void Ganhar()
    {
        Debug.Log(gameObject.name + " ganhou!");
        
        if (gerenciadorDeJogo == true)
        {
            gerenciadorDeJogo.GanharJogo();
        }
    }
}
