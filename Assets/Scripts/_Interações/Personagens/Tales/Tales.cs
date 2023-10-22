using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tales : MonoBehaviour
{
    [SerializeField]
    private UnityEvent dialogo;
    private bool clicou;
    public GameObject menu;

    void OnMouseOver()
    {
        if(Dialogos.instance.dialogoAberto == false && TalesDialogo.instance.primeiroDialogo == true && menu.activeSelf == false && clicou == false)
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
        }
    }
}
