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
        HPLifeText.text =  "100 hp";

    }

    public void ApplyDamage(GameObject obj)
    {
        playerHP -= PointToLose;
        es.EnemyEliminated();
        HPLifeText.text =  playerHP.ToString("F0") + " hp";
        Destroy(obj);

        if(playerHP <= 0)
        {
            playerHP = 0;
        }
    }
}