using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Yafit2 : MonoBehaviour
{
    [SerializeField]
    private UnityEvent dialogo;
    private bool clicou;
    public GameObject menu;

    void Update()
    {
        if(Dialogos.instance.dialogoAberto == false && clicou)
        {
            JardimMinigame.instance.Iniciar = true;
        }
    }

    void OnMouseOver()
    {
        if(Dialogos.instance.dialogoAberto == false && menu.activeSelf == false && clicou == false)
        {
            BotaoInteragir.instance.SeguirMouse(true);
            Clicou();
        }
    }

    void OnMouseExit()
    {
        BotaoInteragir.instance.SeguirMouse(false);
    }

    void Clicou()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            clicou = true;
            dialogo.Invoke();
            Inventario.instance.AdicionarItem(3);
        }
    }
}
