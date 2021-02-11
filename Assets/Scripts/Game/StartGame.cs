using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public SC_EnemySpawner es;

    public void StartTrigger () {
        es.StartGame();
    }
}
