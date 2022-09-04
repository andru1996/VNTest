using Spine;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Skins : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation skeletonAnimation;

    private Skeleton skeleton;
    private SkeletonData skeletonData;


    [SerializeField] private bool isDressed;

    [SerializeField] private SkinName[] addBaseSkins;
    [SerializeField] private SkinName dressSkins;
    [SerializeField] private SkinName emotionSkins;

    [SerializeField] public SkinName EmotionSkins { get => emotionSkins; set => emotionSkins = value; }

    private void Start()
    {
        skeleton = skeletonAnimation.skeleton;
        skeletonData = skeleton.Data;
        ChangeSkin();
    }

    public void ChangeSkin()
    {
        Skin newSkin = new Skin("CustomSkin");

        foreach (SkinName addSkin in addBaseSkins)
        {
            newSkin.AddSkin(skeletonData.FindSkin(addSkin.skinName));
        }
        
        if(isDressed)
        {
            newSkin.AddSkin(skeletonData.FindSkin(dressSkins.skinName));
        }

        newSkin.AddSkin(skeletonData.FindSkin(emotionSkins.skinName));
        //newSkin.AddSkin(skeletonData.FindSkin("emotions/normal"));


        skeleton.SetSkin(newSkin);
        skeleton.SetSlotsToSetupPose();
    }
}

[Serializable]
public struct SkinName
{
    [SpineSkin] public string skinName;
}
