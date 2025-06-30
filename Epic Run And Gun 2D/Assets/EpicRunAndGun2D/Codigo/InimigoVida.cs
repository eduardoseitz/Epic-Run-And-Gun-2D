
using UnityEngine;

public class InimigoVida : MonoBehaviour
{
    // Variaveis publicas.
    public int vidas = 3;
    public AudioSource somAoLevarDano;

    private void OnCollisionEnter2D(Collision2D outroObjeto)
    {
        switch (outroObjeto.gameObject.tag)
        {
            case "Projetil":
                TomarDano();
                break;
            case "Morte":
                Morrer();
                break;
        }
    }

    private void TomarDano()
    {
        vidas = vidas - 1;

        Debug.Log("Vidas restantes para o " + gameObject.name + ": " + vidas);
        
        // Tocar som.
        if (somAoLevarDano == true)
        {
            somAoLevarDano.PlayOneShot(somAoLevarDano.clip);
        }
        
        if (vidas <= 0)
        {
            Morrer();
        }
    }

    private void Morrer()
    {
        Debug.Log(gameObject.name + " morreu!");
        
        Destroy(gameObject);
    }
}
