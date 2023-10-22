using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PassaroInteragir : MonoBehaviour
{
    [SerializeField]
    private UnityEvent clicouPassaro;
    private Animator anim;
    private bool clicou;
    public GameObject menu;
    private AudioSource bemtevi;

    void Start()
    {
        anim = GetComponent<Animator>();
        bemtevi = GetComponent<AudioSource>();
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
            clicou = true;
            clicouPassaro.Invoke();
            StartCoroutine(som());
        }
    }

    IEnumerator som()
    {
        bemtevi.Play();
        yield return new WaitForSeconds(1.5f);
        bemtevi.Stop();
    }
}
