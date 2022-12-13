using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NhanVien_", menuName = "NhanVien/Create New NhanVien")]
public class NhanVien : ScriptableObject
{
    [SerializeField] private Sprite avatar;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private string story;
    [SerializeField] private int pointService;
    [SerializeField] private List<Skin> skins;

    public Sprite Avatar => avatar;
    public string Name => name;
    public string Description => description;
    public string Story => story;
    public int PointService => pointService;
    public List<Skin> Skins => skins;
}
