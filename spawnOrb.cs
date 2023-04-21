using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnOrb : MonoBehaviour
{
    public GameObject orb;
    public int score;
    public float orbTimer;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > orbTimer)
        {
            Vector2 vec = new Vector2(Random.Range(-8,9), Random.Range(-4,5));
            GameObject.Instantiate(orb, vec, transform.rotation);
            orbTimer = Time.time + 1f;
        }

        text.text = score.ToString();
    }
}
