using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class add_item : MonoBehaviour
{

    public Sprite grass_item;
    public Sprite dirt_item;
    public Sprite wood_item;


    public static int grass_count = 0;
    public static int dirt_count = 0;
    public static int wood_count = 0;


    public static string select_material_name = "";
    public static bool select = false;

    [SerializeField]Transform UIPanel;


    void Awake()
    {

    }
    void Update()
    {
        

        /* 偵測選取哪一個道具欄 */
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < 6; i++)
            {
                UIPanel.GetChild(i).GetComponent<Image>().color = Color.white;
            }
            UIPanel.GetChild(0).GetComponent<Image>().color = Color.red;
            select_material_name = UIPanel.GetChild(0).GetChild(1).GetComponent<Image>().sprite.name;
            select = true;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int i = 0; i < 6; i++)
            {
                UIPanel.GetChild(i).GetComponent<Image>().color = Color.white;
            }
            UIPanel.GetChild(1).GetComponent<Image>().color = Color.red;
            select_material_name = UIPanel.GetChild(1).GetChild(1).GetComponent<Image>().sprite.name;
            select = true;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            for (int i = 0; i < 6; i++)
            {
                UIPanel.GetChild(i).GetComponent<Image>().color = Color.white;
            }
            UIPanel.GetChild(2).GetComponent<Image>().color = Color.red;
            select_material_name = UIPanel.GetChild(2).GetChild(1).GetComponent<Image>().sprite.name;
            select = true;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            for (int i = 0; i < 6; i++)
            {
                UIPanel.GetChild(i).GetComponent<Image>().color = Color.white;
            }
            UIPanel.GetChild(3).GetComponent<Image>().color = Color.red;
            select_material_name = UIPanel.GetChild(3).GetChild(1).GetComponent<Image>().sprite.name;
            select = true;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            for (int i = 0; i < 6; i++)
            {
                UIPanel.GetChild(i).GetComponent<Image>().color = Color.white;
            }
            UIPanel.GetChild(4).GetComponent<Image>().color = Color.red;
            select_material_name = UIPanel.GetChild(4).GetChild(1).GetComponent<Image>().sprite.name;
            select = true;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            for (int i = 0; i < 6; i++)
            {
                UIPanel.GetChild(i).GetComponent<Image>().color = Color.white;
            }
            UIPanel.GetChild(5).GetComponent<Image>().color = Color.red;
            select_material_name = UIPanel.GetChild(5).GetChild(1).GetComponent<Image>().sprite.name;
            select = true;
        }
        else if(Input.GetMouseButtonDown(1))
        {
            for (int i = 0; i < 6; i++)
            {
                UIPanel.GetChild(i).GetComponent<Image>().color = Color.white;
            }
            select = false;
        }
        //Debug.Log(select_material_name);



        /* 偵測蒐集到甚麼道具 */
        if (Controller.material_name == "grass(Instance)")
        {
            grass_count++;
            //Debug.Log(grass_count);
            Controller.material_name = "";
            return;
        }
        else if (Controller.material_name == "dirt(Instance)")
        {
            dirt_count++;
            //Debug.Log(dirt_count);
            Controller.material_name = "";
            return;
        }
        else if (Controller.material_name == "wood(Instance)")
        {
            wood_count++;
            //Debug.Log(wood_count);
            Controller.material_name = "";
            return;
        }
        UIPanel.GetChild(0).GetChild(2).GetComponent<Text>().text = grass_count.ToString();
        UIPanel.GetChild(1).GetChild(2).GetComponent<Text>().text = dirt_count.ToString();
        UIPanel.GetChild(2).GetChild(2).GetComponent<Text>().text = wood_count.ToString();

    }
}
