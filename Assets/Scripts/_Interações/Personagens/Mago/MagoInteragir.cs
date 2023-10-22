using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MagoInteragir : MonoBehaviour
{
    [SerializeField]
    private UnityEvent clicouCasa;
    private Animator anim;
    private bool clicou;
    public GameObject menu, fada, bloqueio, cercaFechada, cercaAberta;

    void Update()
    {
        if(clicou && Dialogos.instance.dialogoAberto == true)
        {
            if(Dialogos.instance.contador == 9)
            {
                StartCoroutine(FadaSair());
            }

            if(Dialogos.instance.contador == 10)
            {
                fada.GetComponent<FadaSeguir>().enabled = false;
                fada.GetComponent<FadaSair>().enabled = true;
            }
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
            clicouCasa.Invoke();
            Destroy(bloqueio);
            cercaAberta.SetActive(true);
            cercaFechada.SetActive(false);
            VasosInteragir.instance.clicou = true;
            Inventario.instance.UsarItem(4);
            Inventario.instance.UsarItem(5);
            Inventario.instance.UsarItem(6);
        }
    }

    IEnumerator FadaSair()
    {
        yield return new WaitForSeconds(2f);
        fada.GetComponent<FadaSeguir>().enabled = false;
        fada.GetComponent<FadaSair>().enabled = true;
    }
}
