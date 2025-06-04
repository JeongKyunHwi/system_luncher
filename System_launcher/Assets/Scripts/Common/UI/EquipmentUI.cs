// 문자열 처리를 위한 StringBuilder 사용
using System.Text;
// TextMeshPro 텍스트 컴포넌트 사용
using TMPro;
// Unity 기본 라이브러리 사용
using UnityEngine;
// Unity UI 컴포넌트 사용
using UnityEngine.UI;

// 장비 UI 데이터 클래스 - BaseUIData를 상속받음
public class EquipmentUIData : BaseUIData
{
    // 아이템 시리얼 번호
    public long SerialNumber;
    // 아이템 ID
    public int ItemId;

    public bool IsEquipped;
}

// 장비 UI 클래스 - BaseUI를 상속받음
public class EquipmentUI : BaseUI
{
    // 아이템 등급 배경 이미지 컴포넌트
    public Image ItemGradeBg;
    // 아이템 아이콘 이미지 컴포넌트
    public Image ItemIcon;
    // 아이템 등급 텍스트 컴포넌트
    public TextMeshProUGUI ItemGradeTxt;
    // 아이템 이름 텍스트 컴포넌트
    public TextMeshProUGUI ItemNameTxt;
    // 공격력 수치 텍스트 컴포넌트
    public TextMeshProUGUI AttackPowerAmountTxt;
    // 방어력 수치 텍스트 컴포넌트
    public TextMeshProUGUI DefenseAmountTxt;

    // 장비 UI 데이터 멤버 변수
    private EquipmentUIData m_EquipmentUIData;

    // UI 정보를 설정하는 메서드 오버라이드
    public override void SetInfo(BaseUIData uiData)
    {
        // 부모 클래스의 SetInfo 메서드 호출
        base.SetInfo(uiData);

        // UI 데이터를 EquipmentUIData로 캐스팅
        m_EquipmentUIData = uiData as EquipmentUIData;
        // 캐스팅 실패 시 에러 처리
        if (m_EquipmentUIData == null)
        {
            // 에러 로그 출력
            Logger.LogError("m_EquipmentUIData is invalid.");
            // 메서드 종료
            return;
        }

        // 아이템 ID로 아이템 데이터 가져오기
        var itemData = DataTableManager.Instance.GetItemData(m_EquipmentUIData.ItemId);
        // 아이템 데이터가 없는 경우 에러 처리
        if (itemData == null)
        {
            // 에러 로그 출력 (아이템 ID 포함)
            Logger.LogError($"Item data is invalid. ItemId:{m_EquipmentUIData.ItemId}");
            // 메서드 종료
            return;
        }

        // 아이템 ID에서 등급 정보 추출 (천의 자리 숫자)
        var itemGrade = (ItemGrade)((m_EquipmentUIData.ItemId / 1000) % 10);
        // 등급에 맞는 배경 텍스처 로드
        var gradeBgTexture = Resources.Load<Texture2D>($"Textures/{itemGrade}");
        // 배경 텍스처가 존재하는 경우
        if (gradeBgTexture != null)
        {
            // 텍스처로 스프라이트 생성하여 배경 이미지에 설정
            ItemGradeBg.sprite = Sprite.Create(gradeBgTexture, new Rect(0, 0, gradeBgTexture.width, gradeBgTexture.height), new Vector2(1f, 1f));
        }

        // 아이템 등급 텍스트 설정
        ItemGradeTxt.text = itemGrade.ToString();
        // 등급별 색상 코드를 저장할 변수
        var hexColor = string.Empty;
        // 아이템 등급에 따른 색상 분기 처리
        switch (itemGrade)
        {
            // 일반 등급인 경우
            case ItemGrade.Common:
                // 파란색 설정
                hexColor = "#1AB3FF";
                break;
            // 고급 등급인 경우
            case ItemGrade.Uncommon:
                // 초록색 설정
                hexColor = "#51C52C";
                break;
            // 희귀 등급인 경우
            case ItemGrade.Rare:
                // 분홍색 설정
                hexColor = "#EA5AFF";
                break;
            // 에픽 등급인 경우
            case ItemGrade.Epic:
                // 주황색 설정
                hexColor = "#FF9900";
                break;
            // 전설 등급인 경우
            case ItemGrade.Legendary:
                // 빨간색 설정
                hexColor = "#F24949";
                break;
            // 기본 케이스 (처리 없음)
            default:
                break;
        }

        // 색상 변환용 변수 선언
        Color color;
        // Hex 색상 코드를 Color로 변환 시도
        if (ColorUtility.TryParseHtmlString(hexColor, out color))
        {
            // 변환 성공 시 등급 텍스트 색상 적용
            ItemGradeTxt.color = color;
        }

        // 아이템 ID를 문자열로 변환하여 StringBuilder 생성
        StringBuilder sb = new StringBuilder(m_EquipmentUIData.ItemId.ToString());
        // 두 번째 자리 숫자를 '1'로 변경 (아이콘용 ID 생성)
        sb[1] = '1';
        // 아이콘 이름으로 사용할 문자열 생성
        var itemIconName = sb.ToString();

        // 아이콘 텍스처 로드
        var itemIconTexture = Resources.Load<Texture2D>($"Textures/{itemIconName}");
        // 아이콘 텍스처가 존재하는 경우
        if (itemIconTexture != null)
        {
            // 텍스처로 스프라이트 생성하여 아이콘 이미지에 설정
            ItemIcon.sprite = Sprite.Create(itemIconTexture, new Rect(0, 0, itemIconTexture.width, itemIconTexture.height), new Vector2(1f, 1f));
        }

        // 아이템 이름 텍스트 설정
        ItemNameTxt.text = itemData.ItemName;
        // 공격력 수치 텍스트 설정 (+ 기호 포함)
        AttackPowerAmountTxt.text = $"+{itemData.AttackPower}";
        // 방어력 수치 텍스트 설정 (+ 기호 포함)
        DefenseAmountTxt.text = $"+{itemData.Defense}";
    }
}