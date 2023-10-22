using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteragirFada : MonoBehaviour
{
    [SerializeField]
    private UnityEvent clicouFada;
    public static InteragirFada instance;
    public bool clicou;
    public bool interagiu;
    public GameObject menu, bloqueio, bloqueio2, fleury;
    private AudioSource choro;

    void Start()
    {
        choro = GetComponent<AudioSource>();
        instance = this;
    }

    void Update()
    {
        if(Dialogos.instance.dialogoAberto == false && clicou && interagiu == false)
        {
            interagiu = true;
            gameObject.SetActive(false);
            fleury.SetActive(true);
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
            clicouFada.Invoke();
            choro.Stop();
            Destroy(bloqueio);
            Destroy(bloqueio2);
        }
    }
}
