using UnityEngine;

public class JogadorMoviment : MonoBehaviour
{
    // Variaveis publicas.
    public float velocidadeAoCaminhar = 8f;
    public float forcaDoPulo = 8f;
    public Rigidbody2D rigidbody2D;
    public int numeroMaximoDePulosSeguidos = 2;
    public AudioSource somAoPular;
    public Animator animador;
    [HideInInspector] public bool estaOlhandoParaEsquerda;
    
    // Variaveis privadas.
    private float controleHorizontal;
    private float controleVertical;
    private bool seEstaNoChao = true;
    private Vector2 escalaOriginal;
    private bool estaSeAbaixando = false;
    private int numeroDePulos = 0;

    // Este metódo é chamado pela Unity no incio do jogo.
    public void Start()
    {
        escalaOriginal = transform.localScale;
    }

    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        // Pegue o input s ou baixo
        controleVertical = Input.GetAxisRaw("Vertical");
        if (controleVertical < 0)
            Abaixar();
        else
            Levantar();

        // Pegue o input esquerda, direita ou a, d
        controleHorizontal = Input.GetAxisRaw("Horizontal");
        Caminhar();

        // Pegue o input w ou cima
        if (Input.GetButtonDown("Pular"))
        {
            Pular();
        }
    }

    // Ao colidir com outro objeto 2D.
    private void OnTriggerEnter2D(Collider2D outroObjeto)
    {
        if (outroObjeto.gameObject.tag == "Untagged")
        {
            seEstaNoChao = true;
            numeroDePulos = 0;
            
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
        if (outroObjeto.gameObject.tag == "Untagged")
        {
            seEstaNoChao = false;
        }
    }

    private void Caminhar()
    {
        if (estaSeAbaixando == false)
        {
            // Move na direção correta.
            transform.Translate(new Vector2(controleHorizontal * velocidadeAoCaminhar * Time.deltaTime, 0));

            // Animar.
            if (animador)
            {
                animador.SetBool("Caminhando", (controleHorizontal != 0));
            }
            
            OlharDirecao();
        }
    }
    
    private void OlharDirecao()
    {
        // Caso olhando para esquerda.
        if (controleHorizontal < -0.1f)
        {   
            estaOlhandoParaEsquerda = true;
        }
        // Caso olhando para direita.
        else if (controleHorizontal > 0.1f)
        {
            estaOlhandoParaEsquerda = false;
        }
        
        if (estaOlhandoParaEsquerda)
        {
            transform.localScale = new Vector2(-escalaOriginal.x, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(escalaOriginal.x, transform.localScale.y);
        }
    }

    private void Pular()
    {
        if (rigidbody2D == true && numeroDePulos < numeroMaximoDePulosSeguidos)
        {
            // Adicione força de impulso para cima.
            rigidbody2D.AddForceY(forcaDoPulo, ForceMode2D.Impulse);
            
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

            numeroDePulos = numeroDePulos + 1;
        }
    }

    private void Abaixar()
    {
        if (seEstaNoChao == true && estaSeAbaixando == false)
        {
            estaSeAbaixando = true;

            // Corta a altura do objeto pela metade para parecer que está abaixado.
            transform.localScale = new Vector2(transform.localScale.x, escalaOriginal.y / 2);
        }

        // Animar.
        if (animador == true)
        {
            animador.SetBool("Abaixando", true);
        }
        else transform.localScale = new Vector3(transform.localScale.x, escalaOriginal.y / 2, 1);
    }
    
    private void Levantar()
    {
        if (estaSeAbaixando == true)
        {
            estaSeAbaixando = false;

            // Volta a altura do objeto ao normal para parecer que está de pé.
            transform.localScale = new Vector2(transform.localScale.x, escalaOriginal.y);
        }

        // Animar.
        if (animador == true)
        {
            animador.SetBool("Abaixando", false);
        }
        else transform.localScale = new Vector3(transform.localScale.x, escalaOriginal.y, 1);
    }
}
