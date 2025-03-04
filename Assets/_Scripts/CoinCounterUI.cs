using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current
                                           , toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration;

    private float containerInitPosition
                , moveAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    public void UpdateScore (int score)
    {
        toUpdate.SetText($"{score}");
        Debug.Log($"From Update {containerInitPosition}");
        coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration);
        StartCoroutine(ResetCoinContainer(score));
    }

    private IEnumerator ResetCoinContainer (int score)
    {
        yield return new WaitForSeconds(duration);

        current.SetText($"{score}");
        Debug.Log($"From Coroutine {containerInitPosition}");
        //Vector3 localPos = coinTextContainer.localPosition;
        coinTextContainer.DOLocalMoveY(containerInitPosition, 0);
    }
}
