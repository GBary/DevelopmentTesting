using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

    public bool FancyDay;
    public Color32 NightColor;
    public Color32 SunRiseColor;
    public Color32 DayColor;
    public Color32 SunsetColor;
    public Color32 BackGroundColor;
    public float DayNightCycleSpeed;
    private float t;
    private int TimeOfDay;
    private int Iterator;

    void Start()
    {
        TimeOfDay = 1;
        Iterator = 1;
    }

    void Update()
    {
        if(FancyDay)
        {
            MoreTimesOfDay();
        }else{
            DayNight();
        }
    }


    void DayNight()
    {
        //Day-Night Cycle
        t = Mathf.PingPong(Time.time*DayNightCycleSpeed, 1);
        BackGroundColor = Color.Lerp(NightColor, DayColor, t);
        this.GetComponent<SpriteRenderer>().color = BackGroundColor;
    }

    void MoreTimesOfDay()
    {
        //Day-Night Cycle
        t = Mathf.PingPong(Time.time*DayNightCycleSpeed, 1);

        switch(TimeOfDay)
        {
        case 1:
            BackGroundColor = Color.Lerp(NightColor, SunRiseColor, t);
            if(t>0.95 && Iterator==1){
                Iterator = 2;
            }
            break;
        case 2:
            BackGroundColor = Color.Lerp(DayColor, SunRiseColor, t);
            if(t<0.05 && Iterator==2){
                Iterator = 3;
            }
            break;
        case 3:
            BackGroundColor = Color.Lerp(DayColor, SunsetColor, t);
            if(t>0.95 && Iterator==3){
                Iterator = 4;
            }
            break;
       case 4:
            BackGroundColor = Color.Lerp(NightColor, SunsetColor, t);
            if(t<0.05 && Iterator==4){
                Iterator = 1;
            }
            break;
        }
        if(t<=0.97)
        {
            TimeOfDay = Iterator;
        }else if(t>=0.03)
        {
            TimeOfDay = Iterator;
        }

        this.GetComponent<SpriteRenderer>().color = BackGroundColor;
    }

}
