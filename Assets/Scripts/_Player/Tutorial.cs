using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject botaoProximo, imagem1, imagem2, menu, desfoqueDialogo, setaTutorial, teclas;
    [SerializeField] private UnityEvent dialogoTutorial;
    public UnityEvent dialogoTutorial2;
    private int contador1, contador2;
    private bool comecar = false, clicouMenu, tutorialMenu, clicouVoltar, comecou;
    public bool tutorialMenu2;
    public bool clicouArvore = true;
    public bool ComecarTutorial { get {return comecar;} set { if(comecar != value){ comecar = value; dialogoTutorial.Invoke(); imagem1.SetActive(true); botaoProximo.SetActive(false); } } }
    public static Tutorial instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(Player.instance.comecarTutorial == true && Dialogos.instance.dialogoAberto == false && comecou == false)
        {
            comecou = true;
            ComecarTutorial = true;
            clicouMenu = true;
        }

        if(ArvoreInteragir.instance.comecarTutorial2 == true && Dialogos.instance.dialogoAberto == false)
        {
            ArvoreInteragir.instance.comecarTutorial2 = false;
            tutorialMenu2 = true;
            dialogoTutorial2.Invoke();
            botaoProximo.SetActive(false); 
        }

        if(tutorialMenu)
        {
            TutorialMenu();
        }

        if(tutorialMenu2)
        {
            TutorialParte2();
        }
    }

    public void BotaoMenuClicado()
    {
        if(clicouMenu)
        {
            clicouMenu = false;
            tutorialMenu = true;
            menu.SetActive(true);
            Destroy(imagem1);
            desfoqueDialogo.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
            Dialogos.instance.ProximaFrase();
        }
    }

    void TutorialMenu()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Dialogos.instance.ProximaFrase();
            contador1++;
        }

        if(contador1 == 1)
        {
            setaTutorial.SetActive(true);
        }

        if(contador1 == 2)
        {
            setaTutorial.transform.localPosition = new Vector3(442f, -8f, 0f);
        }
        
        if(contador1 == 3)
        {
            setaTutorial.transform.localPosition = new Vector3(442f, -170f, 0f);
        }

        if(contador1 == 4)
        {
            contador1++;
            Destroy(setaTutorial);
            desfoqueDialogo.SetActive(false);
            tutorialMenu = false;
            clicouVoltar = true;
        }
    }

    public void ClicouBotaoVoltar()
    {
        if(clicouVoltar)
        {
            clicouVoltar = false;
            clicouArvore = false;
            Dialogos.instance.ProximaFrase();
            desfoqueDialogo.GetComponent<Image>().color = new Color32(0, 0, 0, 90);
            imagem2.SetActive(true);
        }
    }

    void TutorialParte2()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Dialogos.instance.dialogoAberto = true;
            Dialogos.instance.ProximaFrase();
            contador2++;
        }

        if(contador2 == 1)
        {
            StartCoroutine(AparecerTeclas());
        }

        if(contador2 == 2)
        {
            StopAllCoroutines();
            desfoqueDialogo.SetActive(true);
            teclas.SetActive(false);
        }
        
        if(contador2 == 3)
        {
            contador2++;
            tutorialMenu2 = false;
            teclas.SetActive(false);
            Player.instance.comecarTutorial = false;
            Dialogos.instance.dialogoAberto = false;
            botaoProximo.SetActive(true);
            Destroy(gameObject);
        }
    }

    IEnumerator AparecerTeclas()
    {
        yield return new WaitForSeconds(1.5f);
        teclas.SetActive(true);
    }
}
