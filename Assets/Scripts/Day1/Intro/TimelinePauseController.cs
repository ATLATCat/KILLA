using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class TimelinePauseController : MonoBehaviour
{
    public PlayableDirector activeDirector;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            activeDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
        }
    }

    public void Pause()
    {
        activeDirector.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }
}
