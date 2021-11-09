using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimator : MonoBehaviour
{
    Animator animator;
    public float speed = 0;
    private Coroutine speedInc = null;
    private Coroutine speedDec = null;
    public SandwichManager sandwichManager;
    bool checkSpeed = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0;
    }

    void Update()
    {
        //Debug.Log(speed);

        if (speed == 0 && checkSpeed)
        {
            sandwichManager.IsStopped();
            checkSpeed = false;
        }
    }

    IEnumerator SpeedIncrease()
    {
        speed = animator.speed;
        while (speed < 1)
        {
            speed += 0.1f;
            if (speed > 1)
                speed = 1;
            animator.speed = speed;
            yield return new WaitForSeconds(0.5f);
        }
        yield break;
    }

    IEnumerator SpeedDecrease()
    {
        speed = animator.speed;
        while (speed > 0)
        {
            speed -= 0.2f;
            if (speed < 0)
                speed = 0;
            animator.speed = speed;
            yield return new WaitForSeconds(0.5f);
        }
        yield break;
	}

	public void StartSpeedInc()
	{
        if (speedDec != null)
        {
            StopCoroutine(speedDec);
            speedDec = null;
        }
		speedInc = StartCoroutine(SpeedIncrease());
	}
    public void StartSpeedDec()
    {
        if (speedInc != null)
        {
            StopCoroutine(speedInc);
            speedInc = null;
        }
        speedDec = StartCoroutine(SpeedDecrease());
    }

    public bool IsStopped()
    {
        if (speed == 0)
            return true;
        else
            return false;
    }

    public void CheckStop()
    {
        checkSpeed = true;
    }


}
