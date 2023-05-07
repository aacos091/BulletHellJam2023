using System;
using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Audio;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    //public AudioSource music;
    public float slowMoPercentage = 100.0f;
    public float regenRate;
    public float decreaseRate;
    public TMP_Text slowMoText;
    private bool regenSlowMo = false;
    public bool usingSloMo = false;
    public AudioMixer mainMixer;
    

    private void Update()
    {
        slowMoText.text = Mathf.FloorToInt(slowMoPercentage) + "%";
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        mainMixer.SetFloat("MasterPitch", Time.timeScale);

        if (slowMoPercentage < 100.0f && !regenSlowMo && !usingSloMo)
        {
            StartCoroutine(SlowMoRegain());
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            usingSloMo = false;
        }
    }

    public void SlowMotion()
    {
        if (slowMoPercentage > 0)
        {
            usingSloMo = true;
            
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            mainMixer.SetFloat("MasterPitch", 0.6f);

            slowMoPercentage -= decreaseRate * Time.deltaTime;
        }
    }

    public void ReleaseSlowMotion()
    {
        usingSloMo = false;
    }

    private IEnumerator SlowMoRegain()
    {
        regenSlowMo = true;
        while (slowMoPercentage < 100.0f)
        {
            slowMoPercentage += 1.0f;
            yield return new WaitForSeconds(regenRate);
        }

        regenSlowMo = false;
    }

}
