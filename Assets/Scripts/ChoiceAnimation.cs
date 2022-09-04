using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VNEngine;

public class ChoiceAnimation : MonoBehaviour
{
    [SerializeField] private AnimationButton[] animationButtons;

    public void ShowChoiceAnimation(string actorName)
    {
        gameObject.SetActive(true);
        SkeletonAnimation skeletonAnimation = ActorManager.Get_Actor(actorName).GetComponentInChildren<SkeletonAnimation>();
        foreach (AnimationButton animationButton in animationButtons)
        {
            animationButton.button.onClick.AddListener(() => { skeletonAnimation.AnimationName = animationButton.animationName;});
        }
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
}

[Serializable]
struct AnimationButton
{
    public Button button;
    public string animationName;
}