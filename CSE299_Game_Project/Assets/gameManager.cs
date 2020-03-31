using UnityEngine.SceneManagement;
using UnityEngine;

public class gameManager : MonoBehaviour
{
  
   public void EndGame()
    {
        Debug.Log("Game Over");
        Invoke("Restart", 5f);
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
