using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject bullet; //총알 오브젝트의 reference 가 있어야 총알을 쏘라고 명령할 수 있다
    public float speed = 10;

    private float shootDelay = 0.3f; //한번 bullet 을 쏘고 난뒤 다음 bullet 을 쏠 수 있을 때까지의 시간 (초)
    private float lastShoot = 0f; //맨 마지막 bullet 을 쏘고 지난 시간

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
 
		Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
		transform.up = direction; //플레이어가 mousePos 방향을 바라보게 하는 방법
        //


        //shoot bullet when mouse clicked
        if(Input.GetMouseButton(0)) //마우스 왼쪽버튼이 눌린 상태면 true를 반환하는 함수
        {
            if(lastShoot >= shootDelay) //마지막 쐈을 때부터 지난 시간이 쿨타임을 지나가면
            {
                Instantiate(bullet, transform.position, transform.rotation); //새로운 오브젝트를 생성시키는 함수 (생성 위치와 처음 방향을 정할 수 있다)
                lastShoot = 0; //방금 쐈으니 0으로 초기화
            }
            //if 가 없으면 매 프레임마다 bullet 생성 (너무 빠름)
            //한번 쏘면 쿨타임을 줘야한다
        }

        lastShoot += Time.deltaTime; //지난 시간 (Time.deltaTime) 만큼 더해준다
        //
    }
}
