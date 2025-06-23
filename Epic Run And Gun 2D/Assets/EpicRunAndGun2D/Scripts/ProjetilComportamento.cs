using UnityEngine;

public class ProjetilComportamento : MonoBehaviour
{
    public float velocidade = 5f;
    public float destruirDespoisDeSegundos = 2f;
    
    // Este metódo é chamado pela Unity no incio do jogo.
    public void Start()
    {
        Destroy(this.gameObject, destruirDespoisDeSegundos);
    }

    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }
}
