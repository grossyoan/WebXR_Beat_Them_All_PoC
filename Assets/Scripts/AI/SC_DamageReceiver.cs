using UnityEngine;

public class SC_DamageReceiver : MonoBehaviour
{
    //This script will keep track of player HP
    public float playerHP = 100;
    public float PointToLose = 10;

    public void ApplyDamage(GameObject obj)
    {
        playerHP -= PointToLose;
        Destroy(obj);

        if(playerHP <= 0)
        {
            playerHP = 0;
        }
    }
}