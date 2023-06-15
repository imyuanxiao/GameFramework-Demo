using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class Demo2MenuController : MonoBehaviour
{
    public UIDocument gameMenuUI;
    public string buttonName;
    private Button button;

    private void Start()
    {
        // 获取按钮
        button = gameMenuUI.rootVisualElement.Q<Button>(buttonName);

        // 绑定按钮点击事件处理函数
        button.clicked += OnButtonClick;
    }

    private void OnButtonClick()
    {
        // 执行按钮点击后的逻辑
        Log.Debug("按钮被点击了！");

        SceneComponent Scene =  GameEntry.GetComponent<SceneComponent>();
        
        // 卸载所有场景
        string[] loadedSceneAssetNames = Scene.GetLoadedSceneAssetNames();
        for (int i = 0; i < loadedSceneAssetNames.Length; i++)
        {
            Scene.UnloadScene(loadedSceneAssetNames[i]);
        }

        // 加载游戏场景
        Scene.LoadScene("Assets/Scenes/Demo2/Demo2Game.unity", this);


    }
}