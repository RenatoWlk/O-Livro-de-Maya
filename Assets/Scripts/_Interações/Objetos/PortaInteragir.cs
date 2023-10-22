using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PortaInteragir : MonoBehaviour
{
    [SerializeField]
    private UnityEvent clicouPorta;
    private bool clicou;
    public GameObject menu, entrarCasa;

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
        if (Input.GetMouseButtonDown(0)) 
        {
            clicou = true;
            clicouPorta.Invoke();
            gameObject.transform.position = new Vector3(-30, 70, 0);
            entrarCasa.SetActive(true);
        }
    }
}
