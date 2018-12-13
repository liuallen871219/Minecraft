using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tool_click : MonoBehaviour {

    public Image img;
    public Sprite grass_item;
    public int count = 0;

    public void useThisTool()
    {
        /* count += 1;
         if (count % 2 == 1)
             img.GetComponent<Image>().color = Color.white;
         else
             img.GetComponent<Image>().color = Color.green;*/
        Debug.Log(Controller.material_name == "grass(Instance)");
        if(Controller.material_name == "grass (Instance)")
        {
            img.GetComponent<Image>().sprite = grass_item;
        }
    }
}
