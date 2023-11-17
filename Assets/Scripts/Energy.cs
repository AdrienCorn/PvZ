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
        GameManager.Instance.AddEnergy(value);
        StartCoroutine(EnergyCatchedAnim());
    }

    public IEnumerator EnergyCatchedAnim()
    {
        yield return new WaitForSeconds(0);
        //Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //Vector3 corner = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        GetComponent<RectTransform>().DOLocalMove(new Vector3(-500, 300, 1), 1).OnComplete(() => 
        {
            shakeTween.Kill();
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

    




}
