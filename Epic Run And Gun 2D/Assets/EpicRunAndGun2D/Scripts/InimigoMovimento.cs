using UnityEngine;

public class InimigoMovimento : MonoBehaviour
{
    // Variaveis publicas.
    public Transform player;
    public float distanciaParaFicarAgressivo = 5;
    public SpriteRenderer spriteRenderer;
    [HideInInspector] public bool estaAgressivo;
    [HideInInspector] public bool olhandoPraEsquerda;

    // Variaveis privadas.
    private Vector2 escalaOriginal;
    
    // Este metódo é chamado pela Unity no incio do jogo.
    public void Start()
    {
        escalaOriginal = transform.localScale;
    }
    
    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        if (player)
        {
            if (Vector2.Distance(transform.position, player.position) < distanciaParaFicarAgressivo)
            {
                estaAgressivo = true;

                OlharDirecao();
            }
            else
            {
                estaAgressivo = false;
            }
        }
    }

    private void OlharDirecao()
    {
        if (player.position.x < transform.position.x && olhandoPraEsquerda == false)
        {
            transform.localScale = new Vector2(-escalaOriginal.x, transform.localScale.y);
            olhandoPraEsquerda = true;
        }
        else if (player.position.x > transform.position.x && olhandoPraEsquerda == true)
        {
            transform.localScale = new Vector2(escalaOriginal.x, transform.localScale.y);
            olhandoPraEsquerda = false;
        }
    }
}
