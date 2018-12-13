using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class base_generator : MonoBehaviour {

    void Awake()
    {
        for (int k = min_y; k <= max_y; k++)
        {
            for (int i = min_x; i <= max_x; i++)
            {
                for (int j = min_z; j <= max_z; j++)
                {
                    Vector3 position = new Vector3(i, k, j);
                    //Debug.Log(position);
                    GameObject blockGO = Instantiate(block);
                    blockGO.GetComponent<MeshRenderer>().material = dirt;
                    blockGO.transform.position = position;
                }
            }
        }
    }
    // Use this for initialization
    void Start()
    {

    }
    public GameObject block;

    public Material dirt;

    public int min_x = -34;
    public int max_x = 70;
    public int min_z = -10;
    public int max_z = 50;
    public int min_y = -4;
    public int max_y = -1;
    // Update is called once per frame
    void Update()
    {

    }
}
