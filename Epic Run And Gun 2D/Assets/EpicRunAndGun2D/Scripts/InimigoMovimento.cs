using UnityEngine;

public class InimigoMovimento : MonoBehaviour
{
    // Variaveis publicas.
    public Transform player;
    public float distanciaParaFicarAgressivo = 10;
    public float forcaPulo = 7f;
    public Rigidbody2D rigidbody2D;
    public int chanceDePular = 10;
    public int chanceDeAbaixar = 1;
    [HideInInspector] public bool estaAgressivo;
    [HideInInspector] public bool olhandoPraEsquerda;

    // Variaveis privadas.
    private bool seEstaNoChao = true;
    private Vector2 escalaOriginal;
    private bool estaSeAbaixando = false;
    
    // Este metódo é chamado pela Unity no incio do jogo.
    public void Start()
    {
        escalaOriginal = transform.localScale;
        
        InvokeRepeating(nameof(Pular), 1f, 1f);
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
                Abaixar();
            }
            else
            {
                estaAgressivo = false;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        seEstaNoChao = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        seEstaNoChao = false;
    }
    
    private void Pular()
    {
        if (Random.Range(1, 100) <= chanceDePular)
        {
            Levantar();
            
            if (rigidbody2D == true && seEstaNoChao == true)
            {
                rigidbody2D.AddForceY(forcaPulo, ForceMode2D.Impulse);
            }
        }
    }

    private void Abaixar()
    {
        if (Random.Range(1, 100) <= chanceDeAbaixar)
        {
            if (seEstaNoChao == true && estaSeAbaixando == false)
            {
                transform.localScale = new Vector2(transform.localScale.x, escalaOriginal.y / 2);
                estaSeAbaixando = true;
            }
        }
    }
    
    private void Levantar()
    {
        if (estaSeAbaixando == true)
        {
            transform.localScale = new Vector2(transform.localScale.x, escalaOriginal.y);
            estaSeAbaixando = false;
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
