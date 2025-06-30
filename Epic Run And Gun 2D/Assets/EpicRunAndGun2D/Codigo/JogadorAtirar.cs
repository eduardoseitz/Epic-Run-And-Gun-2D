using UnityEngine;

public class ogadorAtirar : MonoBehaviour
{
    // Variaveis publicas.
    public GameObject projetilPrefab;
    public Transform posicaoArma;
    public JogadorMoviment jogadorMoviment;
    
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
        if (jogadorMoviment.estaOlhandoParaEsquerda)
        {
            Instantiate(projetilPrefab, posicaoArma.transform.position, new Quaternion(0, 180, 0, 0));
        }
        else
        {
            Instantiate(projetilPrefab, posicaoArma.transform.position, Quaternion.identity);
        }
    }
}
