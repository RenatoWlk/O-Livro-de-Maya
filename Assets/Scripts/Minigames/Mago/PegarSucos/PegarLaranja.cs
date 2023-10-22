using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarLaranja : MonoBehaviour
{
    public bool clicou;
    private MoverAteMenu moverAteMenu;
    public GameObject menu;
    public GameObject objeto;
    public static PegarLaranja instance;

    void Start()
    {
        moverAteMenu = GetComponent<MoverAteMenu>();
        instance = this;
    }

    void OnMouseOver()
    {
        if(Dialogos.instance.dialogoAberto == false && menu.activeSelf == false && clicou == false)
        {
            PegarSuco.instance.SeguirMouse(true);
            objeto.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 50);
            Clicou();
        }
    }

    void OnMouseExit()
    {
        PegarSuco.instance.SeguirMouse(false);
        objeto.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

    void Clicou()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if(hit.collider != null) 
            {
                if(hit.collider.tag == "Laranja")
                {
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    moverAteMenu.irAteHUD = true;
                    clicou = true;
                    Inventario.instance.AdicionarItem(4);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        objeto = collision.gameObject;

        if(objeto.name == "Poção de Mirtilo" || objeto.name == "Poção de Morango")
        {
            objeto = null;
        }
    }
}
