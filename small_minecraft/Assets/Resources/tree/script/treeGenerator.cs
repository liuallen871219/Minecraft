using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        for(int i = 0; i < 5; i++)
            generateTree();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public GameObject block;
    //The material of the leaf block
    public Material leaf;
    //The material of the wood block
    public Material wood;

    int height_min = 10;
    int height_max = 15;
    int volume_min = 10;
    int volume_max = 15;
    public int min_x = -34;
    public int max_x = 70;
    public int min_z = -10;
    public int max_z = 50;

    public void generateTree()
    {
        int rand_x = Random.Range(min_x, max_x);
        int rand_z = Random.Range(min_z, max_z);
        Vector3 pos = new Vector3(rand_x, 0, rand_z);
        Vector3 lastPos = pos;
        int height = Random.Range(height_min, height_max);
        int volume = Random.Range(volume_min, volume_max);
        volume += volume % 2 == 0 ? 1 : 0;
        for (int i = 0; i < height; i++)
        {
            //This is where we instantiate the "block prefab and assign the wood material"
            GameObject blockGO = Instantiate(block);
            blockGO.GetComponent<MeshRenderer>().material = wood;
            blockGO.transform.position = new Vector3(pos.x, lastPos.y + 1f, pos.z);
            lastPos = blockGO.transform.position;
        }
        for (int i = 0; i < volume; i++)
        {
            for (int j = 0; j < volume; j++)
            {
                for (int k = 0; k < volume; k++)
                {
                    if (leafSpawn(i, j, k, volume))
                    {
                        //This is where we instantiate the "block prefab and assign the leaf material"
                        GameObject blockGO = Instantiate(block);
                        blockGO.GetComponent<MeshRenderer>().material = leaf;
                        blockGO.transform.position = new Vector3(
                        lastPos.x - volume / 2 + i,
                        lastPos.y - volume / 2 + j,
                        lastPos.z - volume / 2 + k);
                    }
                }
            }
        }
    }
    bool leafSpawn(int x, int y, int z, int vol)
    {
        float a = Mathf.Abs(-vol / 2 + x);
        float b = Mathf.Abs(-vol / 2 + y);
        float c = Mathf.Abs(-vol / 2 + z);
        float distance = Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2) + Mathf.Pow(c, 2));
        return (distance < vol / 2 && Random.Range(0, vol) > distance);
    }
}
