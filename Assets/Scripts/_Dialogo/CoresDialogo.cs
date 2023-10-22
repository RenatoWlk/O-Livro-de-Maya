using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoresDialogo : MonoBehaviour
{
    //script para mudar a cor dos nomes no diálogo (aproveitei e usei para redimensionar a imagem das reações baseado nos nomes do personagens pois antes as reações ficavam espremidas)
    [SerializeField]
    private TextMeshProUGUI Nome; //Texto do nome do dialogo
    [SerializeField]
    private Image Reacao; //Imagem da reação
    private RectTransform imagemRT; //Transform da reação

    void Start()
    {
        imagemRT = Reacao.GetComponent<RectTransform>(); //guarda o transform da reação na variável
    }
    
    void Update()
    {
        CoresNome();
    }

    void CoresNome() //método para mudar as cores e os tamanhos baseado no nome
    {
        if(Nome.text == "Maya")
        {
            Nome.color = new Color32(101, 121, 186, 255);
            TamanhoNormal();
        }

        if(Nome.text == "Fleury, a bela fada")
        {
            Nome.color = new Color32(255, 0, 102, 255);
            TamanhoNormal();
        }

        if(Nome.text == "Tales, o elfo cozinheiro")
        {
            Nome.color = new Color32(220, 127, 2, 255);
            TamanhoTales();
        }

        if(Nome.text == "Herbert, o ogro")
        {
            Nome.color = new Color32(56, 86, 35, 255);
            TamanhoHerbert();
        }

        if(Nome.text == "Mago")
        {
            Nome.color = new Color32(57, 35, 143, 255);
            TamanhoMago();
        }

        if(Nome.text == "Pássaro")
        {
            Nome.color = new Color32(118, 113, 113, 255);
        }

        if(Nome.text == "Placa")
        {
            Nome.color = new Color32(118, 113, 113, 255);
        }

        if(Nome.text == "Sapo verde")
        {
            Nome.color = new Color32(0, 176, 80, 255);
        }

        if(Nome.text == "Sapo amarelo")
        {
            Nome.color = new Color32(150, 150, 0, 255);
        }

        if(Nome.text == "Sapo azul")
        {
            Nome.color = new Color32(0, 32, 96, 255);
        }

        if(Nome.text == "Sapo rosa")
        {
            Nome.color = new Color32(255, 102, 153, 255);
        }

        if(Nome.text == "Girassol" || Nome.text == "Girassóis")
        {
            Nome.color = new Color32(150, 150, 0, 255);
        }
    }

    void TamanhoNormal()
    {
        imagemRT.sizeDelta = new Vector2(255f, 265f); //tamanho da imagem
        imagemRT.localPosition = new Vector3(267f, -27.51999f, 0f); //posição da imagem
    }

    void TamanhoTales()
    {
        imagemRT.sizeDelta = new Vector2(255f, 355f);
        imagemRT.localPosition = new Vector3(267f, 26.7f, 0f);
    }

    void TamanhoHerbert()
    {
        imagemRT.sizeDelta = new Vector2(300f, 265f);
        imagemRT.localPosition = new Vector3(267f, -20f, 0f);
    }

    void TamanhoMago()
    {
        imagemRT.sizeDelta = new Vector2(255f, 432f);
        imagemRT.localPosition = new Vector3(267f, 66f, 0f);
    }
}
