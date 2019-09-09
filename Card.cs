using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card: MonoBehaviour  
{
    public string suit;
    public Sprite cardFace;
    public Sprite cardBack;
    public virtual void setFace(Sprite face)
    {
        cardFace = face;
    }
}
