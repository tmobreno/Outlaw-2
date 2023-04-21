using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piecePlacer : MonoBehaviour
{
    public GameObject obj;
    public Data[] data;

    // Start is called before the first frame update
    void Start()
    {
        createObject();
    }

    void createObject()
    {
        for (int i = 0; i < data.Length; i++)
        {
            var ob = Instantiate(obj, new Vector3(data[i].xVal/2, data[i].yVal/2, 0), transform.rotation);
            ob.transform.parent = gameObject.transform;
        }
    }

    [System.Serializable]
    public class Data
    {
        public float xVal;
        public float yVal;
    }

}
