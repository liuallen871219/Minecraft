using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Controller : MonoBehaviour
{

    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes m_axes = RotationAxes.MouseXAndY;
    public float m_sensitivityX = 10f;
    public float m_sensitivityY = 10f;

    // 水平方向的 镜头转向
    public float m_minimumX = -360f;
    public float m_maximumX = 360f;
    // 垂直方向的 镜头转向 (这里给个限度 最大仰角为45°)
    public float m_minimumY = -45f;
    public float m_maximumY = 45f;

    float m_rotationY = 0f;

    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        
        /* 鎖定視角 */
        Cursor.lockState = CursorLockMode.Locked;
        animator.SetFloat("speed", 0f);

        /* 偵測人物y座標位置 < -10 則會回到y = 0*/

        if (transform.position.y < -20)
        {
            transform.position = new Vector3(transform.position.x, 10, transform.position.z);
            rig.velocity = new Vector3(0, 0, 0);
        }
        //移動
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + speed * Time.deltaTime * transform.forward;
            animator.SetFloat("speed", 0.2f);
        }
        if (Input.GetKey(KeyCode.S))
        {

            transform.position = transform.position + speed * Time.deltaTime * (Quaternion.Euler(0, 180, 0) * transform.forward);
            animator.SetFloat("speed", -0.2f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + speed * Time.deltaTime * (Quaternion.Euler(0, -90, 0) * transform.forward);
            animator.SetFloat("speed", 0.2f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + speed * Time.deltaTime * (Quaternion.Euler(0, 90, 0) * transform.forward);
            animator.SetFloat("speed", 0.2f);
        }
        //跳躍
        if (Input.GetKey(KeyCode.Space) && is_jump == false)
        {
            //Debug.Log(is_jump);
            rig.AddForce(jumping_force * Vector3.up);
            is_jump = true;
        }


        /* 滑鼠左鍵 collection 或是 putting */
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit ray_cast_hit;
            if (Physics.Raycast(ray, out ray_cast_hit))
            {
                //Debug.Log(ray_cast_hit.collider.gameObject.name);
                //Debug.Log(ray_cast_hit.collider.gameObject.GetComponent<MeshRenderer>().material.name);
                if (add_item.select != true)
                {
                    Debug.Log(ray_cast_hit.collider.gameObject.GetComponent<MeshRenderer>().material.name);
                    if (ray_cast_hit.collider.gameObject.GetComponent<MeshRenderer>().material.name == "grass (Instance)" || ray_cast_hit.collider.gameObject.GetComponent<MeshRenderer>().material.name == "grass(Instance)")
                    {
                        material_name = "grass(Instance)";
                    }
                    else if (ray_cast_hit.collider.gameObject.GetComponent<MeshRenderer>().material.name == "wood (Instance)" || ray_cast_hit.collider.gameObject.GetComponent<MeshRenderer>().material.name == "wood(Instance)")
                    {
                        material_name = "wood(Instance)";
                    }
                    else if (ray_cast_hit.collider.gameObject.GetComponent<MeshRenderer>().material.name == "dirt (Instance)" || ray_cast_hit.collider.gameObject.GetComponent<MeshRenderer>().material.name == "dirt(Instance)")
                    {
                        material_name = "dirt(Instance)";
                    }
                    //Debug.Log(material_name);
                    if (ray_cast_hit.collider.gameObject.name != "monstor(Clone)")
                    {
                        Destroy(ray_cast_hit.collider.gameObject);
                        return;
                    }
                    else
                    {
                        ray_cast_hit.collider.gameObject.GetComponent<monstor_AI>().attacked();
                        if (ray_cast_hit.collider.gameObject.GetComponent<monstor_AI>().hp <= 0)
                        {
                            Destroy(ray_cast_hit.collider.gameObject);
                        }
                    }
                }

                else
                {
                    GameObject blockGO = Instantiate(block);
                    if(add_item.select_material_name == "grass_item" && add_item.grass_count > 0)
                    {
                        blockGO.GetComponent<MeshRenderer>().material = grass;
                        blockGO.transform.position = ray_cast_hit.point + new Vector3(0, 0.5f, 0);
                        add_item.grass_count--;
                    }
                    else if (add_item.select_material_name == "dirt_item" && add_item.dirt_count > 0)
                    {
                        blockGO.GetComponent<MeshRenderer>().material = dirt;
                        blockGO.transform.position = ray_cast_hit.point + new Vector3(0, 0.5f, 0);
                        add_item.dirt_count--;
                    }
                    else if (add_item.select_material_name == "wood_item" && add_item.wood_count > 0)
                    {
                        blockGO.GetComponent<MeshRenderer>().material = wood;
                        blockGO.transform.position = ray_cast_hit.point + new Vector3(0, 0.5f, 0);
                        add_item.wood_count--;
                    }
                }
            }
        }



        //視野隨者滑鼠改變
        if (m_axes == RotationAxes.MouseXAndY)
        {
            float m_rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * m_sensitivityX;
            m_rotationY += Input.GetAxis("Mouse Y") * m_sensitivityY;
            m_rotationY = Mathf.Clamp(m_rotationY, m_minimumY, m_maximumY);

            transform.localEulerAngles = new Vector3(-m_rotationY, m_rotationX, 0);
        }
        else if (m_axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * m_sensitivityX, 0);
        }
        else
        {
            m_rotationY += Input.GetAxis("Mouse Y") * m_sensitivityY;
            m_rotationY = Mathf.Clamp(m_rotationY, m_minimumY, m_maximumY);

            transform.localEulerAngles = new Vector3(-m_rotationY, transform.localEulerAngles.y, 0);
        }
        //Debug.Log(Input.GetAxis("Mouse X"));
        //Debug.Log(Input.GetAxis("Mouse Y"));



        /* 按 Esc 回主畫面 */
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }


    public bool is_jump = false;
    public float speed, jumping_force;
    public Rigidbody rig;
    public Material grass;
    public Material dirt;
    public Material wood;
    public Animator animator;
    public GameObject block;




    public static string material_name;

    void OnCollisionEnter(Collision c)
    {
        if (c.collider)
        {
            is_jump = false;
            //Debug.Log("yes");
        }
        //Debug.Log(c.transform.name);
    }
}
