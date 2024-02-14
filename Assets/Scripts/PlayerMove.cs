using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move using keys
        float horizontalInput = Input.GetAxis("Horizontal"); // 오른쪽 키가 눌려 있으면 1, 왼쪽 키 면 -1, 아무것도 없으면 0
    	float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
    	movement = movement.normalized * speed * Time.deltaTime; // Vector3.Normalize --> magnitude 를 1 로 만들어주는 과정; 대각선으로 가도 더 많이 가지 않도록

    	transform.position += movement;
        //

        //rotate towards mouse pointer
        Vector3 mousePos = Input.mousePosition; //현재 마우스 커서의 위치를 저장하고 있는 변수
        mousePos = Camera.main.ScreenToWorldPoint(mousePos); //Input.mouseposition 은 게임 속 세계의 좌표가 아닌 화면 상의 마우스의 좌표를 주기 때문에 변환 필요
        mousePos = new Vector3(mousePos.x, mousePos.y, 0); //변환하면 z좌표는 카메라의 z좌표를 따르기 때문데 0으로 변환 필요
 
        transform.right = mousePos - transform.position; //플레이어가 mousePos 방향을 바라보게 하는 방법
        //
    }
}
