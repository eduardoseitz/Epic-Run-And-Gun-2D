using UnityEngine;

public class MovimentoPlataforma : MonoBehaviour
{
    // Variaveis publicas.
    public float moverY = 1f;
    public float velocidadeMover = 0.5f;
    
    // Variaveis privadas.
    private Vector2 posicaoInicial;
    private Vector2 posicaoFinal;
    [SerializeField] private bool estaIndoProFinal = true;
    
    // Este metódo é chamado pela Unity no incio do jogo.
    void Start()
    {
        posicaoInicial = transform.position;
        posicaoFinal = new Vector2(0, posicaoInicial.y + Mathf.Abs(moverY));
    }

    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    void Update()
    {
        if (transform.position.y < posicaoFinal.y && estaIndoProFinal == true)
        {
            transform.Translate(new Vector2(0, Mathf.Abs(velocidadeMover) * Time.deltaTime));
        }
        else if (transform.position.y >= posicaoFinal.y)
        {
            estaIndoProFinal = false;
        }
        if (transform.position.y > posicaoInicial.y && estaIndoProFinal == false)
        {
            transform.Translate(new Vector2(0, -Mathf.Abs(velocidadeMover) * Time.deltaTime));
        }
        else if (transform.position.y <= posicaoInicial.y)
        {
            estaIndoProFinal = true;
        }
    }
}
