using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayLight : MonoBehaviour {

    public GameObject monstor;
    private GameObject clone;
    public List<GameObject> monstor_list =new List<GameObject>();
	// Use this for initialization
	void Start () {
        InvokeRepeating("generateMonstor", 1f, 5f);
	}
	public int rotate_speed=5;
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(rotate_speed, 0, 0)*Time.deltaTime);
        //Debug.Log(transform.eulerAngles);
        if(!(transform.eulerAngles.x < 360 && transform.eulerAngles.x > 270))
        {
            foreach(GameObject monstor in monstor_list)
            {
                Destroy(monstor);
            }
            monstor_list.Clear();
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            rotate_speed = 20;
        }
        if (Input.GetKeyUp(KeyCode.F4))
        {
            rotate_speed = 5;
        }

    }
    public void generateMonstor()
    {

        if (transform.eulerAngles.x < 360 && transform.eulerAngles.x > 270)
        {

            clone = Instantiate(monstor);
            clone.transform.position = new Vector3(Random.Range(-30f, 30f), 5, Random.Range(-30f,30f));
            monstor_list.Add(clone);
            Debug.Log("monstor appear");
        }
        if (Input.GetKey(KeyCode.F4))
        {
            transform.rotation = Quaternion.Euler(180, 0, 0) * transform.rotation;
        }

    }
}
