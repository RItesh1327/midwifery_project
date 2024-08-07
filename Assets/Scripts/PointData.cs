using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject")]
public class PointData : ScriptableObject
{
    public string question;
    public string[] choices;
    public int correctChoice;
    public string explanation;
}
