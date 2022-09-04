using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HeartBit : MonoBehaviour
{
    private void Start()
    {
        PlayHeartBit();
    }

    private void PlayHeartBit()
    {
        float timeAnimation = Mathf.Clamp(((float)(GameController.instance.LoseTime - GameController.instance.gamingData.gameTime) / (float)GameController.instance.LoseTime) * 0.5f, 0.1f, 1f);
        transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), timeAnimation).OnComplete(() => 
        {
            float timeAnimation = Mathf.Clamp(((float)(GameController.instance.LoseTime - GameController.instance.gamingData.gameTime) / (float)GameController.instance.LoseTime) * 0.5f, 0.1f, 1f);
            transform.DOScale(new Vector3(1f, 1f, 1f), timeAnimation).OnComplete(() =>
            {
                PlayHeartBit();
            });
        });
    }
}
