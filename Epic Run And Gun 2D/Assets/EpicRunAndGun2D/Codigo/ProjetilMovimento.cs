using UnityEngine;

public class ProjetilMovimento : MonoBehaviour
{
    public float velocidade = 25f;
    public float destruirDespoisDeSegundos = 2f;
    
    // Este metódo é chamado pela Unity no incio do jogo.
    public void Start()
    {
        Destroy(gameObject, destruirDespoisDeSegundos);
    }

    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D outroObjeto)
    {
        Destroy(gameObject);
    }
    
}
