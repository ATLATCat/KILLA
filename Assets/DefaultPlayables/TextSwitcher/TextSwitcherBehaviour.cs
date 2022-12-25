using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;
using TMPro;
using Febucci.UI;

[Serializable]
public class TextSwitcherBehaviour : PlayableBehaviour
{
    public string text;

    bool isFirstFrame = true;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        base.OnBehaviourPlay(playable, info);
        TextMeshProUGUI m_TrackBinding = playerData as TextMeshProUGUI;

        if(isFirstFrame)
        {
            m_TrackBinding.text = text;
            if (m_TrackBinding.GetComponent<TextAnimatorPlayer>() is TextAnimatorPlayer textAnimatorPlayer)
            {
                textAnimatorPlayer.StartShowingText(true);
            }

            isFirstFrame = false;
        }
    }
}
