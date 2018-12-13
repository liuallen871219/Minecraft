using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_camera : MonoBehaviour {

    public GameObject cam1, cam2;
    // Use this for initialization
    void Start () {
		
	}
    void Awake()
    {
        cam2.SetActive(false);
        cam1.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cam1.SetActive(false);

            cam2.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            cam1.SetActive(true);

            cam2.SetActive(false);
        }
    }
}
