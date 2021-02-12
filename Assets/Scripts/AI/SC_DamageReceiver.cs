using UnityEngine;
using UnityEngine.UI;

public class SC_DamageReceiver : MonoBehaviour
{
    public TextMesh HPLifeText;
    //This script will keep track of player HP
    public float playerHP = 80;
    public float PointToLose = 10;
    public SC_EnemySpawner es;

    void Start() {
        HPLifeText.text =  "You have 100 hp left";

    }

    public void ApplyDamage(GameObject obj)
    {
        playerHP -= PointToLose;
        es.EnemyEliminated();
        HPLifeText.text =  "You have " + playerHP.ToString("F0") + " hp left";
        Destroy(obj);

        if(playerHP <= 0)
        {
            playerHP = 0;
        }
    }
}