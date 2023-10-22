using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MagoDialogo : MonoBehaviour
{
    [SerializeField]
    private UnityEvent dialogoMagoInicio;
    public bool iniciou;
    public bool interagiu;

    void Update()
    {
        if(Dialogos.instance.dialogoAberto == false && iniciou && !interagiu)
        {
            MagoMinigame.instance.Iniciar = true;
            interagiu = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(IniciarDialogo());
        }
    }

    IEnumerator IniciarDialogo()
    {
        yield return new WaitForSeconds(1f);
        dialogoMagoInicio.Invoke();
        iniciou = true;
        gameObject.transform.position = new Vector3(-100, -100, 0);
    }
}
