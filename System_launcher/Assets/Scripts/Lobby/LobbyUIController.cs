using UnityEngine;

public class LobbyUIController : MonoBehaviour
{
    public void Init()
    {

    }
    public void OnClickSettingsBtn()
    {
        Logger.Log($"{GetType()}::OnClickSettingsBtn");

        var uiData = new BaseUIData();
        UIManager.Instance.OpenUI<SettingsUI>(uiData);
    }
}
