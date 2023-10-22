using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public float velocidade; //velocidade de movimento do jogador
    private bool andando; //verifica se o jogador está andando
    private bool minigame; //verifica se algum minigame está ativo
    public bool comecarTutorial; //verifica se o tutorial começou e está ativo
    private Animator anim; //componente de animação do jogador
    private AudioSource passos; //componente de reprodução de áudio do jogador (é o áudio dos passos)
    public GameObject menu; //verifica se o menu está ativo
    public UnityEvent dialogoInicio; //dialogo do começo
    public static Player instance; //usarei variáveis desse script em outros

    void Start()
    {
        anim = GetComponent<Animator>(); //guarda o componente de animação na variável
        passos = GetComponent<AudioSource>(); //guarda o componente de reprodução de áudio na variável
        instance = this;
        StartCoroutine(DialogoIniciar()); //inicia a coroutina do primeiro dialogo quando a cena inicia
    }

    void Update()
    {
        if(andando && !passos.isPlaying) //se estiver andando e o áudio de passos não estiver sendo reproduzido 
        {
            passos.Play(); //toca o áudio
        }
        if(!andando) //se não estiver andando
        {
            passos.Stop(); //para o áudio
        }

        minigame = Minigame.estaEmMinigame();
    }

    void FixedUpdate()
    {
        if(Dialogos.instance.dialogoAberto == true && anim.GetBool("andar") == true) //se o dialogo estiver aberto e está tocando a animação de andar
        {
            anim.SetBool("andar", false); //para a animação de andar
            andando = false; //para de andar
        }

        if(menu.activeSelf == true && anim.GetBool("andar") == true) //se o menu estiver aberto e está tocando a animação de andar
        {
            anim.SetBool("andar", false); //para a animação de andar
            andando = false; //para de andar
        }

        if(Dialogos.instance.dialogoAberto == false && menu.activeSelf == false && minigame == false && comecarTutorial == false) //verifica se o dialogo, menu, minigames e tutorial estão inativos
        {
            Move(); //chama o método de andar
        }
    }

    void Move() //método de andar
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); //vetor de movimento que guarda a direção que o input do jogador horizontal (setas ou A e D) está indo
        transform.position += movimento * velocidade * Time.deltaTime; //a posição do jogador é a direção vezes a velocidade vezes o tempo (conta básica para qualquer movimento)

        if(Input.GetAxis("Horizontal") > 0f) //se o input horizontal for para a direita
        {
            anim.SetBool("andar", true); //começa animação de andar
            andando = true; //diz que está andando
            transform.eulerAngles = new Vector3(0f, 0f, 0f); //rotaciona para a direita
        }
        
        if(Input.GetAxis("Horizontal") < 0f) //se o input horizontal for para a esquerda
        {
            anim.SetBool("andar", true); //começa animação de andar
            andando = true; //diz que está andando
            transform.eulerAngles = new Vector3(0f, 180f, 0f); //rotaciona para a esquerda
        }

        if(Input.GetAxis("Horizontal") == 0f) //se não tiver nenhum input horizontal do jogador
        {
            anim.SetBool("andar", false); //para a animação de andar
            andando = false; //diz que não está andando
        }
    }

    IEnumerator DialogoIniciar() //coroutina para iniciar o dialogo no começo do jogo
    {
        yield return new WaitForSeconds(0.7f); //espera 0.7 segundos
        dialogoInicio.Invoke(); //inicia o dialogo
        comecarTutorial = true; //começa o tutorial
    }
}
