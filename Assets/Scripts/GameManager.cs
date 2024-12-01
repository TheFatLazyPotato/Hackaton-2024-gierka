using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour
{
    public int printersDoneThatDay;
    public int rageMeter = 0; 
    public int rageMax = 20000;
    public int atDesk;
    public float gameTime;
    public bool stopTime;
    
    public float debugTime;

    private float epsilon = 0.01f;
    public int minionCooldown = 0;
    public int chosenDesk;
    public bool[] desksAvailable = new bool[13];
    public bool[] desksRagging = new bool[13];

    public GameObject prefab; // The prefab to summon
    public Transform spawnPoint; // The point where the prefab will spawn

    void Start()
    {
        stopTime = false;
        for(int i = 1; i<13; i++)
        {
            desksAvailable[i] = true;
            desksRagging[i] = false;
        }
    }

    void Update()
    {
        if(!stopTime)
        {
            gameTime += Time.deltaTime;
        }

        switch(GlobalVariables.day)
        {
            case 1:
                if(printersDoneThatDay == 5)
                {
                    printersDoneThatDay = 0;
                    SceneManager.LoadScene(0);
                }
                if(gameTime % 10 > 0 && gameTime % 10 < epsilon && minionCooldown == 0)
                {
                    int i = 0;
                    do{
                        chosenDesk = Rnd12();
                        i++;
                    }while(!desksAvailable[chosenDesk] && i<1000);
                    SummonPrefab();
                    minionCooldown = 100;
                    desksAvailable[chosenDesk] = false;
                    Debug.Log("Minion sent with desk number: " + chosenDesk);
                }
                break;
            case 2:
                if(printersDoneThatDay == 5)
                {
                    printersDoneThatDay = 0;
                    SceneManager.LoadScene(0);
                }
                if(gameTime-1 % 10 > 0 && gameTime-1 % 10 < epsilon && minionCooldown == 0)
                {
                    int i = 0;
                    do{
                        chosenDesk = Rnd12();
                        i++;
                    }while(!desksAvailable[chosenDesk] && i<1000);
                    SummonPrefab();
                    minionCooldown = 100;
                    desksAvailable[chosenDesk] = false;
                    Debug.Log("Minion sent with desk number: " + chosenDesk);
                }
                break;
            case 3:
                if(printersDoneThatDay == 5)
                {
                    printersDoneThatDay = 0;
                    SceneManager.LoadScene(0);
                }
                if(gameTime % 10 > 0 && gameTime % 10 < epsilon && minionCooldown == 0)
                {
                    int i = 0;
                    do{
                        chosenDesk = Rnd12();
                        i++;
                    }while(!desksAvailable[chosenDesk] && i<1000);
                    SummonPrefab();
                    minionCooldown = 100;
                    desksAvailable[chosenDesk] = false;
                    Debug.Log("Minion sent with desk number: " + chosenDesk);
                }
                break;
            case 4:
                if(printersDoneThatDay == 5)
                {
                    printersDoneThatDay = 0;
                    SceneManager.LoadScene(0);
                }
                if(gameTime % 10 > 0 && gameTime % 10 < epsilon && minionCooldown == 0)
                {
                    int i = 0;
                    do{
                        chosenDesk = Rnd12();
                        i++;
                    }while(!desksAvailable[chosenDesk] && i<1000);
                    SummonPrefab();
                    minionCooldown = 100;
                    desksAvailable[chosenDesk] = false;
                    Debug.Log("Minion sent with desk number: " + chosenDesk);
                }
                break;
            case 5:
                if(printersDoneThatDay == 5)
                {
                    printersDoneThatDay = 0;
                    SceneManager.LoadScene(0);
                }
                if(gameTime % 10 > 0 && gameTime % 10 < epsilon && minionCooldown == 0)
                {
                    int i = 0;
                    do{
                        chosenDesk = Rnd12();
                        i++;
                    }while(!desksAvailable[chosenDesk] && i<1000);
                    SummonPrefab();
                    minionCooldown = 100;
                    desksAvailable[chosenDesk] = false;
                    Debug.Log("Minion sent with desk number: " + chosenDesk);
                }
                break;
            default:
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch(atDesk)
            {
                case 1:
                    if(desksAvailable[1] == false)
                    {
                        Debug.Log("Player at desk 1");
                        desksAvailable[1] = true;
                        desksRagging[1] = false;
                        printersDoneThatDay++;
                    }
                    Debug.Log("Player at desk 1");
                    break;
                case 2:
                    if(desksAvailable[2] == false)
                    {
                        Debug.Log("Player at desk 2");
                        desksAvailable[2] = true;
                        desksRagging[2] = false;
                        printersDoneThatDay++;
                    }
                    Debug.Log("Player at desk 2");
                    break;
                case 3:
                    if(desksAvailable[3] == false)
                    {
                        Debug.Log("Player at desk 3");
                        desksAvailable[3] = true;
                        desksRagging[3] = false;
                        printersDoneThatDay++;
                    }
                    Debug.Log("Player at desk 3");
                    break;
                case 4:
                    if(desksAvailable[4] == false)
                    {
                        Debug.Log("Player at desk 4");
                        desksAvailable[4] = true;
                        desksRagging[4] = false;
                        printersDoneThatDay++;
                    }
                    Debug.Log("Player at desk 4");
                    break;
                case 5:
                if(desksAvailable[5] == false)
                    {
                        Debug.Log("Player at desk 5");
                        desksAvailable[5] = true;
                        desksRagging[5] = false;
                        printersDoneThatDay++;
                    }
                    Debug.Log("Player at desk 5");
                    break;
                case 6:
                    if(desksAvailable[6] == false)
                    {
                        Debug.Log("Player at desk 6");
                        desksAvailable[6] = true;
                        desksRagging[6] = false;
                        printersDoneThatDay++;
                    }
                    Debug.Log("Player at desk 6");
                    break;
                case 7:
                    if(desksAvailable[7] == false)
                    {
                        Debug.Log("Player at desk 7");
                        desksAvailable[7] = true;
                        desksRagging[7] = false;
                        printersDoneThatDay++;
                    }
                    Debug.Log("Player at desk 7");
                    break;
                case 8:
                    if(desksAvailable[8] == false)
                    {
                        Debug.Log("Player at desk 8");
                        desksAvailable[8] = true;
                        desksRagging[8] = false;
                        printersDoneThatDay++;
                    }
                    Debug.Log("Player at desk 8");
                    break;
                case 9:
                    if(desksAvailable[9] == false)
                    {
                        Debug.Log("Player at desk 9");
                        desksAvailable[9] = true;
                        desksRagging[9] = false;
                        printersDoneThatDay++;
                    }
                    Debug.Log("Player at desk 9");
                    break;
                case 10:
                    if(desksAvailable[10] == false)
                    {
                        Debug.Log("Player at desk 10");
                        desksAvailable[10] = true;
                        desksRagging[10] = false;
                        printersDoneThatDay++;
                    }
                    Debug.Log("Player at desk 10");
                    break;
                case 11:
                    if(desksAvailable[11] == false)
                    {
                        Debug.Log("Player at desk 11");
                        desksAvailable[11] = true;
                        desksRagging[11] = false;
                        printersDoneThatDay++;
                    }
                    Debug.Log("Player at desk 11");
                    break;
                case 12:
                    if(desksAvailable[12] == false)
                    {
                        Debug.Log("Player at desk 12");
                        desksAvailable[12] = true;
                        desksRagging[12] = false;
                        printersDoneThatDay++;
                    }
                    Debug.Log("Player at desk 12");
                    break;
                default:
                   break;
            }
        }
        if(minionCooldown > 0)
        {
            minionCooldown--;
        }
        if(AllDesksNotRagging() && rageMeter > 0)
        {
            rageMeter--;
            rageMeter--;
        }
    }
    public int Rnd12()
    {
        System.Random random = new System.Random();
        return random.Next(1, 13); 
    }
    
    public bool AllDesksAvailable()
    {
        return desksAvailable[1] && desksAvailable[2] && desksAvailable[12] &&
                desksAvailable[3] && desksAvailable[4] && desksAvailable[5] &&
                desksAvailable[6] && desksAvailable[7] && desksAvailable[8] &&
                desksAvailable[9] && desksAvailable[10] && desksAvailable[11];
    }

    public bool AllDesksNotRagging()
    {
        return !desksRagging[1] && !desksRagging[2] && !desksRagging[3] &&
                !desksRagging[4] && !desksRagging[5] && !desksRagging[6] &&
                !desksRagging[7] && !desksRagging[8] && !desksRagging[9] &&
                !desksRagging[10] && !desksRagging[11] && !desksRagging[12];
    }

    public void SummonPrefab()
    {
        if (prefab != null)
        {
            // Instantiate the prefab at the spawn point's position and rotation
            Instantiate(prefab, new Vector3(10, 1.6f, -16.5f), Quaternion.identity);
        }
    }

    public void OnGUI()
    {
        GUI.Box(new Rect(30, 10, 600, 25), "");
        GUI.Box(new Rect(30, 10, 600 * (float)rageMeter/(float)rageMax, 25), "");
        GUI.Label(new Rect(30, 630, 100, 40),"Rage Bar");
    }
}

