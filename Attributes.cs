using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;

    private Click click;
    private GamePlay gamePlay;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        click = GetComponent<Click>();
    }
    // Update is called once per frame
    void Update()
    {
    }
}
