using System;
using System.Collections;
using System.Collections.Generic;
using Engine4;
using static Engine4.Transform4;
using static Engine4.Vector4;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System.IO;
using JetBrains.Annotations;

public class Distance : MonoBehaviour4
{
    //variables for timer and times
    public float timer=0;
    public float time;
    List<float> allTimes=new List<float>();
    public float TimeLeft=600;
    [SerializeField] TMP_Text allTimesText;
    String copyTimes;
    Boolean end=false;
    public GameObject copy_Times;
    [SerializeField] TMP_Text ReferenceMatrix;//used in testing
    [SerializeField] TMP_Text RotateMatrix;//used in testing
    //instances for RotateCuba and RandomRotation to get rotation information
    public RotateCube Rotat;
    public RandomRotation Rotate;

    
    void Start()
    {
        //hide button to copy times
        copy_Times.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {       
            //resets rotation information
            Engine4.Vector4 X1=new Engine4.Vector4 (1,0,0,0);
            Engine4.Vector4 Y1=new Engine4.Vector4 (0,1,0,0);
            Engine4.Vector4 Z1=new Engine4.Vector4 (0,0,1,0);
            Engine4.Vector4 X2=new Engine4.Vector4 (1,0,0,0);
            Engine4.Vector4 Y2=new Engine4.Vector4 (0,1,0,0);
            Engine4.Vector4 Z2=new Engine4.Vector4 (0,0,1,0);
            float[] rot={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            float[] rote={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};


            //Gets and rebuilds rotation matrix for rotation cube and multiplies it by basis vectors to get vectors which rotations can be compared
            rot=Rotat.Rotates();
            Engine4.Vector4 rowX1=new Engine4.Vector4(rot[0],rot[1],rot[2],rot[3]);
            Engine4.Vector4 rowY1=new Engine4.Vector4(rot[4],rot[5],rot[6],rot[7]);
            Engine4.Vector4 rowZ1=new Engine4.Vector4(rot[8],rot[9],rot[10],rot[11]);
            Engine4.Vector4 rowW1=new Engine4.Vector4(rot[12],rot[13],rot[14],rot[15]);
            Matrix4 MatrixRot=new Matrix4(rowX1,rowY1,rowZ1,rowW1);
            X1=MatrixRot*X1;
            Y1=MatrixRot*Y1;
            Z1=MatrixRot*Z1;

            //Gets and rebuilds rotation matrix for reference cube and multiplies it by basis vectors to get vectors which rotations can be compared
            rote=Rotate.Rotates();
            Engine4.Vector4 rowX2=new Engine4.Vector4(rote[0],rote[1],rote[2],rote[3]);
            Engine4.Vector4 rowY2=new Engine4.Vector4(rote[4],rote[5],rote[6],rote[7]);
            Engine4.Vector4 rowZ2=new Engine4.Vector4(rote[8],rote[9],rote[10],rote[11]);
            Engine4.Vector4 rowW2=new Engine4.Vector4(rote[12],rote[13],rote[14],rote[15]);
            Matrix4 MatrixRote=new Matrix4(rowX2,rowY2,rowZ2,rowW2);
            X2=MatrixRote*X2;
            Y2=MatrixRote*Y2;
            Z2=MatrixRote*Z2;

            //used in testing
            //print("Rotation:"+rowX1+", "+rowY1+", "+rowZ1+", "+rowW1+" \nReference:"+rowX2+", "+rowY2+", "+rowZ2+", "+rowW2);
            ReferenceMatrix.text="Reference:\n"+rowX2+"\n"+rowY2+"\n"+rowZ2+"\n"+rowW2;
            RotateMatrix.text="Rotate:\n"+rowX1+"\n"+rowY1+"\n"+rowZ1+"\n"+rowW1;
            //print("x1="+X1+" X2="+X2);
           
        //gets the distances between vectors
        float DistanceX=Distance(X1,X2);
        float DistanceY=Distance(Y1,Y2);
        float DistanceZ=Distance(Z1,Z2);

        //add or subtracts time to timers
        timer+=Time.deltaTime;
        TimeLeft-=Time.deltaTime;
        //if rotation is within 0.3 and there is still time left recors rotation and get new reference rotation and zero rotation cube rotation
        if(DistanceX <0.3f && DistanceY<0.3f  && DistanceZ<0.3f && TimeLeft>0f)
        {
            if(time==0)
            {
                time=timer;
            }
            print("Time: "+time+" seconds");
            allTimes.Add(time);
            Rotate.newRotation();
            Rotat.zeroRotation();
            time=0;
            timer=0;
        }
        
        //once the 10 minutes are up
         if(TimeLeft<0f && end==false)
         {
            //formats all the times to be displayed 
            for(int i = 0; i < allTimes.Count; i++){
                float minutes = Mathf.FloorToInt(allTimes[i] / 60);
                float seconds = Mathf.FloorToInt(allTimes[i] % 60);
                if (seconds>=10){
                    allTimesText.text+="Time "+i+" is "+minutes+":"+ seconds+"\n";
                }
                else{
                    allTimesText.text+="Time "+i+" is "+minutes+":"+ seconds+"\n";
                }
                //formats time to be copied
                copyTimes+=Mathf.FloorToInt(allTimes[i])+", ";
            }
            //if there are no time show No Times
            if(allTimes.Count==0)
            {
                allTimesText.text="No Times";
                copyTimes="No Times";
            }
            
            //copy times to clipboard and show button to copy times
            copyTimes.CopyToClipboard();
            copy_Times.gameObject.SetActive(true);
            end=true;
         }

    }

    public void CopyToClipboardFromPress(){
        //allow button to copy times
        copyTimes.CopyToClipboard();
    }


}
