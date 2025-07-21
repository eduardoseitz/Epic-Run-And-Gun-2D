using UnityEngine;

public class NaoDestruirAoCarregarCena : MonoBehaviour
{
    // Variaveis estaticas.
    public static NaoDestruirAoCarregarCena instance;

    // Este metódo é chamado pela Unity no incio do jogo.
    private void Start()
    {
        // Padrao singleton.
        if (NaoDestruirAoCarregarCena.instance == null)
            NaoDestruirAoCarregarCena.instance = this; 
        else
            Destroy(gameObject);

        // Tira esse objeto de qualquer pai.
        transform.SetParent(null);

        // Não destrua o objeto com esse código ao carregar outra cena.
        DontDestroyOnLoad(gameObject);
    }
}
