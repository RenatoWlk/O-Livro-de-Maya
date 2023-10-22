using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Yafit : MonoBehaviour
{
    [SerializeField]
    private UnityEvent dialogo;
    private bool clicou;
    public bool interagiu;
    public GameObject menu;
    public static Yafit instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(Dialogos.instance.dialogoAberto == false && clicou)
        {
            interagiu = true;
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
