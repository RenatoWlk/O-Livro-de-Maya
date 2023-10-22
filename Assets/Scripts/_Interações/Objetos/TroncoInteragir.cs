using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TroncoInteragir : MonoBehaviour
{
    [SerializeField]
    private UnityEvent clicouTronco;
    private Animator anim;
    private bool clicou;
    public GameObject menu;
    private AudioSource sapo;

    void Start()
    {
        sapo = GetComponent<AudioSource>();
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
        if (Input.GetMouseButtonDown(0)) 
        {
            sapo.Play();
            clicou = true;
            clicouTronco.Invoke();
        }
    }
}
