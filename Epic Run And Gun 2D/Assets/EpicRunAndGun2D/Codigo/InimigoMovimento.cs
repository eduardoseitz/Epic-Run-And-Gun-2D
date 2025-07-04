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
    public AudioSource somAoPular;
    public Animator animador;

    // Variaveis privadas.
    private bool seEstaNoChao = true;
    private Vector2 escalaOriginal;
    private bool estaSeAbaixando = false;
    private Vector2 posicaoInicial;
    private Vector2 posicaoFinal;
    private bool estaIndoProFinal = true;
    
    // Este metódo é chamado pela Unity no incio do jogo.
    public void Start()
    {
        escalaOriginal = transform.localScale;
        posicaoInicial = transform.position;
        posicaoFinal = new Vector2(posicaoInicial.x + moverX, posicaoInicial.y);

        // Repita a função pular a cada x segundos.
        InvokeRepeating(nameof(Pular), 1f, 1f);
    }
    
    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        if (player)
        {
            // Se o player estiver perto o suficiente.
            if (Vector2.Distance(transform.position, player.position) < distanciaParaFicarAgressivo)
            {
                // O inimigo fica agressivo.
                estaAgressivo = true;
                Abaixar();
                OlharParaJogador();
                
                // Animar.
                if (animador == true && estaSeAbaixando == false)
                {
                    animador.SetBool("Caminhando", false);
                }
            }
            // Se o player estiver longe.
            else if (estaAgressivo == false)
            {
                // O inimigo caminha normalmente.
                Caminhar();
                OlharParaCaminho();
                
                // Animar.
                if (animador == true && estaSeAbaixando == false)
                {
                    animador.SetBool("Caminhando", true);
                }
            }
        }
    }

    // Ao colidir com outro objeto 2D.
    private void OnTriggerEnter2D(Collider2D outroObjeto)
    {
        // Verifica se está tocando no chao.
        if (outroObjeto.gameObject.tag == "Untagged")
        {
            seEstaNoChao = true;
            
            // Animar.
            if (animador == true)
            {
                animador.SetBool("Pulando", false);
            }
        }
    }

    // Ao parar de colidir com outro objeto 2D.
    private void OnTriggerExit2D(Collider2D outroObjeto)
    {
        // Verifica se está no ar.
        if (outroObjeto.gameObject.tag == "Untagged")
        {
            seEstaNoChao = false;
        }
    }
    
    private void Caminhar()
    {
        if (estaSeAbaixando == false)
        {
            if (estaIndoProFinal == true)
            {
                // Se estiver em direção ao ponto final.
                if (Mathf.Abs(transform.position.x - posicaoFinal.x) > 0.1f)
                {
                    // Mova para o ponto final.
                    transform.Translate(new Vector2(Mathf.Abs(velocidadeCaminhar) * Mathf.Sign(moverX) * Time.deltaTime, 0));
                }
                else
                {
                    estaIndoProFinal = false;
                }
            }
            // Se estiver em direção ao ponto inicial.
            else
            {
                if (Mathf.Abs(transform.position.x - posicaoInicial.x) > 0.1f)
                {
                    // Mova para o ponto inicial.
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
        // Verifica se deve ficar voltado para a esquerda ou para a direita.
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
        // Verifica se deve ficar voltado para a esquerda ou para a direita.
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
        // Sorteie um numero de 1 a 100 e compare se é menor que a chance de pular. 
        if (Random.Range(1, 100) <= chanceDePular)
        {
            // Se estiver abaixado levante.
            Levantar();
            
            // Se estiver no chão.
            if (rigidbody2D == true && seEstaNoChao == true)
            {
                // Adicione força de impulso para cima.
                rigidbody2D.AddForceY(forcaPulo, ForceMode2D.Impulse);
                
                // Tocar som.
                if (somAoPular == true)
                {
                    somAoPular.PlayOneShot(somAoPular.clip);
                }
                
                // Animar.
                if (animador == true)
                {
                    animador.SetBool("Pulando", true);
                }
            }
        }
    }

    private void Abaixar()
    {
        // Sorteie um numero de 1 a 100 e compare se é menor que a chance de abaixar.
        if (Random.Range(1, 100) <= chanceDeAbaixar)
        {
            if (seEstaNoChao == true && estaSeAbaixando == false)
            {
                estaSeAbaixando = true;

                // Corta a altura do objeto pela metade para parecer que está abaixado.
                transform.localScale = new Vector2(transform.localScale.x, escalaOriginal.y / 2);
            }
        }
    }
    
    private void Levantar()
    {
        if (estaSeAbaixando == true)
        {
            estaSeAbaixando = false;

            // Volta a altura do objeto ao normal para parecer que está de pé.
            transform.localScale = new Vector2(transform.localScale.x, escalaOriginal.y);
        }
    }
}
