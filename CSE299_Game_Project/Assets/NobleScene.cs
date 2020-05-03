using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NobleScene : MonoBehaviour
{
    public void PlayNobleScene()
    {
        // loading the next scene in the queue by index number.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
