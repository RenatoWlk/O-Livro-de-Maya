using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VasosInteragir : MonoBehaviour
{
    [SerializeField]
    private UnityEvent clicouVasos;
    private Animator anim;
    public bool clicou;
    public GameObject menu;
    public static VasosInteragir instance;

    void Start()
    {
        anim = GetComponent<Animator>();
        instance = this;
    }

    void OnMouseOver()
    {
        if(Dialogos.instance.dialogoAberto == false && menu.activeSelf == false && clicou == false)
        {
            anim.SetBool("mouse", true);
            BotaoInteragir.instance.SeguirMouse(true);
            Clicou();
        }
    }

    void OnMouseExit()
    {
        anim.SetBool("mouse", false);
        BotaoInteragir.instance.SeguirMouse(false);
    }

    void Clicou()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            clicou = true;
            clicouVasos.Invoke();
        }
    }
}
