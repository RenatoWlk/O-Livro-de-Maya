using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Yafit4 : MonoBehaviour
{
    [SerializeField]
    private UnityEvent dialogo;
    private bool clicou;
    private bool escolheu;
    public GameObject menu, escolha;

    void Update()
    {
        if(escolha != null)
        {
            if(escolha.activeSelf == true)
            {
                Dialogos.instance.dialogoAberto = true;
            }
        }

        if(Dialogos.instance.dialogoAberto == false && clicou && !escolheu)
        {
            escolha.SetActive(true);
            escolheu = true;
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
        }
    }
}
