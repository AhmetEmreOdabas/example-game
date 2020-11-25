using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    private float spawnTime;

    private void Start() 
    {
        GameObject ball = Instantiate(ballPrefab) as GameObject;
        GameObject ballTwo = Instantiate(ballPrefab) as GameObject;
        ball.transform.position = new Vector2(-1, this.transform.position.y);
        ball.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 190.0f);
        ball.GetComponentInChildren<Text>().text = Random.Range(1, 5).ToString();
        ballTwo.transform.position = new Vector2(0, this.transform.position.y);
        ballTwo.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 250.0f);
        ballTwo.GetComponentInChildren<Text>().text = Random.Range(6, 10).ToString();
    }

    private void Update() 
    {
        spawnTime += Time.deltaTime;

        if(spawnTime >= 5)
        {
            GameObject ball = Instantiate(ballPrefab) as GameObject;
            GameObject ballTwo = Instantiate(ballPrefab) as GameObject;
            ball.transform.position = new Vector2(-1, this.transform.position.y);
            ball.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 190.0f);
            ball.GetComponentInChildren<Text>().text = Random.Range(1, 5).ToString();
            ballTwo.transform.position = new Vector2(0, this.transform.position.y);
            ballTwo.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 250.0f);
            ballTwo.GetComponentInChildren<Text>().text = Random.Range(6, 10).ToString();
            spawnTime = 0;
            return;
        }
    }
}
