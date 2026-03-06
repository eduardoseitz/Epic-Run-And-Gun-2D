using UnityEngine;

public class JogadorAtirar : MonoBehaviour
{
    // Variaveis publicas.
    public GameObject projetilPrefab;
    public Transform posicaoArma;
    public JogadorMovimento jogadorMovimento;
    public AudioSource somAoAtirar;
    public string atirarInput = "Atirar";
    
    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        // Ao precionar o botão de atirar.
        if (Input.GetButtonDown(atirarInput))
        {
            Atirar();
        }
    }

    public void Atirar()
    {
        if (projetilPrefab == true && posicaoArma == true && jogadorMovimento == true)
        {
            // Verifique o lado que o jogador está olhando.
            if (jogadorMovimento.estaOlhandoParaEsquerda)
            {
                // Spawne um objeto novo na posição onde seria a arma.
                Instantiate(projetilPrefab, posicaoArma.transform.position, new Quaternion(0, 180, 0, 0));
            }
            else
            {
                // Spawne um objeto novo na posição onde seria a arma.
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
