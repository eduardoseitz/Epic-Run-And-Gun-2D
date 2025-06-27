using UnityEngine;

public class InimigoMovimento : MonoBehaviour
{
    // Variaveis publicas.
    public Transform player;
    public float moverX = 2f;
    public float distanciaParaFicarAgressivo = 10f;
    public float velocidadeCaminhar = 2f;
    public float forcaPulo = 3f;
    public Rigidbody2D rigidbody2D;
    [Range(1, 100)] public int chanceDePular = 10;
    [Range(1, 100)] public int chanceDeAbaixar = 1;
    [HideInInspector] public bool estaAgressivo;
    [HideInInspector] public bool olhandoPraEsquerda;

    // Variaveis privadas.
    private bool seEstaNoChao = true;
    private Vector2 escalaOriginal;
    private bool estaSeAbaixando = false;
    private Vector2 posicaoInicial;
    [SerializeField] private Vector2 posicaoFinal;
    [SerializeField] private bool estaIndoProFinal = true;
    
    // Este metódo é chamado pela Unity no incio do jogo.
    public void Start()
    {
        escalaOriginal = transform.localScale;
        posicaoInicial = transform.position;
        posicaoFinal = new Vector2(posicaoInicial.x + moverX, posicaoInicial.y);
        
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

                Abaixar();
                OlharParaJogador();
            }
            else if (estaAgressivo == false)
            {
                Caminhar();
                OlharParaCaminho();
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
    
    private void Caminhar()
    {
        if (estaSeAbaixando == false)
        {
            if (estaIndoProFinal == true)
            {
                if (Mathf.Abs(transform.position.x - posicaoFinal.x) > 0.1f)
                {
                    transform.Translate(new Vector2(Mathf.Abs(velocidadeCaminhar) * Mathf.Sign(moverX) * Time.deltaTime, 0));
                }
                else
                {
                    estaIndoProFinal = false;
                }
            }
            else
            {
                if (Mathf.Abs(transform.position.x - posicaoInicial.x) > 0.1f)
                {
                    transform.Translate(new Vector2(Mathf.Abs(velocidadeCaminhar) * -Mathf.Sign(moverX) * Time.deltaTime, 0));
                }
                else
                {
                    estaIndoProFinal = true;
                }
            }
        }
    }
    
    private void OlharParaCaminho()
    {
        if ((estaIndoProFinal == true && Mathf.Sign(moverX) >= 0) || estaIndoProFinal == false && Mathf.Sign(moverX) < 0)
        {
            transform.localScale = new Vector2(escalaOriginal.x, transform.localScale.y);
            olhandoPraEsquerda = false;
        }
        else
        {
            transform.localScale = new Vector2(-escalaOriginal.x, transform.localScale.y);
            olhandoPraEsquerda = true;
        }
    }
    
    private void OlharParaJogador()
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
}
