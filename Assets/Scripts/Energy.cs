using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private float lifeTime;
    [SerializeField] private float fadespeed;

    private Tweener shakeTween;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOutWithDelay(lifeTime));
        shakeTween = transform.DOShakePosition(lifeTime, strength: new Vector3(0, 10, 0), vibrato: 2, randomness: 1, snapping: true, fadeOut: false).SetEase(Ease.InOutBounce);
    }

    public void CatchEnergy()
    {
        StartCoroutine(EnergyCatchedAnim());
    }

    public IEnumerator EnergyCatchedAnim()
    {
        shakeTween.Kill();
        yield return new WaitForSeconds(0);
        Vector3 energyTracker_position = GameObject.FindGameObjectsWithTag("EnergyTracker")[0].transform.position;
        GetComponent<RectTransform>().DOMove(energyTracker_position, 1).OnComplete(() => 
        {
            GameManager.Instance.AddEnergy(value);
            Destroy(gameObject); 
        });
    }

    private IEnumerator FadeOutWithDelay(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Color spriteColor = gameObject.GetComponent<Image>().color;
        while (spriteColor.a > 0)
        {
            yield return new WaitForSeconds(0.01f);
            spriteColor.a -= fadespeed;
            gameObject.GetComponent<Image>().color = spriteColor;
        }
        Destroy(gameObject);
    }

    public void SetValue(int value)
    {
        this.value = value;
    }




}
