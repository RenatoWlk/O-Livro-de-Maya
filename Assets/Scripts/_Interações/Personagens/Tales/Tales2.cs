using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tales2 : MonoBehaviour
{
    [SerializeField]
    private UnityEvent dialogo;
    private bool clicou;
    public GameObject yafit, yafit2, yafit3, menu;

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
            Inventario.instance.UsarItem(1);
            ReposicionarYafit();
        }
    }

    void ReposicionarYafit()
    {
        if(Yafit.instance.interagiu == true)
        {
            yafit2.transform.position = yafit.transform.position;
            Destroy(yafit);
            Destroy(yafit3);
        }
        else
        {
            yafit3.transform.position = yafit.transform.position;
            Destroy(yafit);
            Destroy(yafit2);
        }
    }
}
