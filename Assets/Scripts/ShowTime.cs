using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowTime : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ScaleOverTime(5f, 10f));
        }
    }

    public IEnumerator ScaleOverTime(float duration, float scale) {
        var startScale = transform.localScale;
        var endScale = Vector3.one * scale;
        var elapsed = 0f;

        while (elapsed < duration) {
            var t = elapsed / duration;
            transform.localScale = Vector3.Lerp(startScale, endScale, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = endScale;
    }
}
