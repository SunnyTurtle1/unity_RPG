using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownCamera : MonoBehaviour
{
    /* <ī�޶� ��Ʈ�ѷ� ��� ����>
     * 1. �÷��̾� �߽����� ī�޶� �̵�
     * 2. ���콺 ������ ��ư -> ȭ�� ���� ��ȯ�� �� ������
     * 3. ���콺�� -> ����, �ܾƿ�
     * (4. NPC�� �浹�� ī�޶� ����)
     */

    public GameObject player;
    //ȭ�� �����̼�
    private float RotationSpeed = 30.0f;    
    private float RotateX = 40;
    private float RotateY = 0;
    private float yRotateMove;   

    //ī�޶� ��ġ ������
    public float offsetX = 0.0f;
    public float offsetY = 3.0f;
    public float offsetZ = -3.0f;
    public Camera mainCamera;
    private float CamMoveSpeed = 30.0f;
    private Vector3 TargetPos;    

    //���� �ܾƿ�
    private float wheelspeed = 20.0f;
    public float ZoomIn = 30f;
    public float ZoomOut = 80.0f;

    private void Start()
    {        
        mainCamera.fieldOfView = 50;
    }
     
    private void FixedUpdate() //�÷��̾� ��ġ�� ī�޶� �̵�
    {
        TargetPos = new Vector3(player.transform.position.x + offsetX,
                                player.transform.position.y + offsetY,
                                player.transform.position.z + offsetZ);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CamMoveSpeed);        
        //Debug.Log("Ȱ��ȭ �÷��̾� ��ġ : " + TargetPos);               
    }
    
    void Update()
    {
        transform.rotation = Quaternion.Euler(RotateX, RotateY, 0);
        Zoom();
        MouseRotation();
    }

    #region ����,�ܾƿ�
    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * wheelspeed;
        //Debug.Log("distance = " + distance);

        if (distance != 0)
        {
            mainCamera.fieldOfView += distance;
            Debug.Log("�����ܾƿ�");
        }
        if (mainCamera.fieldOfView < ZoomIn)
            mainCamera.fieldOfView = ZoomIn;
        if (mainCamera.fieldOfView > ZoomOut)
            mainCamera.fieldOfView = ZoomOut;
    }
    #endregion ����,�ܾƿ� 
    
    void MouseRotation() //���콺 ������  -> ȸ��
    {
        if (Input.GetMouseButton(1)) 
        {
            yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * RotationSpeed * (-1);
            RotateY = transform.eulerAngles.y + yRotateMove;

            if (RotateY > 60 && RotateY < 180)
                RotateY = 60;
            if (RotateY >= 180 && RotateY < 300)
                RotateY = 300;            
        }

        if (Input.GetMouseButtonUp(1))
            RotateY = 0;            
        //Debug.Log("euler: " + transform.eulerAngles.x + " xR: " + RotateY);
    }
    
}
