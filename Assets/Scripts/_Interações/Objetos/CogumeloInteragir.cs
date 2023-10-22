using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CogumeloInteragir : MonoBehaviour
{
    [SerializeField]
    private UnityEvent clicouCogumelo;
    private Animator anim;
    private bool clicou;
    public GameObject menu;

    void Start()
    {
        anim = GetComponent<Animator>();
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
            clicouCogumelo.Invoke();
        }
    }
}
