using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AzulChave : MonoBehaviour
{
    [SerializeField]
    private UnityEvent chaveAzul;
    public bool clicou;
    public bool interagiu;
    public GameObject menu;
    public static AzulChave instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(Dialogos.instance.dialogoAberto == false && clicou)
        {
            interagiu = true;
        }
    }

    void OnMouseOver()
    {
        if(clicou == false)
        {
            PegarChave.instance.SeguirMouse(true);
        }
        Clicou();
    }

    void OnMouseExit()
    {
        PegarChave.instance.SeguirMouse(false);
    }

    void Clicou()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) 
            {
                if(hit.collider.tag == "Pegar Chave Azul" && Dialogos.instance.dialogoAberto == false && menu.activeSelf == false && clicou == false)
                {
                    clicou = true;
                    chaveAzul.Invoke();
                }
            }
        }
    }
}
