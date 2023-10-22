using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlacaInteragir : MonoBehaviour
{
    //esse script é um de muitos outros parecidos, esse é o mais genérico que eu achei para exemplificar como funciona
    //a interação com os objetos e personagens, demorou muito tempo para chegar nesse resultado pois eu testei de
    //várias formas diferentes até chegar nisso. Não fiz um script que funciona para todos os objetos pois o sistema
    //que eu usei para fazer o dialogo aparecer (UnityEvents) não me permitia, além de que fazer vários facilitou fazer
    //coisas individuais em cada interação (por exemplo adicionar determinado item apenas em um dialogo especifico)
    [SerializeField]
    private UnityEvent clicouPlaca; //cria um evento para iniciar o dialogo
    private Animator anim; //componente de animação do objeto
    private bool clicou; //verifica se já clicou no objeto
    public GameObject menu; //verifica se o menu está fechado

    void Start()
    {
        anim = GetComponent<Animator>(); //guarda o componente de animação do objeto
    }

    void OnMouseOver() //quando o mouse estiver em cima do objeto
    {
        if(Dialogos.instance.dialogoAberto == false && menu.activeSelf == false && clicou == false) //verifica se o dialogo e o menu estão fechados e se o objeto ainda não foi clicado
        {
            anim.SetBool("mouse", true); //animação de mouse em cima ativa
            BotaoInteragir.instance.SeguirMouse(true); //botão de interagir segue o mouse
            Clicou(); //chama o método de clique
        }
    }

    void OnMouseExit() //quando o mouse sair de cima do objeto
    {
        anim.SetBool("mouse", false); //para a animação de mouse em cima
        BotaoInteragir.instance.SeguirMouse(false); //botão de interagir para de seguir o mouse
    }

    void Clicou() //método de clicar em objetos
    {
        if(Input.GetMouseButtonDown(0)) //se o botão esquerdo do mouse foi clicado
        {
            clicou = true; //diz que já foi clicado
            clicouPlaca.Invoke(); //inicia o dialogo
        }
    }
}
