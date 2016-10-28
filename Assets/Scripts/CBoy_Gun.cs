using UnityEngine;
using System.Collections;

public class CBoy_Gun : GunScript
{
    public int iMaxRounds = 6;
    public float fReloadSpeed;
    public float fReloadTimer;
    private int iBullets = 6;

    void Update()
    {
        if(RobotAudioSource)
        {
            if (fTimerForNext < fFireRate)
            {
                fTimerForNext += Time.deltaTime;
            }

            if (iBullets < iMaxRounds)
            {
                fReloadTimer += Time.deltaTime;
                if (fReloadTimer >= fReloadSpeed)
                {
                    RobotAudioSource.PlayOneShot(ReloadNoise);
                    iBullets += 1;
                    fReloadTimer = 0;
                    print(iBullets);
                }
            }
        }
    }

    public override void Shoot()
    {
        RobotAudioSource.PlayOneShot(ShootingNoise);

        if (fTimerForNext >= fFireRate && iBullets > 0)
        {
            GameObject bulletPattern = Instantiate(gBulletPattern, 
                                                    PatternSpawn.transform.position, 
                                                    transform.rotation) as GameObject;
            fTimerForNext = 0;
            iBullets -= 1;
        }
    }
}
