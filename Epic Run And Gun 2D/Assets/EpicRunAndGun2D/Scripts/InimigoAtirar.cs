using UnityEngine;

public class InimigoAtirar : MonoBehaviour
{
    public GameObject projetilPrefab;
    public Transform posicaoArma;
    public SpriteRenderer spriteRenderer;
    public int chanceDeAtirar = 30;
    public float atirarACadaSegundos = 0.5f;
    
    [HideInInspector] public InimigoMovimento inimigoMovimento;
    
    // Este metódo é chamado pela Unity no incio do jogo.
    public void Start()
    {
        InvokeRepeating(nameof(Atirar), atirarACadaSegundos, atirarACadaSegundos);
    }
    
    private void Atirar()
    {
        if (inimigoMovimento.estaAgressivo)
        {
            if (Random.Range(1, 100) <= chanceDeAtirar)
            {
                if (inimigoMovimento.olhandoPraEsquerda)
                {
                    Instantiate(projetilPrefab, posicaoArma.transform.position, new Quaternion(0, 180, 0, 0));
                }
                else
                {
                    Instantiate(projetilPrefab, posicaoArma.transform.position, Quaternion.identity);
                }
            }
        }
    }
}
