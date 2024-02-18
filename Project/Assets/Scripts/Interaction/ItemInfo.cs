using UnityEditor;
using UnityEngine;

public enum ActionType
{
    None,
    Eat,
    Weapon,
    Build
}

public enum WeaponType
{
    Default,
    Pickaxe,
    Axe
}

#if UNITY_EDITOR

[CustomEditor(typeof(ItemInfo))]
public class ItemInfoEditor : Editor
{
    private SerializedProperty actionTypeProp;
    private SerializedProperty valueAddHealthProp;
    private SerializedProperty valueAddHungerProp;
    private SerializedProperty damageProp;
    private SerializedProperty prefabsItemInArmProp;
    private SerializedProperty weaponTypeProp;

    private void OnEnable()
    {
        actionTypeProp = serializedObject.FindProperty("actionType");
        valueAddHealthProp = serializedObject.FindProperty("valueAddHealth");
        valueAddHungerProp = serializedObject.FindProperty("valueAddHunger");
        damageProp = serializedObject.FindProperty("damage");
        prefabsItemInArmProp = serializedObject.FindProperty("prefabsItemInArm");
        weaponTypeProp = serializedObject.FindProperty("weaponType");
       
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("id"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("name"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("description"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("icon"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("prefabs"));
        EditorGUILayout.Space(10);
        
        EditorGUILayout.PropertyField(actionTypeProp);

        ActionType actionType = (ActionType)actionTypeProp.enumValueIndex;

        switch (actionType)
        {
            case ActionType.Eat:
                EditorGUILayout.PropertyField(valueAddHealthProp);
                EditorGUILayout.PropertyField(valueAddHungerProp);
                break;
            case ActionType.Weapon:
                EditorGUILayout.PropertyField(damageProp);
                EditorGUILayout.PropertyField(prefabsItemInArmProp);
                EditorGUILayout.PropertyField(weaponTypeProp);
                break;
        }
        
        
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemInfo : ScriptableObject
{
    public int id;
    public new string name;
    public string description;
    public Sprite icon;
    public GameObject prefabs;
    
    public ActionType actionType;
    
    //Поля для actionType = Weapon
    public int damage; 
    public GameObject prefabsItemInArm;
    public WeaponType weaponType;

    //Поля для actionType = Eat
    public int valueAddHealth;
    public int valueAddHunger;
    
}
