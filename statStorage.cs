using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statStorage : MonoBehaviour
{
    public int p1score, p2score;
    public Text text1, text2;
    public Image selected;
    public RectTransform[] rects;

    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<infoStorage>().gameSelected > 0)
        {
            Instantiate(FindObjectOfType<infoStorage>().games[FindObjectOfType<infoStorage>().gameSelected]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        text1.text = p1score.ToString();
        text2.text = p2score.ToString();
        if (FindObjectOfType<infoStorage>().gameSelected == 0)
        {
            selected.transform.position = rects[0].transform.position;
        }
        if (FindObjectOfType<infoStorage>().gameSelected == 1)
        {
            selected.transform.position = rects[1].transform.position;
        }
        if (FindObjectOfType<infoStorage>().gameSelected == 2)
        {
            selected.transform.position = rects[2].transform.position;
        }
        if (FindObjectOfType<infoStorage>().gameSelected == 3)
        {
            selected.transform.position = rects[3].transform.position;
        }
    }

    public void one()
    {
        FindObjectOfType<infoStorage>().gameSelected = 0;
    }
    public void two()
    {
        FindObjectOfType<infoStorage>().gameSelected = 1;
    }
    public void three()
    {
        FindObjectOfType<infoStorage>().gameSelected = 2;
    }
    public void four()
    {
        FindObjectOfType<infoStorage>().gameSelected = 3;
    }
}
