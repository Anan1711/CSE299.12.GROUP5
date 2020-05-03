using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrantiScene : MonoBehaviour
{
    public void PlayPrantiScene()
    {
        // loading the next scene in the queue by index number.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
}
