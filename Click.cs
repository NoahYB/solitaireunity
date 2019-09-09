using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public bool isfaceUp;
    public bool isSelected;
    public bool isInDeck;
    private Attributes attributes;
    private SpriteRenderer spriteRenderer;
    GamePlay gamePlay;
    // Start is called before the first frame update
    void Start()
    {
        attributes = GetComponent<Attributes>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gamePlay = GameObject.Find("Solitaire").GetComponent<GamePlay>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isfaceUp)
        {
            spriteRenderer.sprite = attributes.cardFace;
        }
        else
        {
            spriteRenderer.sprite = attributes.cardBack;
        }

    }








}
