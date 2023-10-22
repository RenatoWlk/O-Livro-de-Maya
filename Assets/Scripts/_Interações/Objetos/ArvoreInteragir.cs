using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArvoreInteragir : MonoBehaviour
{
    [SerializeField]
    private UnityEvent clicouArvore;
    private Animator anim;
    private bool clicou;
    public bool comecarTutorial2;
    public GameObject menu, botaoProximo, tutorialImagem, desfoqueDialogo;
    public static ArvoreInteragir instance;

    void Start()
    {
        anim = GetComponent<Animator>();
        instance = this;
    }

    void OnMouseOver()
    {
        if(Tutorial.instance.clicouArvore == false && menu.activeSelf == false && clicou == false)
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
            botaoProximo.SetActive(true);
            Destroy(tutorialImagem);
            desfoqueDialogo.SetActive(true);
            clicou = true;
            Inventario.instance.AdicionarItem(0);
            clicouArvore.Invoke();
            comecarTutorial2 = true;
        }
    }
}
