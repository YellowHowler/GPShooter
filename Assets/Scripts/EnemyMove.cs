using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Transform player;

    private float moveSpeed = 2f;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = player.position - transform.position;
        transform.Translate(transform.up * moveSpeed * Time.deltaTime); 
    }
}
