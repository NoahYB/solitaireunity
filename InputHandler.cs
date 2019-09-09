using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handleMouseClick();
    }

    private void handleMouseClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag.Equals("Card")|| hit.collider.gameObject.tag.Equals("Hand"))
                {
                    Card(hit.collider.gameObject);
                    if (!hit.collider.gameObject.GetComponent<Click>().isfaceUp && hit.collider.gameObject.GetComponent<Click>() != null)
                    {
                        hit.collider.gameObject.GetComponent<Click>().isfaceUp = true;
                    }
                }
                if (hit.collider.gameObject.tag.Equals("Deck"))
                {
                    Deck();
                }

            }
            else
            {
                GetComponent<GamePlay>().highlitedCards[0].GetComponent<SpriteRenderer>().color = Color.white;
                GetComponent<GamePlay>().highlitedCards.Clear();
            }
        }
    }
    void Deck()
    {
        GetComponent<GamePlay>().DrawFromDeck();
    }
    void Card(GameObject clickedOn)
    {
        GetComponent<GamePlay>().HighlightCard(clickedOn);
    }

}
