using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using Sirenix.OdinInspector;
using UnityEditor;

public class HeroAvatarEditorWindow : OdinMenuEditorWindow
{
    [MenuItem("Tools/HeroAvatarEditor")]
    static void OpenWindow()
    {
        GetWindow<HeroAvatarEditorWindow>().Show();
    }

    private CreateNewHeroAvatar createNewHeroAvatar;

    protected override void OnDestroy()
    {
        base.OnDestroy();

        if (createNewHeroAvatar != null)
            DestroyImmediate(createNewHeroAvatar.avatarData);
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();
        createNewHeroAvatar = new CreateNewHeroAvatar();
        tree.Add("Create New Hero Avatar", createNewHeroAvatar);
        tree.AddAllAssetsAtPath("HeroAvatar", "Assets/Data/HeroAvatar", typeof(HeroAvatarData));

        return tree;
    }

    protected override void OnBeginDrawEditors()
    {
        OdinMenuTreeSelection selected = this.MenuTree.Selection;

        SirenixEditorGUI.BeginHorizontalToolbar();
        {
            GUILayout.FlexibleSpace();
            if(SirenixEditorGUI.ToolbarButton("Delete Current"))
            {
                HeroAvatarData asset = selected.SelectedValue as HeroAvatarData;
                var path = AssetDatabase.GetAssetPath(asset);
                AssetDatabase.DeleteAsset(path);
                AssetDatabase.SaveAssets();
            }
        }
        SirenixEditorGUI.EndHorizontalToolbar();
    }

    public class CreateNewHeroAvatar
    {
        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)]
        public HeroAvatarData avatarData;

        public CreateNewHeroAvatar()
        {
            avatarData = ScriptableObject.CreateInstance<HeroAvatarData>();
            avatarData.avatarName = "New Hero Avatar Name";
        }

        [Button("Add New Hero Avatar")]
        private void CreateNewData()
        {
            AssetDatabase.CreateAsset(avatarData, $"Assets/Data/HeroAvatar/{avatarData.avatarName}.asset");
            AssetDatabase.SaveAssets();

            avatarData = ScriptableObject.CreateInstance<HeroAvatarData>();
            avatarData.avatarName = "New Hero Avatar Name";
        }
    }
}


