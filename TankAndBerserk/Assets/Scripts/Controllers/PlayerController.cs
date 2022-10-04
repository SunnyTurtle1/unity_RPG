using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{  /* <�÷��̾� ��Ʈ�ѷ� ��� ����>
     * 1. ���콺 ���� -> �̵�
     * 2. Ű���� awsd -> �̵�
     * 3. �� Ŭ�� -> ����
     * 4. ����ĳ��Ʈ -> �浹, Ʈ���� ����
     */
      
    static public float _speed = 5.0f;        
    static public float RotateSpeed = 5.0f;
    static public Vector3 vDir;
              
       
    private void FixedUpdate()
    {
        OnMouse(); //���콺 Ŭ���� �÷��̾� �̵�
        OnKeyboard(); //Ű���� �Է½� �÷��̾� �̵�     
    }

    void Update()
    {
        RayInfo(); //�÷��̾�κ��� �߻�Ǵ� ����              
    }

    static public void OnMouse()
    {
        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(Camera.main.transform.position, ray.direction * 30.0f, Color.blue, 0.5f);
                RaycastHit hit;
                Physics.Raycast(ray, out hit, Mathf.Infinity);

                if (hit.collider.CompareTag("Terrain"))
                {
                    vDir = hit.point - PlayerChoice.Player.transform.position;
                }
                PlayerChoice.Player.transform.position += vDir.normalized * Time.deltaTime * _speed;

                Vector3 newDir = Vector3.RotateTowards(PlayerChoice.Player.transform.forward, vDir.normalized,
                    Time.deltaTime * RotateSpeed, Time.deltaTime * RotateSpeed);
                PlayerChoice.Player.transform.rotation = Quaternion.LookRotation(newDir.normalized);
            }
        }
            
        
    }

    void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            PlayerChoice.Player.transform.rotation = Quaternion.Slerp(PlayerChoice.Player.transform.rotation, Quaternion.LookRotation(Vector3.forward),0.3f);
            PlayerChoice.Player.transform.position += new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * _speed;           
        }

        if (Input.GetKey(KeyCode.S))
        {
            PlayerChoice.Player.transform.rotation = Quaternion.Slerp(PlayerChoice.Player.transform.rotation, Quaternion.LookRotation(Vector3.back), 0.3f);
            PlayerChoice.Player.transform.position += new Vector3(0.0f, 0.0f, -1.0f) * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerChoice.Player.transform.rotation = Quaternion.Slerp(PlayerChoice.Player.transform.rotation, Quaternion.LookRotation(Vector3.left), 0.3f);
            PlayerChoice.Player.transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerChoice.Player.transform.rotation = Quaternion.Slerp(PlayerChoice.Player.transform.rotation, Quaternion.LookRotation(Vector3.right), 0.3f);
            PlayerChoice.Player.transform.position += new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime * _speed;
        }
    }
        

    void RayInfo() 
    {
        Vector3 look = PlayerChoice.Player.transform.TransformDirection(Vector3.forward); //����, ���� ��ǥ ��ȯ
        Debug.DrawRay(PlayerChoice.Player.transform.position, look * 2, Color.red);
        
        RaycastHit hitinfo;
        if (Physics.Raycast(PlayerChoice.Player.transform.position, look, out hitinfo, 2))
        {
            //Debug.Log($"Raycast {hitinfo.collider.gameObject.name}!");
        }
    }

    
}
