using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Secreto : MonoBehaviour
{
    private string[] codigo;
    private string[] codigo2;
    private int index;
    private int index2;
    public GameObject secreto, sapo, sombra;
    public TMPro.TMP_InputField velocidade;
    public TMPro.TMP_InputField tamanho;
    public Player player;

    void Start()
    {
        codigo = new string[] {"r", "e", "n", "a", "t", "o"};
        codigo2 = new string[] {"s", "a", "p", "o"};
        index = 0;
        index2 = 0;
        velocidade.text = "4";
    }

    void Update()
    {
        Abrir();
    }

    void Abrir()
    {
        if(Input.anyKeyDown)
        {
            if(Input.GetKeyDown(codigo[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }

        if(index == codigo.Length)
        {
            secreto.SetActive(true);
            index = 0;
        }

        if(Input.anyKeyDown)
        {
            if(Input.GetKeyDown(codigo2[index2]))
            {
                index2++;
            }
            else
            {
                index2 = 0;
            }
        }

        if(index2 == codigo2.Length)
        {
            sapo.SetActive(true);
            player.velocidade = 15;
            velocidade.text = "15";
            sombra.SetActive(false);
            index2 = 0;
        }
    }

    public void Fechar()
    {
        secreto.SetActive(false);
    }

    public void MudarVelocidade(int rogerio)
    {
        rogerio = int.Parse(velocidade.text);
        player.velocidade = rogerio;
    }

    public void MudarTamanho(float roger)
    {
        player.transform.localScale = new Vector3(roger, roger, roger);
    }

    public void TpCaminho()
    {
        player.transform.position = new Vector3(-11.94f, 15.61f, 0f);
    }

    public void TpCaminho2()
    {
        player.transform.position = new Vector3(23.75f, -0.22f, 0f);
    }
    
    public void TpBosque()
    {
        player.transform.position = new Vector3(25.88f, 15.77f, 0f);
    }

    public void TpPantano()
    {
        player.transform.position = new Vector3(-12.47f, 0.19f, 0f);
    }

    public void TpTrilha()
    {
        player.transform.position = new Vector3(23.53f, 32.32f, 0f);
    }
}
