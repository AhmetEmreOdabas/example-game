using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public GameObject firstSelection;
    public GameObject secondSelection;

    private string numberOne;
    private string numberTwo;

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction,Mathf.Infinity);
           Debug.Log("Balls" + SpawnerForKids.BallsAlive);

           if(hit)
           {
               if(hit.collider.tag == "Ball")
               {
                   GameObject hitInfo = hit.transform.root.gameObject;
                   Selection(hitInfo);
               }
           }
        }
    }

    public void Selection(GameObject ball)
    {
       if(firstSelection == null)
       {
           firstSelection = ball;
           firstSelection.GetComponent<SpriteRenderer>().color = Color.green;
           Debug.Log("first selection is  :" + ball);
           return;
       }

       if(firstSelection != null && secondSelection == null)
       {
           if(ball == firstSelection)
           {
               return;
           }
           secondSelection = ball;
           secondSelection.GetComponent<SpriteRenderer>().color = Color.green;
           DoMath();
           Debug.Log("second selection is  :" + ball);
           return;
       }

       if(firstSelection != null && secondSelection != null)
       {
           Deselect();
       }
    }

    public void Deselect()
    {
        firstSelection.GetComponent<SpriteRenderer>().color = Color.white;
        secondSelection.GetComponent<SpriteRenderer>().color = Color.white;
        firstSelection = null;
        secondSelection = null;
    }

    public void DoMath()
    {
        if(firstSelection != null && secondSelection != null)
        {
           numberOne = firstSelection.GetComponentInChildren<Text>().text;
           numberTwo = secondSelection.GetComponentInChildren<Text>().text;

           int.TryParse(numberOne, out int valueOne);
           int.TryParse(numberTwo, out int valueTwo);

           if(valueOne + valueTwo == 10)
           {
               Destroy(firstSelection);
               Destroy(secondSelection);
               GameManager.Timer += 5;
               SpawnerForKids.BallsAlive -= 2;
           }
        }
    }
}
