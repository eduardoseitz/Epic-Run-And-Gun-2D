using UnityEngine;
using UnityEngine.UI;

public class JogadorVida : MonoBehaviour
{
    public int vidas = 3;
    public GerenciadorDeJogo gerenciadorDeJogo;
    public Image imagemBarraDeVida;
    
    private int totalDeVidas;

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
                TomarDano(1);
                break;
            case "Inimigo":
                TomarDano(1);
                break;
            case "Morte":
                TomarDano(vidas);
                break;
        }
    }

    private void TomarDano(int dano)
    {
        vidas = vidas - dano;

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
}
