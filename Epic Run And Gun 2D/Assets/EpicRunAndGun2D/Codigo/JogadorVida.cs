using System;
using UnityEngine;
using UnityEngine.UI;

public class JogadorVida : MonoBehaviour
{
    // Variaveis publicas.
    public int vidas = 5;
    public GerenciadorDeJogo gerenciadorDeJogo;
    public Image imagemBarraDeVida;
    public AudioSource somAoLevarDano;
    public AudioSource somAoGanharVida;
    public Animator animador;
    
    // Variaveis privadas.
    private int totalDeVidas;

    // Este metódo é chamado pela Unity no incio do jogo.
    private void Start()
    {
        totalDeVidas = vidas;
        AtualizarBarraDeVida();
    }

    // Ao colidir com outro objeto 2D.
    private void OnCollisionEnter2D(Collision2D outroObjeto)
    {
        // Checar o tipo de etiqueta no outro objeto.
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

    // Ao colidir com outro objeto 2D do tipo trigger.
    private void OnTriggerEnter2D(Collider2D outroObjeto)
    {
        switch (outroObjeto.gameObject.tag)
        {
            case "Ganhar":
                MudarVida(totalDeVidas);
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
        // Atualize as vidas atuais.
        vidas = Math.Clamp(vidas + dano, 0, totalDeVidas);

        // Atualize a vida na tela.
        AtualizarBarraDeVida();
        
        // Printa no console.
        Debug.Log("Vidas restantes para o " + gameObject.name + ": " + vidas);
        
        // Animar.
        if (animador == true)
        {
            animador.Play("TomarDano");
        }

        // Se as vidas chegarem a zero morra.
        if (vidas == 0)
        {
            Morrer();
        }
        // Se ganhou vida.
        else if (somAoGanharVida == true && Math.Sign(dano) > 0)
        {
            // Tocar som.
            somAoGanharVida.PlayOneShot(somAoGanharVida.clip);
        }
        // Se perdeu vida.
        else if (somAoLevarDano == true && Math.Sign(dano) < 0)
        {
            // Tocar som.
            somAoLevarDano.PlayOneShot(somAoLevarDano.clip);
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
