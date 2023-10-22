using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassarFase : MonoBehaviour
{
    private GameObject player;
    public GameObject fada;
    private Transform cam;
    public Animator transicao;
    public Vector3 playerPosicao, fadaPosicao;
    public float xMaximo;
    public float yMinimo;
    public float tempoTransicao;

    void Start()
    {
        cam = Camera.main.transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator trocarFase()
    {
        player.GetComponent<Player>().enabled = false;
        transicao.SetTrigger("inicio");
        yield return new WaitForSeconds(tempoTransicao);
        player.transform.position = playerPosicao;
        Camera2D.instance.xMax = xMaximo;
        Camera2D.instance.yMin = yMinimo;

        if(InteragirFada.instance.interagiu == true)
        {
            fada.transform.position = fadaPosicao;
        }
        
        transicao.SetTrigger("fim");
        player.GetComponent<Player>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(trocarFase());
        }
    }
}
