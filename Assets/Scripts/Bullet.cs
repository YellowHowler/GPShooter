using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6); //6초뒤(그쯤이면 화면 밖으로 나갔을테니)에 오브젝트를 삭제시킨다. 너무 많은 object 가 있으면 렉걸리기 때문
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime); 
        //Transform.Translate: 괄호 안에 움직이는 만큼을 담은 vector을 넣어주면 그방향으로 움직이는 함수
        //transform.right: 소문자의 transform은 스크립트가 붙은 오브젝트의 transform component를 가리킨다; transform.right 는 오브젝트의 '오른쪽'(2D에서는 앞) 방향을 벡터로 준다
        //transform.position = transform.position + (transform.right * speed * Time.deltaTime) 랑 같음
    }
}
