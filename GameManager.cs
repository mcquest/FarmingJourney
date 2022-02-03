/*
 * Charles Farris
 * Farming Journey
 * GameManager.cs
 * Game and UI variables
*/

// Imported Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Monobehavior is in here
using UnityEngine.UI;

// Same name as script
public class GameManager : MonoBehaviour // Inheritance (Start, Update)
{
    // initialize inventory
    public int appleSeeds = 0; // red apple 
    public int yFSeeds = 0; //sunflower
    public int raspBushSeeds = 0; //pink raspberry

    // Set time and day tracking variables
    public int Day = 104;
    public float currentTime;
    public float dayMarker = 5.0f;

    // UI text
    public Text aTreeNum;
    public Text yFNum;
    public Text raspBushNum;
    public Text DayNum;

    //public int 

    // player position
    public Transform playerPos;

    //agriculture
    //Red appleTree

    //Pink Raspberry Bush

    //Yellow Sunflower

    //current farm setup


    // Called before the first frame update
    // After Awake()
    void Start()
    {

    }

    // Called every frame
    // Also FixedUpdate() for calls set every .2s
    void Update()
    {
        DayTracker();
    }

    void DayTracker()
    {
        // Set Current time to a variable
        currentTime = Time.time;
        // Track time since start in Console 
        // Debug.Log(Time.time.ToString());
        //DayNum.text = currentTime.ToString();
        if (Time.time > dayMarker)
        {
            // Day = Day + 1 
            Day++;
            // Sets float to signify next day 
            dayMarker = dayMarker + 10.0f;
            DayNum.text = Day.ToString();

        }
    }


    public void PlaySeedPickUpSound()
    {
        //play seed sound
    }

    //apple seeds +1
    public void AppleSeedUp()
    {
        PlaySeedPickUpSound();
        appleSeeds += 1;
        aTreeNum.text = appleSeeds.ToString();
    }

    //apple seeds -1
    public void AppleSeedDown()
    {
        appleSeeds -= 1;
        aTreeNum.text = appleSeeds.ToString();
    }

    //sunflower seeds +1
    public void SunSeedUp()
    {
        PlaySeedPickUpSound();
        yFSeeds += 1;
        yFNum.text = yFSeeds.ToString();
    }

    //sunflower seeds -1
    public void SunSeedDown()
    {
        yFSeeds -= 1;
        yFNum.text = yFSeeds.ToString();
    }

    //Raspberry seeds +1
    public void RaspSeedUp()
    {
        //add seed to inventory
        raspBushSeeds += 1;
        raspBushNum.text = raspBushSeeds.ToString();
    }

    //Raspberry seeds -1
    public void RaspSeedDown()
    {
        raspBushSeeds -= 1;
        raspBushNum.text = raspBushSeeds.ToString();
    }

    //CanPlantApple seed -> return a boolean 
    public bool CanPlantApple()
    {
        if (appleSeeds > 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    } 
    
    //CanPlantRasp seed -> return a boolean 
    public bool CanPlantRasp()
    {
        if (raspBushSeeds > 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
    
    // CanPlantSunflower seed -> boolean
    public bool CanPlantSun()
    {
        if (yFSeeds > 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

   
}
