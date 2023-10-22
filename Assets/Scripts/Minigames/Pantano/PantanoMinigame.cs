using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PantanoMinigame : MonoBehaviour
{
    private Camera cam;
    public Animator transicao;
    public GameObject[] pegarChaves;
    [SerializeField] private UnityEvent dialogoChave;
    [SerializeField] private UnityEvent atualizarObjetivo;
    public bool minigame;
    private bool iniciar = false, clicouAmarelo = false, clicouAzul = false, clicouRosa = false, clicouVerde = false, pegouChave = false;
    public bool Iniciar { get {return iniciar;} set { if(iniciar != value){ iniciar = value; StartCoroutine(IniciarMG()); } } }
    public bool ClicouAmarelo { get {return clicouAmarelo;} set { if(clicouAmarelo != value){ clicouAmarelo = value; contador++; } } }
    public bool ClicouAzul { get {return clicouAzul;} set { if(clicouAzul != value){ clicouAzul = value; contador++; } } }
    public bool ClicouRosa { get {return clicouRosa;} set { if(clicouRosa != value){ clicouRosa = value; contador++; } } }
    public bool ClicouVerde { get {return clicouVerde;} set { if(clicouVerde != value){ clicouVerde = value; contador++; } } }
    public bool PegouChave { get {return pegouChave;} set { if(pegouChave != value){ pegouChave = value; StartCoroutine(SairMG()); atualizarObjetivo.Invoke(); } } }
    public float tempoTransicao;
    private int contador;
    public static PantanoMinigame instance;
    
    void Start()
    {
        instance = this;
        cam = Camera.main;
    }

    void Update()
    {
        ContadorDeFalas();

        if(contador >= 4 && Dialogos.instance.dialogoAberto == false)
        {
            PegarChave();
        }
    }
    
    public IEnumerator IniciarMG()
    {
        transicao.SetTrigger("inicio");
        yield return new WaitForSeconds(tempoTransicao);
        minigame = true;
        cam.GetComponent<Camera2D>().enabled = false;
        Camera2D.instance.yMin = 65f;
        cam.transform.position = new Vector3(0f, 65f, -10f);
        transicao.SetTrigger("fim");
    }

    public IEnumerator SairMG()
    {
        transicao.SetTrigger("inicio");
        yield return new WaitForSeconds(tempoTransicao);
        minigame = false;
        cam.GetComponent<Camera2D>().enabled = true;
        Camera2D.instance.yMin = 49.5f;
        transicao.SetTrigger("fim");
    }

    void ContadorDeFalas()
    {
        if(SapoAmarelo.instance.clicou == true)
        {
            ClicouAmarelo = true;
        }
        if(SapoAzul.instance.clicou == true)
        {
            ClicouAzul = true;
        }
        if(SapoRosa.instance.clicou == true)
        {
            ClicouRosa = true;
        }
        if(SapoVerde.instance.clicou == true)
        {
            ClicouVerde = true;
        }
    }

    void PegarChave()
    {
        if(contador == 4 && Dialogos.instance.dialogoAberto == false)
        {
            dialogoChave.Invoke();
            contador++;

            for(int i = 0; i < pegarChaves.Length; i++)
            {
                pegarChaves[i].SetActive(true);
            }
        }

        if(AmareloChave.instance.interagiu == true || AzulChave.instance.interagiu == true || VerdeChave.instance.interagiu == true || RosaChave.instance.interagiu == true)
        {
            PegouChave = true;
        }
    }
}
