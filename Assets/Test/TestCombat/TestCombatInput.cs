using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCombatInput : MonoBehaviour
{
    bool atkAble = true;
    int atkState;
    Coroutine atkRoutine;
    public SkeletonAnimation model;

    void Update()
    {
        if (atkAble && atkState == 0 && Input.GetKeyDown(KeyCode.Z))
        {
            atkRoutine = StartCoroutine(Attack1());
        }

        if(atkAble && atkState == 1 && Input.GetKeyDown(KeyCode.Z))
        {
            if (atkRoutine != null) StopCoroutine(atkRoutine);
            atkRoutine = StartCoroutine(Attack2());
        }
    }

    IEnumerator Attack1()
    {
        atkAble = false;
        PlayAnim("AttackA");
        float coolTime = 0.4f;
        yield return new WaitForSeconds(coolTime);

        float waitTime = 0.3f;
        atkAble = true;
        atkState = 1;
        yield return new WaitForSeconds(waitTime);
        atkAble = false;

        float returnTime = 0.3f;
        yield return new WaitForSeconds(returnTime);
        atkState = 0;
        atkAble = true;
        yield break;
    }

    IEnumerator Attack2()
    {
        atkAble = false;
        PlayAnim("AttackB");

        float attackTime = 1.3f;
        yield return new WaitForSeconds(attackTime);
        atkAble = true;
        atkState = 0;
        yield break;
    }

    TrackEntry PlayAnim(string key, bool loop = false)
    {
        var anim = model.AnimationState.SetAnimation(0, key, loop);
        return anim;
    }
}
