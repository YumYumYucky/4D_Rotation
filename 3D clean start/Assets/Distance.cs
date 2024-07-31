using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using System.IO;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    //cube and reference cube and line game object to get position information
    public GameObject cube;
    public GameObject LineX;
    public GameObject LineY;
    public GameObject LineXRef;
    public GameObject LineYRef;
    public GameObject Reference;
    //timers and variables used for time
    public float timer=0;
    public float time;
    public float timeRemaining=600;
    [SerializeField] TMP_Text timerText;
    Boolean end=false;
    List<float> allTimes=new List<float>();
    [SerializeField] TMP_Text allTimesText;
    String copyTimes;
    public GameObject copy_Times;
    //instance of RotateCube and RandomeRotation classes.
    public RotateCube Rotat;
    public RandomRotation RandomRotat;

    // Start is called before the first frame update
    void Start()
    {
        //makes the button to copy times invisible at the beggening
        copy_Times.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //gets the position of 4 of the lines/cuboids 
        Vector3 X1=((LineX.transform.position-cube.transform.position)*2).normalized;
        Vector3 Y1=((LineY.transform.position-cube.transform.position)*2).normalized;
        Vector3 X2=((LineXRef.transform.position-Reference.transform.position)*2).normalized;
        Vector3 Y2=((LineYRef.transform.position-Reference.transform.position)*2).normalized;
        
        //finds the distance bwtween X1 and X2 and Y1 and Y2
        double DistanceX=Math.Sqrt(Mathf.Pow(X1.x-X2.x,2)+Mathf.Pow(X1.y-X2.y,2)+Mathf.Pow(X1.z-X2.z,2));
        double DistanceY=Math.Sqrt(Mathf.Pow(Y1.x-Y2.x,2)+Mathf.Pow(Y1.y-Y2.y,2)+Mathf.Pow(Y1.z-Y2.z,2));
        //print(X1+" "+Y1+" Ref:"+X2+" "+Y2+" Distance:"+DistanceX+" "+DistanceY);
        
        //adds time to the timer
        timer+=Time.deltaTime;

        //if the distances are less than 0.2 apart and there is still time remaining record the time, reset the cubes, and reset the times
        if(DistanceX <0.2f && DistanceY<0.2f && timeRemaining>0f)
        {
            if(time==0)
            {
                time=timer;
            }
            print("Time: "+time+" seconds");
            allTimes.Add(time);
            RandomRotat.NewRotation();
            Rotat.ZeroRotation();
            time=0;
            timer=0;
        }
        
        //Displays the time if there is time remaining and if not shows Times's up
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            // Handle when the timer reaches 0
            timerText.text = "Time's up!";
        }

        //at the end of the 10 minutes
        if(timeRemaining<0f && end==false)
         {
            //formats all the times to be shown in the center
            for(int i = 0; i < allTimes.Count; i++){
                float minutes = Mathf.FloorToInt(allTimes[i] / 60);
                float seconds = Mathf.FloorToInt(allTimes[i] % 60);
                if (seconds>=10){
                    allTimesText.text+="Time "+i+" is "+minutes+":"+ seconds+"\n";
                }
                else{
                    allTimesText.text+="Time "+i+" is "+minutes+":0"+ seconds+"\n";
                }
                //formats times to be copied
                copyTimes+=Mathf.FloorToInt(allTimes[i])+", ";
            }
            //if there are no time show No Times
            if(allTimes.Count==0)
            {
                allTimesText.text="No Times";
                copyTimes="No Times";
            }
            //copy times to clipboard and make button to copy times appear
            print(copyTimes);
            copyTimes.CopyToClipboard();
            copy_Times.gameObject.SetActive(true);
            end=true;
         }
    }

    void DisplayTime(float timeToDisplay)
    {
        //displays the time in the correct format
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("Time Left: "+"{0:00}:{1:00}", minutes, seconds);
    }

    public void CopyToClipboardFromPress()
    {
        //allows button to copy the times
        copyTimes.CopyToClipboard();
    }

}
