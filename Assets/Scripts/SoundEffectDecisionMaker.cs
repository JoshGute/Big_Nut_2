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

    public void PlaySFX(AudioClip INacSFXtoPlay, int INiSystemPriority = 1, int INfAudioPriority = 128, float INfAudioVolume = 0.5f)
    {
        if (INiSystemPriority >= CurrentEffectPriority)
        {
            if (INfAudioPriority != 128)
            {
                RobotAudioSource.priority = INfAudioPriority;
            }

            if (INfAudioVolume != 0.5)
            {
                RobotAudioSource.volume = INfAudioVolume;
            }

            RobotAudioSource.PlayOneShot(INacSFXtoPlay);
            CurrentAudioClip = INacSFXtoPlay;
            CurrentEffectPriority = INiSystemPriority;
            PlayingSFX = true;
        }

        else
        {
            print("More Important Sound " + CurrentAudioClip);
        }
    }
}
