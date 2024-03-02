using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Configuration
{
     public int NextSceneId;
     public SceneModifiers[] SceneModifiers;
     public Rewards Rewards;
     public Object[] Options;
     public bool isAmbush;
     public Object[] Enemies;
}
