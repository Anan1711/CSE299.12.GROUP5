using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
  
    public void Quit()
    {
        // Just print an Quit statement. No actually closing.
        Debug.Log("Quit!");
        Application.Quit();
    }
}
