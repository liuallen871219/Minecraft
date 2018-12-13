using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayLight : MonoBehaviour {

    public GameObject monstor;
	// Use this for initialization
	void Start () {
        InvokeRepeating("generateMonstor", 1f, 5f);
	}
	public int rotate_speed=5;
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Vector3.zero,Vector3.right,rotate_speed*Time.deltaTime);
        //Debug.Log(transform.eulerAngles);
    }
    public void generateMonstor()
    {

        if (transform.eulerAngles.x < 360 && transform.eulerAngles.x > 270)
        {
            Instantiate(monstor).transform.position = new Vector3(Random.Range(-30, 30), 5, Random.Range(-30, 30));
            Debug.Log("monstor appear");
        }
    }
}
