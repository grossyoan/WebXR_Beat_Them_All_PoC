using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public SC_DamageReceiver player;
    public Texture crosshairTexture;
    public float spawnInterval = 2; //Spawn new enemy each n seconds
    public int enemiesPerWave = 5; //How many enemies per wave
    public Transform[] spawnPoints;
    
    public TextMesh CountDownText;
    public TextMesh EnnemiesText;
    public TextMesh GameoverText;

    public HideObject RestartBox;

    float nextSpawnTime = 0;
    int waveNumber = 1;
    bool waitingForWave = true;
    float newWaveTimer = 0;
    int enemiesToEliminate;
    //How many enemies we already eliminated in the current wave
    int enemiesEliminated = 0;
    int totalEnemiesSpawned = 0;

    public bool startingGame = false;

    bool gameOver = false;

    bool isDead = false;

    /**
    * Game audio
    */
    public AudioSource GameAudio;
    public AudioSource GameOverAudio;
    public AudioSource WaveStart;
    public AudioSource WaveEnd;
    public AudioSource BtnAudio;

    // Start is called before the first frame update
    void Start()
    {
        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Wait 10 seconds for new wave to start
        newWaveTimer = 5;
        waitingForWave = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(startingGame) {
            
            if (waitingForWave)
            {
                if(newWaveTimer >= 0)
                {
                    newWaveTimer -= Time.deltaTime;
                }
                else
                {
                    WaveStart.Play(0);
                    //Initialize new wave
                    enemiesToEliminate = waveNumber * enemiesPerWave;
                    enemiesEliminated = 0;
                    totalEnemiesSpawned = 0;
                    waitingForWave = false;
                }
            }
            else
            {
                if(Time.time > nextSpawnTime)
                {
                    nextSpawnTime = Time.time + spawnInterval;

                    //Spawn enemy 
                    if(totalEnemiesSpawned < enemiesToEliminate)
                    {
                        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                        GameObject enemy = Instantiate(enemyPrefab, randomPoint.position, Quaternion.identity);
                        SC_NPCEnemy npc = enemy.GetComponent<SC_NPCEnemy>();
                        npc.playerTransform = player.transform;
                        npc.es = this;
                        totalEnemiesSpawned++;
                    }
                }
            }

        }

        if (player.playerHP <= 0)
        {
            startingGame = false;
            gameOver = true;
            if(isDead == false) {
                GameAudio.Stop();
                GameOverAudio.Play();
                RestartBox.Show();
                isDead = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                restart();
            }
        }
    }

    public void StartGame() {
        startingGame = true;
        BtnAudio.Play();
        GameAudio.PlayDelayed(1);
    }

    public void restart() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void OnGUI()
    {
        //GUI.Box(new Rect(10, Screen.height - 35, 100, 25), ((int)player.playerHP).ToString() + " HP");

        if(player.playerHP <= 0)
        {
           // GUI.Box(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 20, 150, 40), "Game Over\nPress 'Space' to Restart");
        }

        //GUI.Box(new Rect(Screen.width / 2 - 50, 10, 100, 25), (enemiesToEliminate - enemiesEliminated).ToString());
        EnnemiesText.text = (enemiesToEliminate - enemiesEliminated).ToString() + " enemies left";

        if (waitingForWave)
        {

            EnnemiesText.text = "";

            CountDownText.text =  "Wave " + waveNumber.ToString() + " in " + ((int)newWaveTimer).ToString() + " seconds";
            //GUI.Box(new Rect(Screen.width / 2 - 125, Screen.height / 4 - 12, 250, 25), "Wave " + waveNumber.ToString() + " starting in " + ((int)newWaveTimer).ToString() + " seconds");
        }
        else {
            CountDownText.text =  "";
        }

        if(gameOver) {
            CountDownText.text =  "";
            EnnemiesText.text = "";
            GameoverText.text = "Game over !";
        }
        else {
            GameoverText.text = "";
        }
    }

    public void EnemyEliminated()
    {
        enemiesEliminated++;

        if(enemiesToEliminate - enemiesEliminated <= 0)
        {
            //Start next wave
            WaveEnd.Play(0);
            newWaveTimer = 10;
            waitingForWave = true;
            waveNumber++;
        }
    }
}