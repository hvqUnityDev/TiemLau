using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NhanVien_", menuName = "NhanVien/Create New NhanVien")]
public class NhanVienBase : ScriptableObject
{
    [SerializeField] private Sprite avatar;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private string story;
    [SerializeField] private List<Skin> skins;
    [SerializeField] private List<Skill> skill;
    [SerializeField] private ValueNhanVien group;
    
    public Sprite Avatar => avatar;
    public string Name => name;
    public string Description => description;
    public string Story => story;
    public List<Skin> Skins => skins;
    public List<Skill> Skill => skill;
    public ValueNhanVien Group => group;
    
}
