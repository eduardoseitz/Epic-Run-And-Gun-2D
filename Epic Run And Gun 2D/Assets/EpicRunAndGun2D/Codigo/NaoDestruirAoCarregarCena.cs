using UnityEngine;

public class NaoDestruirAoCarregarCena : MonoBehaviour
{
    // Este metódo é chamado pela Unity no incio do jogo.
    private void Start()
    {
        // Tira esse objeto de qualquer pai.
        transform.SetParent(null);

        // Não destrua o objeto com esse código ao carregar outra cena.
        DontDestroyOnLoad(gameObject);
    }
}
