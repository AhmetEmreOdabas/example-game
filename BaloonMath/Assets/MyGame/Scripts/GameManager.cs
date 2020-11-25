using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static float Timer;

   public  TextMeshProUGUI timerText;

   private void Start() 
   {
       Timer = 30;
       Time.timeScale = 1f;
   }

   private void Update() 
   {
       timerText.text = Timer.ToString("0");

       if(Timer != 0)
       {
            Timer -= 1 * Time.deltaTime;
       }

       if(Timer <= 0 || SpawnerForKids.BallsAlive >= 25)
       {
           EndGame();
       }
   }

   public void EndGame()
   {
        Time.timeScale = 0f;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

   }

   public GameObject pauseMenu;

   public void Pause()
   {
       Time.timeScale = 0f;
       pauseMenu.SetActive(true);
   }

   public void Continue()
   {
       Time.timeScale = 1f;
       pauseMenu.SetActive(false);
   }
}
