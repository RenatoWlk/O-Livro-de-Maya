using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HerbertDialogo2 : MonoBehaviour
{
    [SerializeField]
    private UnityEvent clicouOgro;
    private Animator anim;
    public GameObject menu, dialogo3, tales;
    public Transform tales2;
    public bool clicou;
    private bool interagiu;
    
    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Dialogos.instance.dialogoAberto == false && clicou && !interagiu)
        {
            anim.SetBool("interagiu", false);
            PosicionarDialogosNovos();
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
            Inventario.instance.UsarItem(0);
            Inventario.instance.AdicionarItem(1);
            dialogo3.SetActive(true);
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            anim.SetBool("interagiu", true);
        }
    }

    void PosicionarDialogosNovos()
    {
        tales2.position = tales.transform.position;
        Destroy(tales);
    }
}
