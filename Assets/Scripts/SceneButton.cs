using UnityEngine;
public class SceneButton : MonoBehaviour
{
    public string targetScene;
    public void FindSceneScript()
    {
        SceneScript.Instance.ChangeScene(targetScene);
    }
}
