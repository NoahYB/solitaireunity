using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GamePlay : MonoBehaviour
{
    public static string[] suits = new string[] { "c", "s", "h", "d" };
    public static string[] values = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13" };


    List<string> deck;

    public List<string> currentCards = new List<string>();

    public List<GameObject> selectedObjects = new List<GameObject>();

    public List<GameObject> highlitedCards = new List<GameObject>();

    public int trips;
    public int tripsmodifier;

    public Sprite[] cardSprites;
    public GameObject[] tableuArray;

    List<string> deckObjs = new List<string>();

    public GameObject cardfab;

    public GameObject deckObject;

    public GameObject cardPlace;

    public List<string> tableuOne = new List<string>();
    public List<string> tableuTwo = new List<string>();
    public List<string> tableuThree = new List<string>();
    public List<string> tableuFour = new List<string>();
    public List<string> tableuFive = new List<string>();
    public List<string> tableuSix = new List<string>();
    public List<string> tableuSeven = new List<string>();

    public List<string>[] tableu;

    public List<GameObject> tableuLocations = new List<GameObject>();

    GameObject card;

    float offsetY = 0.0f;
    float offsetZ = 0.0f;

    public List<string> GenerateDeck()
    {
        List<string> generatedDeck = new List<string>();

        foreach (string i in suits)
        {
            foreach (string j in values)
            {
                generatedDeck.Add(i + j);
            }
        }
        return generatedDeck;

    }

    void Start()
    {
        tableu = new List<string>[]
        {tableuOne,tableuTwo,tableuThree,tableuFour,tableuFive,tableuSix,tableuSeven};

        deck = GenerateDeck();
        Shuffle<string>(deck);
        Sort(deck);
        Deal(deck);
    }
    //https://stackoverflow.com/questions/273313/randomize-a-listt//
    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    void Deal(List<string> deck)
    {
        foreach (string i in deck)
        {
            foreach (Sprite s in cardSprites)
            {
                if (s.name.Equals(i))
                {
                    card = Instantiate(cardfab);
                    card.GetComponent<SpriteRenderer>().sprite = s;
                    card.transform.position = deckObject.transform.position;
                    card.transform.position = new Vector3
                    (card.transform.position.x-100, transform.position.y + 2.75f,
                     transform.position.z + offsetZ);
                    offsetZ -= 6f;
                    card.name = i;
                    card.GetComponent<Attributes>().cardFace = s;
                    card.GetComponent<Click>().isfaceUp = false;
                    card.GetComponent<Click>().isInDeck = true;
                    continue;
                }
            }
        }
        for (int p = 0; p < 7; p++)
        {
            offsetZ = 0.0f;
            offsetY = -1.75f;
            foreach (string i in tableu[p])
            {
                foreach (Sprite s in cardSprites)
                {
                    if (s.name.Equals(i))
                    {
                        card = Instantiate(cardfab);
                        card.GetComponent<SpriteRenderer>().sprite = s;
                        card.transform.position = tableuArray[p].transform.position;
                        offsetZ -= 0.4f;
                        offsetY -= 0.1f;
                        card.transform.position = new Vector3
                        (card.transform.position.x, transform.position.y + offsetY,
                        transform.position.z + offsetZ);
                        card.name = i;
                        card.GetComponent<Attributes>().cardFace = s;
                        if (tableu[p][tableu[p].Count - 1].Equals(card.name))
                        {
                            card.GetComponent<Click>().isfaceUp = true;
                        }
                        else card.GetComponent<Click>().isfaceUp = false;
                        continue;
                    }
                }
            }
        }
    }
    void Sort(List<string> deck)
    {
        for (int i = 0; i < 7; i++)
        {
            print(tableu[i].Count);
            for (int j = i; j < 7; j++)
            {
                tableu[j].Add(deck.Last<string>());

                deck.RemoveAt(deck.Count - 1);
            }
        }
    }
    public void DrawFromDeck()
    {
        if (currentCards.Count >= 1)
        {
            deck.Add(currentCards[0]);
            currentCards.RemoveAt(0);
        }
        currentCards.Add(deck[0]);
        deck.RemoveAt(0);
    }

    public void HighlightCard(GameObject g)
    {
        print(g);
        if (highlitedCards.Count == 1)
        {
            if (!currentCards.Contains(g.name))
            {
                highlitedCards[0].gameObject.transform.position = g.transform.position + new Vector3(0, -0.3f, -.1f);
                currentCards.Remove(highlitedCards[0].name);
            }
            highlitedCards[0].GetComponent<SpriteRenderer>().color = Color.white;
            highlitedCards.RemoveAt(0);
        }
        else
        {
            g.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            highlitedCards.Add(g);
        }
    }

    void Update()
    {
        for (int i = 0; i < currentCards.Count; i++)
        {
            GameObject.Find(currentCards[i]).transform.position = cardPlace.transform.position;
            GameObject.Find(currentCards[i]).GetComponent<Click>().isfaceUp = true;
        }
        for (int i = 0; i < deck.Count; i++)
        {
            GameObject.Find(deck[i]).transform.position = cardPlace.transform.position + new Vector3(-100, 0, 0);
            GameObject.Find(deck[i]).GetComponent<Click>().isfaceUp = false;
        }
    }
}
