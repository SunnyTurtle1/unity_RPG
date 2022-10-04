using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoice : MonoBehaviour
{
    Button btn;
    public static GameObject Player;
    public static bool vEndReset = false;
    static Rigidbody nopush;
    
    public void Start()
    {
        
        btn = transform.GetComponent<Button>();
        
        if (btn != null)
        {
            btn.onClick.AddListener(PlayerSelect); //버튼 클릭하면 함수 구현
        }
        if (Player == null)
            Player = GameObject.Find("Tank");                      
    }
    


    public void PlayerSelect() //클릭한 버튼에 따라서 플레이 캐릭터가 달라짐
    {
        switch (btn.name)
        {
            case "Tank_Card":
                Player = GameObject.Find("Tank");
                break;
            case "Berserk_Card":
                Player = GameObject.Find("Berserk");
                break;
            case "Healery_Card":
                Player = GameObject.Find("Healery");
                break;
            case "Boxman_Card":
                Player = GameObject.Find("Boxman");
                break;
        }


        //if (btn.name == "Tank_Card")
        //{
        //    Player = GameObject.Find("Tank");
        //    nopush = GetComponent<Rigidbody>();
        //    nopush.velocity = Vector3.zero;
        //}
        //else if (btn.name == "Berserk_Card")
        //{
        //    Player = GameObject.Find("Berserk");
        //}
        //else if (btn.name == "Healery_Card")
        //{
        //    Player = GameObject.Find("Healery");
        //}
        //else if (btn.name == "Boxman_Card")
        //{
        //    Player = GameObject.Find("Boxman");
        //}
        //else
        //    return;

    }

}
