using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HerbertDialogo1 : MonoBehaviour
{
    [SerializeField]
    private UnityEvent clicouOgro;
    private Animator anim;
    public GameObject menu;
    public Transform ogro2;
    public bool clicou, mg;
    private bool interagiu;
    public static HerbertDialogo1 instance;

    public void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Dialogos.instance.dialogoAberto == false && clicou && !interagiu)
        {
            anim.SetBool("interagiu", false);
            PantanoMinigame.instance.Iniciar = true;
            StartCoroutine(PosicionarDialogosNovos());
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
            clicouOgro.Invoke();
            clicou = true;
            Inventario.instance.UsarItem(2);
            anim.SetBool("interagiu", true);
        }
    }

    IEnumerator PosicionarDialogosNovos()
    {
        yield return new WaitForSeconds(3f);
        ogro2.position = gameObject.transform.position;
        Destroy(gameObject);
    }
}
