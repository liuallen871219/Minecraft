using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstor_AI : MonoBehaviour {
    public GameObject player;
    public GameObject self;
    public Rigidbody monstor;
    public AudioSource sound;
    public int speed = 10;
    public int hp = 5;
	// Use this for initialization
	void Start () {
        monstor = GetComponent<Rigidbody>();
        self = GetComponent<GameObject>();
        player = GameObject.Find("Viking_Sword");
        sound = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        transform.forward = Quaternion.Euler(0, 180, 0) * player.transform.forward * Time.deltaTime * speed;
        transform.position += (player.transform.position - transform.position) / Vector3.Distance(player.transform.position, transform.position) * 3 * Time.deltaTime;

        

    }
    public void attacked()
    {
        hp--;
        monstor.AddForce(player.transform.forward * 1500);
        sound.Play();
    }
}

