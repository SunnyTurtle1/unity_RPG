using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownCamera : MonoBehaviour
{
    /* <카메라 컨트롤러 기능 구현>
     * 1. 플레이어 중심으로 카메라 이동
     * 2. 마우스 오른쪽 버튼 -> 화면 시점 전환된 뒤 고정됨
     * 3. 마우스휠 -> 줌인, 줌아웃
     * (4. NPC와 충돌시 카메라 줌인)
     */

    public GameObject player;
    //화면 로테이션
    private float RotationSpeed = 30.0f;    
    private float RotateX = 40;
    private float RotateY = 0;
    private float yRotateMove;   

    //카메라 위치 고정값
    public float offsetX = 0.0f;
    public float offsetY = 3.0f;
    public float offsetZ = -3.0f;
    public Camera mainCamera;
    private float CamMoveSpeed = 30.0f;
    private Vector3 TargetPos;    

    //줌인 줌아웃
    private float wheelspeed = 20.0f;
    public float ZoomIn = 30f;
    public float ZoomOut = 80.0f;

    private void Start()
    {        
        mainCamera.fieldOfView = 50;
    }
     
    private void FixedUpdate() //플레이어 위치로 카메라 이동
    {
        TargetPos = new Vector3(player.transform.position.x + offsetX,
                                player.transform.position.y + offsetY,
                                player.transform.position.z + offsetZ);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CamMoveSpeed);        
        //Debug.Log("활성화 플레이어 위치 : " + TargetPos);               
    }
    
    void Update()
    {
        transform.rotation = Quaternion.Euler(RotateX, RotateY, 0);
        Zoom();
        MouseRotation();
    }

    #region 줌인,줌아웃
    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * wheelspeed;
        //Debug.Log("distance = " + distance);

        if (distance != 0)
        {
            mainCamera.fieldOfView += distance;
            Debug.Log("줌인줌아웃");
        }
        if (mainCamera.fieldOfView < ZoomIn)
            mainCamera.fieldOfView = ZoomIn;
        if (mainCamera.fieldOfView > ZoomOut)
            mainCamera.fieldOfView = ZoomOut;
    }
    #endregion 줌인,줌아웃 
    
    void MouseRotation() //마우스 오른쪽  -> 회전
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
