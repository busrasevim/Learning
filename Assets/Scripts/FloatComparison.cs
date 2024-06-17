using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatComparison : MonoBehaviour
{
    public static bool IsNEarlyEqual(float a, float b, float epsilon) {
        var absA = Mathf.Abs(a);
        var absB = Mathf.Abs(b);
        var diff = Mathf.Abs(a - b);

        if (a == b) { // shortcut, handles infinities
            return true;
        } else if (a == 0 || b == 0 || (absA + absB < float.Epsilon)) {
            // a or b is zero or both are extremely close to it
            // relative error is less meaningful here
            return diff < (epsilon *  float.Epsilon);
        } else { // use relative error
            return diff / Mathf.Min((absA + absB), float.MaxValue) < epsilon;
        }
    }
}
