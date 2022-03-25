using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IUint
{
    bool isIdle();
    void MoveTo(Vector3 postion, float stopDistance, Action onPosition);
    void PlayAnimation(Vector3 lookAt,Action onAnimationComplete);
}
