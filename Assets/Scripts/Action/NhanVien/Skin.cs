using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Skin
{
    [SerializeField] private Sprite avatar;
    [SerializeField] private Sprite fullSkin;
    [SerializeField] private string nameSkin;
    [SerializeField] private Sprite coat;
    [SerializeField] private int pointSkin;
    [SerializeField] private int price;
    
    
    public Sprite Avatar => avatar; 
    public Sprite FullSkin => fullSkin; 
    public string NameSkin => nameSkin;
    public Sprite Coat => coat;
    public int PointSkin => pointSkin;
    public int Price => price;
}
