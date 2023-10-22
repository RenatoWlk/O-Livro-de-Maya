using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EscolhaYafit : MonoBehaviour
{
    [SerializeField] private UnityEvent dialogoAzul;
    [SerializeField] private UnityEvent dialogoVermelho;
    [SerializeField] private UnityEvent dialogoAmarelo;
    public GameObject escolha, bloqueioTrilha;
    private bool amarelo;

    void Update()
    {
        if(Dialogos.instance.dialogoAberto == false && amarelo)
        {
            amarelo = false;
        }
    }

    public void DiscoAmarelo()
    {
        Destroy(escolha);
        Destroy(bloqueioTrilha);
        amarelo = true;
        dialogoAmarelo.Invoke();
        Inventario.instance.UsarItem(3);
    }

    public void DiscoAzul()
    {
        dialogoAzul.Invoke();
    }

    public void DiscoVermelho()
    {
        dialogoVermelho.Invoke();
    }
}
