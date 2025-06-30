using UnityEngine;

public class NaoDestruirAoCarregarCena : MonoBehaviour
{
    // Este metódo é chamado pela Unity no incio do jogo.
    private void Start()
    {
        transform.SetParent(null);
        DontDestroyOnLoad(this.gameObject);
    }
}
