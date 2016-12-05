using UnityEngine;

using UnityEngine.Networking;
using System.Collections.Generic;
using System.Collections;


public enum WAVE_DAY {
    ONE = 1,
    TWO = 2,
    THREE = 3,
    FOUR = 4,
    FIVE = 5,
    SIX = 6,
    SEVEN = 7,
    EIGHT = 8,
    NINE = 9,
    TEN = 10,
    ELEVEN = 11,
    TWELVE = 12,
    FINISH = 13
}


public class GameProgression : MonoBehaviour {

    
    public WAVE_DAY waveDay;
    const float maxBreakTime = 30.0f;
    ParticleSystem snowParticleSys;
    PlayerController player;

    public float breakTime = 0.0f;
    public bool snowHeavy = false;
    public bool onBreak = false;

    public float waveTime = 0.0f;
    const float maxWaveTime = 10.0f;
    float playerDefaultSpeed;

    public int numEnemiesLeft = 0;
    const int startEnmCount = 1;

    public int snowfallChance = 10;

    void Start() {
        waveDay = WAVE_DAY.ONE;
        snowParticleSys = GameObject.FindGameObjectWithTag("Snow").GetComponent<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerDefaultSpeed = player.movementSpeed;

        numEnemiesLeft = startEnmCount;

        LightSnow();
    }


    void Update() {

        waveTime += Time.deltaTime;

        if (waveTime >= 3.0f && onBreak == false) {
            numEnemiesLeft--;
            waveTime = 0.0f;
        }
            
        if ((numEnemiesLeft <= 0) && (onBreak == false)) {
            onBreak = !onBreak;
            LightSnow();

            if (waveDay == WAVE_DAY.TWELVE) {
                Debug.Log("YOU WIN");
                return;
            }
        }

        

        if (onBreak == true) {

            breakTime += Time.deltaTime;
            if (breakTime >= maxWaveTime) {
                breakTime = 0.0f;
                onBreak = false;
                WaveUpdate();
                CalculateSnowFall();
                numEnemiesLeft = startEnmCount + ((int)waveDay + 3);
            }
        }
    }

    void CalculateSnowFall() {
        int rand = Random.Range(0, 100);

        if (rand <= snowfallChance)
        {
            HeavySnow();
        }
        else
        {
            LightSnow();
        }
        snowfallChance += 7;
        Debug.Log(rand);
    }

    void HeavySnow() {
        snowHeavy = true;
        snowParticleSys.startSpeed = 40;
        snowParticleSys.emissionRate = 2000;
        player.movementSpeed /= 2.0f;
        
    }

    void LightSnow() {
        snowHeavy = false;
        snowParticleSys.startSpeed = 10;
        snowParticleSys.emissionRate = 500;
        player.movementSpeed = playerDefaultSpeed;
    }

    void WaveUpdate() {
        waveDay++;

        if (waveDay == WAVE_DAY.FINISH) {
            Debug.Log("YOU WIN!");
        }
    }

} // end class GameProgression
