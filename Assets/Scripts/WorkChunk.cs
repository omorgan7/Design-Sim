using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkChunk{

    public float timescale = 60f;

    public float currenttime = 0f;
    public float duration;
    public Brief brief;

    public WorkChunk(float _duration, Brief _brief){
        brief = _brief;
        duration = timescale*_duration;
    }

    public static bool operator ==(WorkChunk w, Brief b){
        return (w.brief == b);
    }
    public static bool operator !=(WorkChunk w, Brief b){
        return (w.brief != b);
    }
        public static bool equals(WorkChunk w, Brief b){
        return (w.brief == b);
    }

}

//	print(W.FindIndex(x => x==b2)); //FIND MATCHING BRIEF IN LIST