using UnityEngine;

public class MovimentoPlataforma : MonoBehaviour
{
    // Variaveis publicas.
    public float moverY = 1f;
    public float velocidadeMover = 0.5f;
    
    // Variaveis privadas.
    [SerializeField] private Vector2 posicaoInicial;
    [SerializeField] private Vector2 posicaoFinal;
    [SerializeField] private bool estaIndoProFinal = true;
    
    // Este metódo é chamado pela Unity no incio do jogo.
    void Start()
    {
        posicaoInicial = transform.position;
        posicaoFinal = new Vector2(0, posicaoInicial.y + moverY);
        //
        // if (moverY < 0)
        // {
        //     estaIndoProFinal = false;   
        // }
    }

    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    void Update()
    {
        if (estaIndoProFinal == true)
        {
            if (Vector2.Distance(transform.position, posicaoFinal) > 0.1f)
            {
                transform.Translate(new Vector2(0, Mathf.Abs(velocidadeMover) * Mathf.Sign(moverY) * Time.deltaTime));
            }
            else
            {
                estaIndoProFinal = false;
            }
        }
        else if (estaIndoProFinal == false)
        {
            if (Vector2.Distance(transform.position, posicaoInicial) > 0.1f)
            {
                transform.Translate(new Vector2(0, Mathf.Abs(velocidadeMover) * -Mathf.Sign(moverY) * Time.deltaTime));
            }
            else
            {
                estaIndoProFinal = true;
            }
        }
        
        // if (transform.position.y > posicaoInicial.y && estaIndoProFinal == false)
        // {
        //     transform.Translate(new Vector2(0, -Mathf.Abs(velocidadeMover) * Time.deltaTime));
        // }
        // else if (transform.position.y <= posicaoInicial.y)
        // {
        //     estaIndoProFinal = true;
        // }
    }
}
