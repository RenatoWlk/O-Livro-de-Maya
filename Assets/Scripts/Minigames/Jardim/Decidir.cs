using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Decidir : MonoBehaviour
{
    [SerializeField] private UnityEvent dialogoDecidir;
    public GameObject minigameBotoes;
    public bool clicou;
    public static Decidir instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(Dialogos.instance.dialogoAberto == false && clicou)
        {
            JardimMinigame.instance.SairMinigame();
            clicou = false;
        }
    }

    public void DecidirDisco()
    {
        dialogoDecidir.Invoke();
        clicou = true;
        minigameBotoes.SetActive(false);
        JardimMinigame.instance.GirassoisNormais();
    }
}
