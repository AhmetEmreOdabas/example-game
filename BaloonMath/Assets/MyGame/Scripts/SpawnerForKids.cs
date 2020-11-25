using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerForKids : MonoBehaviour
{
    [SerializeField]
    private GameObject[] balls;

    public List<int> TakeList = new List<int>();

    public static int BallsAlive;

    private int randomNumber;
    private float spawnTime;

    private void Awake() 
    {
        BallsAlive = 0;
    }

    private void Start() 
    {
        FillTheList();
        spawnTime = 5f;
    }

    private void Update()
    {
        if (spawnTime == 10)
        {
            FillTheList();
        }

        spawnTime -= 1 * Time.deltaTime;


        if(spawnTime <= 0)
        {
            StartCoroutine(SpawnBall());
            spawnTime = 10f;
        }
    }

    public void FillTheList()
    {
        TakeList = new List<int>(new int[balls.Length]);

        for (int i = 0; i < balls.Length; i++)
        {
            while (TakeList.Contains(randomNumber))
            {
                randomNumber = Random.Range(1, (balls.Length) + 1);
            }

            TakeList[i] = randomNumber;
        }   
    }

    IEnumerator SpawnBall()
    {
           foreach (int i in TakeList)
        {
            GameObject ball = Instantiate(balls[i-1]) as GameObject;
            ball.transform.position = new Vector2(Random.Range(-1,1), this.transform.position.y);
            ball.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(10.0f,200.0f));
            BallsAlive++;
            yield return new WaitForSeconds (0.5f);
        }
    }
}
