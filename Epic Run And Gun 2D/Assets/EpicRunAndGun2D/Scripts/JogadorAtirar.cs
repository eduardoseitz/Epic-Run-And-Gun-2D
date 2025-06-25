using UnityEngine;

public class ogadorAtirar : MonoBehaviour
{
    public GameObject projetilPrefab;
    public Transform posicaoArmaEsquerda;
    public Transform posicaoArmaDireita;
    public SpriteRenderer spriteRenderer;
    
    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        if (Input.GetButtonDown("Atirar"))
        {
            Atirar();
        }
    }

    private void Atirar()
    {
        if (spriteRenderer.flipX == false)
        {
            Instantiate(projetilPrefab, posicaoArmaDireita.transform.position, posicaoArmaDireita.transform.rotation);
        }
        else if (spriteRenderer.flipX == true)
        {
            Instantiate(projetilPrefab, posicaoArmaEsquerda.transform.position, posicaoArmaEsquerda.transform.rotation);
        }
    }
}
