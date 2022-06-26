using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Text YouDeadText;

    private bool isGameEnd;
    private float lastScaleTextTime;
    private const float scalingTextMaxTime = 0.5f;
    private float scalingFactor;
    private bool smallingScale;
    private Vector3 oldFontSize;

    private float scaleMax = 0.1f;
    private float scaleMin = 0.05f;
    private float scalingSpeed = 3f;

    void Start()
    {
        isGameEnd = false;
        smallingScale = false;
        lastScaleTextTime = 0;

        oldFontSize = YouDeadText.rectTransform.localScale;
    }

    void Update()
    {
        if (isGameEnd)
        {
            if (!smallingScale)
            {
                lastScaleTextTime += Time.deltaTime;
                scalingFactor = Mathf.SmoothStep(scaleMin, scaleMax, lastScaleTextTime / scalingTextMaxTime * scalingSpeed);
                YouDeadText.rectTransform.localScale = oldFontSize + new Vector3(1f, 1f, 1f) * scalingFactor;

                if (lastScaleTextTime >= scalingTextMaxTime)
                {
                    lastScaleTextTime = 0f;
                    smallingScale = true;
                }
            }
            else if (smallingScale)
            {
                lastScaleTextTime += Time.deltaTime;
                scalingFactor = Mathf.SmoothStep(scaleMax, scaleMin, lastScaleTextTime / scalingTextMaxTime * scalingSpeed);
                YouDeadText.rectTransform.localScale = oldFontSize + new Vector3(1f, 1f, 1f) * scalingFactor;

                if (lastScaleTextTime >= scalingTextMaxTime)
                {
                    lastScaleTextTime = 0f;
                    smallingScale = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        isGameEnd = true;
        YouDeadText.gameObject.SetActive(true);
    }
}
