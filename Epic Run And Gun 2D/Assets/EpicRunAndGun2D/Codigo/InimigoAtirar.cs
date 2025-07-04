using UnityEngine;

public class InimigoAtirar : MonoBehaviour
{
    // Variaveis publicas.
    public GameObject projetilPrefab;
    public Transform posicaoArma;
    public int chanceDeAtirar = 15;
    public float atirarACadaSegundos = 1f;
    public AudioSource somAoAtirar;
    public InimigoMovimento inimigoMovimento;
    
    // Este metódo é chamado pela Unity no incio do jogo.
    public void Start()
    {
        // Repita a função atirar a cada x segundos.
        InvokeRepeating(nameof(Atirar), atirarACadaSegundos, atirarACadaSegundos);
    }
    
    private void Atirar()
    {
        if (inimigoMovimento == true)
        {
            if (inimigoMovimento.estaAgressivo)
            {
                // Sorteie um numero de 1 a 100 e compare se é menor que a chance de atirar.
                if (Random.Range(1, 100) <= chanceDeAtirar)
                {
                    if (inimigoMovimento.olhandoPraEsquerda)
                    {
                        if (projetilPrefab == true && posicaoArma == true)
                        {
                            // Spawne um objeto novo na posição onde seria a arma.
                            Instantiate(projetilPrefab, posicaoArma.transform.position, new Quaternion(0, 180, 0, 0));
                        }
                    }
                    else
                    {
                        if (projetilPrefab == true && posicaoArma == true)
                        {
                            // Spawne um objeto novo na posição onde seria a arma.
                            Instantiate(projetilPrefab, posicaoArma.transform.position, Quaternion.identity);
                        }
                    }

                    // Tocar som.
                    if (somAoAtirar == true)
                    {
                        somAoAtirar.PlayOneShot(somAoAtirar.clip);
                    }
                }
            }
        }
    }
}
