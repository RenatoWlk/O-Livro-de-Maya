using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SapoRosa : MonoBehaviour
{
    [SerializeField]
    private UnityEvent dialogoRosa;
    public bool clicou;
    public GameObject menu;
    public static SapoRosa instance;

    void Start()
    {
        instance = this;
    }

    void OnMouseOver()
    {
        if(clicou == false)
        {
            InteragirMinigame.instance.SeguirMouse(true);
        }
        Clicou();
    }

    void OnMouseExit()
    {
        InteragirMinigame.instance.SeguirMouse(false);
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
                if(hit.collider.tag == "Rosa" && Dialogos.instance.dialogoAberto == false && menu.activeSelf == false && clicou == false)
                {
                    clicou = true;
                    dialogoRosa.Invoke();
                }
            }
        }
    }
}
