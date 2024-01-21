using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUD_Project.Data;

public class Manager : MonoBehaviour
{

    protected Transform enemySpawnPoint;
    protected GameObject enemy_gameObject;

    protected float timer;
    protected bool waveValue;
    protected int repeatValue;

   
    private void Awake()
    {
        enemySpawnPoint = GameObject.FindGameObjectWithTag("ESpawn").transform;
        enemy_gameObject = Resources.Load<GameObject>("Enemy/enemy");
    }
    private void Start()
    {
        Actions.OnGameStarted += StartGame;
        Actions.OnGameStarted();
        waveValue = false;
        repeatValue = 2;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

      

    }


    private void Update()
    {
        if (waveValue)
        {
            StartCoroutine(CallEnemyWave(repeatValue));
            waveValue = false;
        }
    }

    public void StartGame()
    {
        Invoke("CreateSingleEnemy", 10f);
    }

    public void CreateSingleEnemy()
    {
        GameLogic.CreateEnemy(enemy_gameObject, enemySpawnPoint);
    }

    public void SetWaveBoolValue(bool value)
    {
        waveValue = value;
    }


   IEnumerator CallEnemyWave(int repeat)
   {
        for (int i = 0; i < repeat; i++)
        {
            GameLogic.CreateEnemy(enemy_gameObject, enemySpawnPoint);
            yield return new WaitForSeconds(1.5f);
        }
        repeatValue = repeatValue + 1;
   }




}
