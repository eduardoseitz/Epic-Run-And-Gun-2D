using UnityEngine;

public class JogadorVida : MonoBehaviour
{
    public int vidas = 3;
    
    private void OnCollisionEnter2D(Collision2D outroObjeto)
    {
        switch (outroObjeto.gameObject.tag)
        {
            case "Projetil":
                TomarDano();
                break;
            case "Inimigo":
                TomarDano();
                break;
            case "Morte":
                Morrer();
                break;
        }
    }

    private void TomarDano()
    {
        Debug.Log("This was called " + vidas);
        vidas = vidas - 1;

        if (vidas <= 0)
        {
            Morrer();
        }
    }

    private void Morrer()
    {
        Destroy(gameObject);
    }
}
