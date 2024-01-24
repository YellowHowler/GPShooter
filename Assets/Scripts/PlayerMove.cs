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
        float horizontalInput = Input.GetAxis("Horizontal"); // 오른쪽 키가 눌려 있으면 1, 왼쪽 키 면 -1, 아무것도 없으면 0
    	float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
    	movement = movement.normalized * speed * Time.deltaTime; // Vector3.Normalize --> magnitude 를 1 로 만들어주는 과정; 대각선으로 가도 더 많이 가지 않도록

    	transform.position += movement;
    }
}
