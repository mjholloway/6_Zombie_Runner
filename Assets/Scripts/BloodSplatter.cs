using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodSplatter : MonoBehaviour
{
    [SerializeField] float decayTime = .75f;
    RawImage image;

    private void Start()
    {
        image = GetComponent<RawImage>();
        gameObject.SetActive(false);
    }

    public void DisplayBlood()
    {
        if (gameObject.activeSelf == true)
        {
            StopCoroutine(StartDecay());
            gameObject.SetActive(false);
        }
        gameObject.SetActive(true);
        StartCoroutine(StartDecay());
    }

    private IEnumerator StartDecay()
    {
        image.CrossFadeAlpha(0, decayTime, true);
        yield return new WaitForSeconds(decayTime);
        gameObject.SetActive(false);
    }
}
