using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimator : MonoBehaviour
{
    public SandwichManager sandwichManager;

    Animator animator;

    public float speed = 0;
    public float[] variableSectionSpeedInc;
    public float[] variableSectionSpeedDec;

    private Coroutine speedInc = null;
    private Coroutine speedDec = null;
    private int currentSection;

    bool checkSpeed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0;

        variableSectionSpeedInc = new float[4];
        variableSectionSpeedDec = new float[4];

        for (int i = 0; i < 4; i++)
        {
            variableSectionSpeedInc[i] = Random.Range(0.01f, 0.1f); 
            variableSectionSpeedDec[i] = Random.Range(0.01f, 0.1f); 
        }
    }

    void Update()
    {
        //Debug.Log(speed);

        if (speed == 0 && checkSpeed)                 //constantly check if speed is 0 and if speed is being checked
        {
            sandwichManager.IsStopped();
            checkSpeed = false;
        }
    }

    IEnumerator SpeedIncrease()
    {
        speed = animator.speed;
        currentSection = sandwichManager.GetLevel();

        while (speed < 1)
        {
            //speed += 0.02f;
            speed += variableSectionSpeedInc[currentSection - 1];
            if (speed > 1)
                speed = 1;
            animator.speed = speed;
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }

    IEnumerator SpeedDecrease()
    {
        speed = animator.speed;
        currentSection = sandwichManager.GetLevel();

        while (speed > 0)
        {
            //speed -= 0.04f;
            speed -= variableSectionSpeedDec[currentSection - 1];
            if (speed < 0)
                speed = 0;
            animator.speed = speed;
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
	}

	public void StartSpeedInc()                           //attached function to Start button to start increase speed
    {
        if (speedDec != null)
        {
            StopCoroutine(speedDec);
            speedDec = null;
        }
		speedInc = StartCoroutine(SpeedIncrease());
	}
    public void StartSpeedDec()                          //attached function to Stop button to start decrease speed
    {
        if (speedInc != null)
        {
            StopCoroutine(speedInc);
            speedInc = null;
        }
        speedDec = StartCoroutine(SpeedDecrease());
    }

    public bool IsStopped()            //if hand is stopped or not
    {
        if (speed == 0)
            return true;
        else
            return false;
    }

    public void CheckStop()               //whether to check if speed is 0 or not
    {
        checkSpeed = true;
    }


}
