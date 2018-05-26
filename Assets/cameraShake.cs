using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour {

    public IEnumerator shake(float duration, float amount)
    {
        var _originalPos = Camera.main.transform.localPosition;

        float endTime = Time.time + duration;

        while (Time.time < endTime)
        {
            Camera.main.transform.localPosition = _originalPos + Random.insideUnitSphere * amount;

            duration -= Time.deltaTime;

            yield return null;
        }

        Camera.main.transform.localPosition = _originalPos;
    }

}
