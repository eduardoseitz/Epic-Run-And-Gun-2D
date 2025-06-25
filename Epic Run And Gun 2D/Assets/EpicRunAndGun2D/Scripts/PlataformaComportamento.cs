using UnityEngine;

public class PlataformaComportamento : MonoBehaviour
{
    // Variaveis publicas.
    public float moverX = 1f;
    public float moverY = 0;
    public float velocidadeMoverX = 1f;
    public float velocidadeMoverY = 1f;
    
    // Variaveis privadas.
    [SerializeField] private Vector2 posicaoInicial;
    [SerializeField] private Vector2 posicaoFinal;
    [SerializeField] private bool estaIndoProFinalNoEixoX = true;
    [SerializeField] private bool estaIndoProFinalNoEixoY = true;
    
    // Este metódo é chamado pela Unity no incio do jogo.
    private void Start()
    {
        posicaoInicial = transform.position;
        posicaoFinal = new Vector2(posicaoInicial.x + moverX, posicaoInicial.y + moverY);
    }

    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        MoverEixoX();
        MoverEixoY();
    }

    private void MoverEixoX()
    {
        if (estaIndoProFinalNoEixoX == true)
        {
            if (Mathf.Abs(transform.position.x - posicaoFinal.x) > 0.1f)
            {
                transform.Translate(new Vector2(Mathf.Abs(velocidadeMoverX) * Mathf.Sign(moverX) * Time.deltaTime, 0));
            }
            else
            {
                estaIndoProFinalNoEixoX = false;
            }
        }
        else
        {
            if (Mathf.Abs(transform.position.x - posicaoInicial.x) > 0.1f)
            {
                transform.Translate(new Vector2(Mathf.Abs(velocidadeMoverX) * -Mathf.Sign(moverX) * Time.deltaTime, 0));
            }
            else
            {
                estaIndoProFinalNoEixoX = true;
            }
        }
    }
    
    private void MoverEixoY()
    {
        if (estaIndoProFinalNoEixoY == true)
        {
            if (Mathf.Abs(transform.position.y - posicaoFinal.y) > 0.1f)
            {
                transform.Translate(new Vector2(0, Mathf.Abs(velocidadeMoverY) * Mathf.Sign(moverY) * Time.deltaTime));
            }
            else
            {
                estaIndoProFinalNoEixoY = false;
            }
        }
        else 
        {
            if (Mathf.Abs(transform.position.y - posicaoInicial.y) > 0.1f)
            {
                transform.Translate(new Vector2(0, Mathf.Abs(velocidadeMoverY) * -Mathf.Sign(moverY) * Time.deltaTime));
            }
            else
            {
                estaIndoProFinalNoEixoY = true;
            }
        }
    }
}
