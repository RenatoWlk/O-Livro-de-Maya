using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SairCasaMago : MonoBehaviour
{
    private GameObject player;
    private Transform cam;
    public Animator transicao;
    public Vector3 playerPosicao;
    public float xMaximo;
    public float yMinimo;
    public float tempoTransicao;
    public AudioClip passosNaGrama;

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
        player.transform.localScale = new Vector3(1.09f, 1.15f, 1f);
        Camera2D.instance.xMax = xMaximo;
        Camera2D.instance.yMin = yMinimo;
        transicao.SetTrigger("fim");
        player.GetComponent<Player>().enabled = true;
        player.GetComponent<AudioSource>().clip = passosNaGrama;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(trocarFase());
        }
    }
}
