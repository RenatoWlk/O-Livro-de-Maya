using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogos : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Nome; //guarda o texto do nome da cena
    [SerializeField]
    private TextMeshProUGUI Texto; //guarda o texto do texto da cena
    [SerializeField]
    private Image Reacao; //guarda a imagem da reação da cena
    [SerializeField]
    private AudioSource Dublagem; //guarda o componente de reprodução de áudio do objeto que reproduz o áudio na cena
    [SerializeField]
    private GameObject CaixaDialogo; //guarda o objeto da caixa de dialogo da cena
    public bool dialogoAberto; //verifica se o dialogo está aberto ou não (usei em outros scripts)
    public int contador = 0; //contador da frase atual
    public Dialogo dialogoAtual; //guarda o dialogo atual
    public static Dialogos instance; //usarei a variável dialogo aberto em outros scripts

    void Start()
    {
        instance = this;
    }

    public void Inicializa(Dialogo dialogo) //método para inicializar o dialogo, que leva como parâmetro um dialogo
    {
        Texto.text = ""; //limpa o texto
        dialogoAberto = true; //dialogo está aberto
        contador = 0; //inicia o contador
        dialogoAtual = dialogo; //faz a variável de dialogo atual ser a variável passada
        ProximaFrase(); //chama o método de próxima frase
    }

    public void ProximaFrase() 
    {
        if(dialogoAtual == null)
        {
            return; //se a variável dialogo atual for vazio ele fecha o dialogo e não roda o método
        }

        if(contador == dialogoAtual.GetFrases().Length) //se o contador for do mesmo tamanho do tanto de frases do dialogo (significa que ele acabou) 
        {
            CaixaDialogo.gameObject.SetActive(false); //fecha a caixa de dialogo
            dialogoAtual = null; //limpa a variável de dialogo atual
            contador = 0; //limpa o contador
            dialogoAberto = false; //dialogo está fechado
            Dublagem.Stop(); //para o áudio da dublagem caso esteja tocando
            return; //para de rodar o método
        }

        //se tiver dialogo e não tiver acabado o dialogo
        Nome.text = dialogoAtual.GetFrases()[contador].GetNome(); //faz o texto na cena de nome ser o mesmo do dialogo atual
        Dublagem.Stop(); //para a dublagem caso esteja tocando a anterior
        StopAllCoroutines(); //para todas as coroutinas (para de digitar texto na cena) 
        StartCoroutine(DisplayText(dialogoAtual.GetFrases()[contador].GetFrase())); //começa a digitar o texto do dialogo atual
        Reacao.sprite = dialogoAtual.GetFrases()[contador].GetReacao(); //faz o sprite da reação virar o sprite do dialogo atual
        Dublagem.clip = dialogoAtual.GetFrases()[contador].GetDublagem(); //faz o áudio do componente do objeto que toca as dublagens ser o mesmo do dialogo atual
        Dublagem.Play(); //toca o áudio
        CaixaDialogo.gameObject.SetActive(true); //ativa a caixa de dialogo
        contador++; //aumenta o contador em 1 (o contador serve para controlar qual é a frase atual das frases atuais do dialogo atual)
    }

    IEnumerator DisplayText(string fraseAtual) //coroutina para dar um efeito de maquina de escrever no texto do dialogo (escreve aos poucos), leva como parâmetro a frase atual
    {
        Texto.text = ""; //limpa o texto
        foreach(char letra in fraseAtual.ToCharArray()) //para cada letra na frase atual
        {
            Texto.text += letra; //aumenta uma letra no texto da cena
            yield return new WaitForSeconds(0.035f); //espera alguns milisegundos
        }
    }
}
