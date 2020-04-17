using UnityEngine;

public class GameMaster : MonoBehaviour
{
  
    public static void KillPlayer(PlayerHealth player)
    {
        Destroy(player.gameObject);
    }

   

    
}