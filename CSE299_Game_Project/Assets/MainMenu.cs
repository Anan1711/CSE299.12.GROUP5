using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        // loading the next scene in the queue by index number.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        // Just print an Quit statement. No actually closing.
        Debug.Log("Quit!");
        Application.Quit();
    }
}
