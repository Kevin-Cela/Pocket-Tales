using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Option
{
    public int NextSceneId;
    public string Text;
    public Object Requirements;
    public Rewards Success;
    public Rewards Failure;
    public int rollRequirement;
}