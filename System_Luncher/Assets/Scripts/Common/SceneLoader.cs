using UnityEngine;
using UnityEngine.SceneManagement;

//씬 종류를 정의하는 열거형
public enum SceneType
{
    Title, //타이틀화면
    Lobby, //로비화면
    InGame, //게임화면
}

//씬 전환을 관리하는 싱클톤 클래스
public class SceneLoader : SingletonBehaviour<SceneLoader>
{
    //지정된 씬으로 전환하는 메소드
    public void LoadScene(SceneType sceneType)
    {
        Logger.Log($"{sceneType} scene loading...");

        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneType.ToString());
    }

    //현재 씬을 다시 로드하는 메서드
    public void ReloadScene()
    {
        Logger.Log($"{SceneManager.GetActiveScene().name} scene loading...");

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
