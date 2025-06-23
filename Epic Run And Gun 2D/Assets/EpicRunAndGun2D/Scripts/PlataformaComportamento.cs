using UnityEngine;

public class PlataformaComportamento : MonoBehaviour
{
    // Variaveis publicas.
    public float moverY = 1f;
    public float velocidadeMover = 0.5f;
    
    // Variaveis privadas.
    [SerializeField] private Vector2 posicaoInicial;
    [SerializeField] private Vector2 posicaoFinal;
    [SerializeField] private bool estaIndoProFinal = true;
    
    // Este metódo é chamado pela Unity no incio do jogo.
    private void Start()
    {
        posicaoInicial = transform.position;
        posicaoFinal = new Vector2(0, posicaoInicial.y + moverY);
    }

    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
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
    }
}
