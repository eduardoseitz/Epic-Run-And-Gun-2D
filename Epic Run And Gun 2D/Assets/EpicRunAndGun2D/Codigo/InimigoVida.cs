using UnityEngine;

public class InimigoVida : MonoBehaviour
{
    // Variaveis publicas.
    public int vidas = 3;
    public AudioSource somAoLevarDano;
    public Animator animador;

    // Ao colidir com outro objeto 2D.
    private void OnCollisionEnter2D(Collision2D outroObjeto)
    {
        // Checar o tipo de etiqueta no outro objeto.
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
        // Diminui as vidas atuais.
        vidas = vidas - 1;

        // Printa no console.
        Debug.Log("Vidas restantes para o " + gameObject.name + ": " + vidas);
        
        // Tocar som.
        if (somAoLevarDano == true)
        {
            somAoLevarDano.PlayOneShot(somAoLevarDano.clip);
        }
        
        // Animar.
        if (animador == true)
        {
            animador.Play("TomarDano");
        }
        
        // Se as vidas chegarem a zero morra.
        if (vidas <= 0)
        {
            Morrer();
        }
    }

    private void Morrer()
    {
        // Printa no console.
        Debug.Log(gameObject.name + " morreu!");
        
        // Destroi o objeto com esse codigo de cena.
        Destroy(gameObject);
    }
}
