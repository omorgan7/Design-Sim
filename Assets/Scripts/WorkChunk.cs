using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkChunk{
    float currenttime = 0f;
    float duration;
    public Brief b;

    WorkChunk(float _duration, Brief _b){
        b = _b;
        duration = _duration;
    }


}