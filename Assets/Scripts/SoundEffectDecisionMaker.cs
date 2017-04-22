using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectDecisionMaker : MonoBehaviour 
{
    public AudioSource RobotAudioSource;
    private AudioClip CurrentAudioClip;
    private int CurrentEffectPriority;
    public bool PlayingSFX;

	// Update is called once per frame
	void Update () 
    {
        if (PlayingSFX)
        {
            if (RobotAudioSource.isPlaying)
            {
                return;
            }

            else
            {
                PlayingSFX = false;
                CurrentEffectPriority = 0;
            }
        }
	}

    public void PlaySFX(AudioClip INacSFXtoPlay, int INiSystemPriority = 1, bool OverRide = true, int INfAudioPriority = 128, float INfAudioVolume = 0.5f)
    {
        if (INiSystemPriority >= CurrentEffectPriority)
        {
            if (PlayingSFX == false || OverRide)
            {
                RobotAudioSource.priority = INfAudioPriority;

                RobotAudioSource.volume = INfAudioVolume;

                RobotAudioSource.PlayOneShot(INacSFXtoPlay);
                CurrentAudioClip = INacSFXtoPlay;
                CurrentEffectPriority = INiSystemPriority;
                PlayingSFX = true;
            }
            else
            {
                //print("can't override");
            }
        }

        else
        {
            //print("More Important Sound " + CurrentAudioClip);
        }
    }
}
