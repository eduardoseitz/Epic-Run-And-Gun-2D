using UnityEngine;

public class JogadorMoviment : MonoBehaviour
{
    // Variaveis publicas.
    public float velocidadeAoCaminhar = 6f;
    public float forcaDoPulo = 7f;
    public Rigidbody2D rigidbody2D;
    [HideInInspector] public bool estaOlhandoParaEsquerda;
    
    // Variaveis privadas.
    private float controleHorizontal;
    private bool seEstaNoChao = true;
    private Vector2 escalaOriginal;
    private bool estaSeAbaixando = false;

    // Este metódo é chamado pela Unity no incio do jogo.
    public void Start()
    {
        escalaOriginal = transform.localScale;
    }

    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        controleHorizontal = Input.GetAxis("Horizontal");
        Caminhar();
        
        if(Input.GetButtonDown("Pular"))
        {
            Pular();
        }
        
        if(Input.GetButtonDown("Abaixar"))
        {
            Abaixar();
        }
        else if(Input.GetButtonUp("Abaixar"))
        {
            Levantar();
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
            transform.Translate(new Vector2(controleHorizontal * velocidadeAoCaminhar * Time.deltaTime, 0));

            OlharDirecao();
        }
    }
    
    private void OlharDirecao()
    {
        if (controleHorizontal < -0.1f && estaOlhandoParaEsquerda == false)
        {
            transform.localScale = new Vector2(-escalaOriginal.x, transform.localScale.y);
            estaOlhandoParaEsquerda = true;
        }
        else if (controleHorizontal > 0.1f && estaOlhandoParaEsquerda == true)
        {
            transform.localScale = new Vector2(escalaOriginal.x, transform.localScale.y);
            estaOlhandoParaEsquerda = false;
        }
    }

    private void Pular()
    {
        if (rigidbody2D == true && seEstaNoChao == true)
        {
            rigidbody2D.AddForceY(forcaDoPulo, ForceMode2D.Impulse);
        }
    }

    private void Abaixar()
    {
        if (seEstaNoChao == true && estaSeAbaixando == false)
        {
            transform.localScale = new Vector2(transform.localScale.x, escalaOriginal.y / 2);
            estaSeAbaixando = true;
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
