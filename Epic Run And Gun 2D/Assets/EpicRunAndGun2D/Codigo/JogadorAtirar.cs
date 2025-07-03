using UnityEngine;

public class ogadorAtirar : MonoBehaviour
{
    // Variaveis publicas.
    public GameObject projetilPrefab;
    public Transform posicaoArma;
    public JogadorMoviment jogadorMovimento;
    public AudioSource somAoAtirar;
    
    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        if (Input.GetButtonDown("Atirar"))
        {
            Atirar();
        }
    }

    private void Atirar()
    {
        if (projetilPrefab == true && posicaoArma == true && jogadorMovimento == true)
        {
            if (jogadorMovimento.estaOlhandoParaEsquerda)
            {
                Instantiate(projetilPrefab, posicaoArma.transform.position, new Quaternion(0, 180, 0, 0));
            }
            else
            {
                Instantiate(projetilPrefab, posicaoArma.transform.position, Quaternion.identity);
            }

            // Tocar som.
            if (somAoAtirar == true)
            {
                somAoAtirar.PlayOneShot(somAoAtirar.clip);
            }
        }
    }
}
