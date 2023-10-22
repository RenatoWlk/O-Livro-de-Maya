using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrarCasaMago : MonoBehaviour
{
    private bool clicou;
    public GameObject menu, player, fada, bloqueio;
    private Transform cam;
    public Animator transicao;
    public Vector3 playerPosicao, fadaPosicao;
    public float xMaximo;
    public float yMinimo;
    public float tempoTransicao;
    public AudioClip passosNaCasa;

    void Start()
    {
        cam = Camera.main.transform;
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
            StartCoroutine(EntrarCasa());
        }
    }

    IEnumerator EntrarCasa()
    {
        player.GetComponent<Player>().enabled = false;
        bloqueio.SetActive(true);
        transicao.SetTrigger("inicio");
        yield return new WaitForSeconds(tempoTransicao);
        player.transform.position = playerPosicao;
        player.transform.localScale = new Vector3(1.39f, 1.45f, 1f);
        player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        Camera2D.instance.xMax = xMaximo;
        Camera2D.instance.yMin = yMinimo;
        fada.transform.position = fadaPosicao;
        fada.transform.localScale = new Vector3(1f, 1f, 1f);
        transicao.SetTrigger("fim");
        player.GetComponent<Player>().enabled = true;
        player.GetComponent<AudioSource>().clip = passosNaCasa;
    }

    public void EntrarNaCasa()
    {
        StartCoroutine(EntrarCasa());
    }
}
