using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoStorage : MonoBehaviour
{
    // games
    public GameObject[] games;
    public int gameSelected;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        infoStorage[] exist;
        exist = FindObjectsOfType<infoStorage>();
        if (exist.Length != 1)
        {
            Destroy(this.gameObject);
        }
    }
}
