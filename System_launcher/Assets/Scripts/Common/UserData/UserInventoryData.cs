// 시스템 관련 라이브러리 사용
using System;
// 코루틴 관련 라이브러리 사용
using System.Collections;
// 컬렉션 관련 라이브러리 사용
using System.Collections.Generic;
// Unity 기본 라이브러리 사용
using UnityEngine;

// 직렬화 가능한 클래스로 설정
[Serializable]
// 사용자 아이템 데이터 클래스
public class UserItemData
{
    // 고유한 시리얼 번호
    public long SerialNumber; //unique value
    // 아이템 ID
    public int ItemId;

    // 사용자 아이템 데이터 생성자
    public UserItemData(long serialNumber, int itemId)
    {
        // 시리얼 번호 설정
        SerialNumber = serialNumber;
        // 아이템 ID 설정
        ItemId = itemId;
    }
}

// JSONUtility를 사용하여 JSON으로 파싱하기 위한 래퍼 클래스
//wrapper class to parse data to JSON using JSONUtility
[Serializable]
// 사용자 인벤토리 아이템 데이터 리스트 래퍼 클래스
public class UserInventoryItemDataListWrapper
{
    // 인벤토리 아이템 데이터 리스트
    public List<UserItemData> InventoryItemDataList;
}

// 사용자 인벤토리 데이터 클래스 - IUserData 인터페이스 구현
public class UserInventoryData : IUserData
{
    // 장착된 무기 데이터 프로퍼티
    public UserItemData EquippedWeaponData { get; set; }
    // 장착된 방패 데이터 프로퍼티
    public UserItemData EquippedShieldData { get; set; }
    // 장착된 가슴 방어구 데이터 프로퍼티
    public UserItemData EquippedChestArmorData { get; set; }
    // 장착된 부츠 데이터 프로퍼티
    public UserItemData EquippedBootsData { get; set; }
    // 장착된 장갑 데이터 프로퍼티
    public UserItemData EquippedGlovesData { get; set; }
    // 장착된 액세서리 데이터 프로퍼티
    public UserItemData EquippedAccessoryData { get; set; }

    // 인벤토리 아이템 데이터 리스트 프로퍼티 (빈 리스트로 초기화)
    public List<UserItemData> InventoryItemDataList { get; set; } = new List<UserItemData>();

    // 기본 데이터를 설정하는 메서드
    public void SetDefaultData()
    {
        // 로그 출력
        Logger.Log($"{GetType()}::SetDefaultData");

        // 시리얼 번호 생성 방식: 현재 날짜시간(yyyyMMddHHmmss) + 랜덤 4자리 숫자
        //serial number => DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4") 

        // 아이템 ID 11001로 아이템 데이터 추가
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 11001));
        // 아이템 ID 11002로 아이템 데이터 추가
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 11002));
        // 아이템 ID 22001로 아이템 데이터 추가
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 22001));
        // 아이템 ID 22002로 아이템 데이터 추가
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 22002));
        // 아이템 ID 33001로 아이템 데이터 추가
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 33001));
        // 아이템 ID 33002로 아이템 데이터 추가
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 33002));
        // 아이템 ID 44001로 아이템 데이터 추가
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 44001));
        // 아이템 ID 44002로 아이템 데이터 추가
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 44002));
        // 아이템 ID 55001로 아이템 데이터 추가
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 55001));
        // 아이템 ID 55002로 아이템 데이터 추가
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 55002));
        // 아이템 ID 65001로 아이템 데이터 추가
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 65001));
        // 아이템 ID 65002로 아이템 데이터 추가
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 65002));

        // 첫 번째 아이템을 무기로 장착
        EquippedWeaponData = new UserItemData(InventoryItemDataList[0].SerialNumber, InventoryItemDataList[0].ItemId);
        // 세 번째 아이템을 방패로 장착
        EquippedShieldData = new UserItemData(InventoryItemDataList[2].SerialNumber, InventoryItemDataList[2].ItemId);
    }

    // 데이터를 로드하는 메서드
    public bool LoadData()
    {
        // 로그 출력
        Logger.Log($"{GetType()}::LoadData");

        // 결과 변수 초기화
        bool result = false;

        // 예외 처리 시작
        try
        {
            // PlayerPrefs에서 장착된 무기 데이터 JSON 가져오기
            string weaponJson = PlayerPrefs.GetString("EquippedWeaponData");
            // JSON 문자열이 비어있지 않은 경우
            if (!string.IsNullOrEmpty(weaponJson))
            {
                // JSON을 UserItemData 객체로 변환
                EquippedWeaponData = JsonUtility.FromJson<UserItemData>(weaponJson);
                // 로그 출력
                Logger.Log($"EquippedWeaponData: SN:{EquippedWeaponData.SerialNumber} ItemId:{EquippedWeaponData.ItemId}");
            }

            // PlayerPrefs에서 장착된 방패 데이터 JSON 가져오기
            string shieldJson = PlayerPrefs.GetString("EquippedShieldData");
            // JSON 문자열이 비어있지 않은 경우
            if (!string.IsNullOrEmpty(shieldJson))
            {
                // JSON을 UserItemData 객체로 변환
                EquippedShieldData = JsonUtility.FromJson<UserItemData>(shieldJson);
                // 로그 출력
                Logger.Log($"EquippedShieldData: SN:{EquippedShieldData.SerialNumber} ItemId:{EquippedShieldData.ItemId}");
            }

            // PlayerPrefs에서 장착된 가슴 방어구 데이터 JSON 가져오기
            string chestArmorJson = PlayerPrefs.GetString("EquippedChestArmorData");
            // JSON 문자열이 비어있지 않은 경우
            if (!string.IsNullOrEmpty(chestArmorJson))
            {
                // JSON을 UserItemData 객체로 변환
                EquippedChestArmorData = JsonUtility.FromJson<UserItemData>(chestArmorJson);
                // 로그 출력
                Logger.Log($"EquippedChestArmorData: SN:{EquippedChestArmorData.SerialNumber} ItemId:{EquippedChestArmorData.ItemId}");
            }

            // PlayerPrefs에서 장착된 부츠 데이터 JSON 가져오기
            string bootsJson = PlayerPrefs.GetString("EquippedBootsData");
            // JSON 문자열이 비어있지 않은 경우
            if (!string.IsNullOrEmpty(bootsJson))
            {
                // JSON을 UserItemData 객체로 변환
                EquippedBootsData = JsonUtility.FromJson<UserItemData>(bootsJson);
                // 로그 출력
                Logger.Log($"EquippedBootsArmorData: SN:{EquippedBootsData.SerialNumber} ItemId:{EquippedBootsData.ItemId}");
            }

            // PlayerPrefs에서 장착된 장갑 데이터 JSON 가져오기
            string glovesJson = PlayerPrefs.GetString("EquippedGlovesData");
            // JSON 문자열이 비어있지 않은 경우
            if (!string.IsNullOrEmpty(glovesJson))
            {
                // JSON을 UserItemData 객체로 변환
                EquippedGlovesData = JsonUtility.FromJson<UserItemData>(glovesJson);
                // 로그 출력
                Logger.Log($"EquippedGlovesData: SN:{EquippedGlovesData.SerialNumber} ItemId:{EquippedGlovesData.ItemId}");
            }

            // PlayerPrefs에서 장착된 액세서리 데이터 JSON 가져오기
            string accessoryJson = PlayerPrefs.GetString("EquippedAccessoryData");
            // JSON 문자열이 비어있지 않은 경우
            if (!string.IsNullOrEmpty(accessoryJson))
            {
                // JSON을 UserItemData 객체로 변환
                EquippedAccessoryData = JsonUtility.FromJson<UserItemData>(accessoryJson);
                // 로그 출력
                Logger.Log($"EquippedChestArmorData: SN:{EquippedAccessoryData.SerialNumber} ItemId:{EquippedAccessoryData.ItemId}");
            }

            // PlayerPrefs에서 인벤토리 아이템 데이터 리스트 JSON 가져오기
            string inventoryItemDataListJson = PlayerPrefs.GetString("InventoryItemDataList");
            // JSON 문자열이 비어있지 않은 경우
            if (!string.IsNullOrEmpty(inventoryItemDataListJson))
            {
                // JSON을 래퍼 객체로 변환
                UserInventoryItemDataListWrapper itemDataListWrapper = JsonUtility.FromJson<UserInventoryItemDataListWrapper>(inventoryItemDataListJson);
                // 래퍼에서 실제 리스트 데이터 추출
                InventoryItemDataList = itemDataListWrapper.InventoryItemDataList;

                // 인벤토리 아이템 리스트 로그 출력
                Logger.Log("InventoryItemDataList");
                // 모든 아이템 데이터를 순회하며 로그 출력
                foreach (var item in InventoryItemDataList)
                {
                    // 각 아이템의 시리얼 번호와 ID 로그 출력
                    Logger.Log($"SerialNumber:{item.SerialNumber} ItemId:{item.ItemId}");
                }
            }

            // 로드 성공으로 설정
            result = true;
        }
        // 예외 발생 시 처리
        catch (System.Exception e)
        {
            // 로드 실패 로그 출력
            Logger.Log("Load failed (" + e.Message + ")");
        }

        // 결과 반환
        return result;
    }

    // 데이터를 저장하는 메서드
    public bool SaveData()
    {
        // 로그 출력
        Logger.Log($"{GetType()}::SaveData");

        // 결과 변수 초기화
        bool result = false;

        // 예외 처리 시작
        try
        {
            // 무기 데이터를 JSON으로 변환
            string weaponJson = JsonUtility.ToJson(EquippedWeaponData);
            // PlayerPrefs에 무기 데이터 저장
            PlayerPrefs.SetString("EquippedWeaponData", weaponJson);
            // 무기 데이터가 null이 아닌 경우
            if (EquippedWeaponData != null)
            {
                // 로그 출력
                Logger.Log($"EquippedWeaponData: SN:{EquippedWeaponData.SerialNumber} ItemId:{EquippedWeaponData.ItemId}");
            }

            // 방패 데이터를 JSON으로 변환
            string shieldJson = JsonUtility.ToJson(EquippedShieldData);
            // PlayerPrefs에 방패 데이터 저장
            PlayerPrefs.SetString("EquippedShieldData", shieldJson);
            // 방패 데이터가 null이 아닌 경우
            if (EquippedShieldData != null)
            {
                // 로그 출력
                Logger.Log($"EquippedShieldData: SN:{EquippedShieldData.SerialNumber} ItemId:{EquippedShieldData.ItemId}");
            }

            // 가슴 방어구 데이터를 JSON으로 변환
            string chestArmorJson = JsonUtility.ToJson(EquippedChestArmorData);
            // PlayerPrefs에 가슴 방어구 데이터 저장
            PlayerPrefs.SetString("EquippedChestArmorData", chestArmorJson);
            // 가슴 방어구 데이터가 null이 아닌 경우
            if (EquippedChestArmorData != null)
            {
                // 로그 출력
                Logger.Log($"EquippedChestArmorData: SN:{EquippedChestArmorData.SerialNumber} ItemId:{EquippedChestArmorData.ItemId}");
            }

            // 부츠 데이터를 JSON으로 변환
            string bootsJson = JsonUtility.ToJson(EquippedBootsData);
            // PlayerPrefs에 부츠 데이터 저장
            PlayerPrefs.SetString("EquippedBootsData", bootsJson);
            // 부츠 데이터가 null이 아닌 경우
            if (EquippedBootsData != null)
            {
                // 로그 출력
                Logger.Log($"EquippedBootsData: SN:{EquippedBootsData.SerialNumber} ItemId:{EquippedBootsData.ItemId}");
            }

            // 장갑 데이터를 JSON으로 변환
            string glovesJson = JsonUtility.ToJson(EquippedGlovesData);
            // PlayerPrefs에 장갑 데이터 저장
            PlayerPrefs.SetString("EquippedGlovesData", glovesJson);
            // 장갑 데이터가 null이 아닌 경우
            if (EquippedGlovesData != null)
            {
                // 로그 출력
                Logger.Log($"EquippedGlovesData: SN:{EquippedGlovesData.SerialNumber} ItemId:{EquippedGlovesData.ItemId}");
            }

            // 액세서리 데이터를 JSON으로 변환
            string accessoryJson = JsonUtility.ToJson(EquippedAccessoryData);
            // PlayerPrefs에 액세서리 데이터 저장
            PlayerPrefs.SetString("EquippedAccessoryData", accessoryJson);
            // 액세서리 데이터가 null이 아닌 경우
            if (EquippedAccessoryData != null)
            {
                // 로그 출력
                Logger.Log($"EquippedAccessoryData: SN:{EquippedAccessoryData.SerialNumber} ItemId:{EquippedAccessoryData.ItemId}");
            }

            // 인벤토리 아이템 데이터 리스트 래퍼 객체 생성
            UserInventoryItemDataListWrapper inventoryItemDataListWrapper = new UserInventoryItemDataListWrapper();
            // 래퍼에 인벤토리 아이템 데이터 리스트 설정
            inventoryItemDataListWrapper.InventoryItemDataList = InventoryItemDataList;
            // 래퍼를 JSON으로 변환
            string inventoryItemDataListJson = JsonUtility.ToJson(inventoryItemDataListWrapper);
            // PlayerPrefs에 인벤토리 아이템 데이터 리스트 저장
            PlayerPrefs.SetString("InventoryItemDataList", inventoryItemDataListJson);

            // 인벤토리 아이템 리스트 로그 출력
            Logger.Log("InventoryItemDataList");
            // 모든 아이템 데이터를 순회하며 로그 출력
            foreach (var item in InventoryItemDataList)
            {
                // 각 아이템의 시리얼 번호와 ID 로그 출력
                Logger.Log($"SerialNumber:{item.SerialNumber} ItemId:{item.ItemId}");
            }
            // PlayerPrefs 저장 실행
            PlayerPrefs.Save();

            // 저장 성공으로 설정
            result = true;
        }
        // 예외 발생 시 처리
        catch (System.Exception e)
        {
            // 저장 실패 로그 출력
            Logger.Log("Load failed (" + e.Message + ")");
        }

        // 결과 반환
        return result;
    }
}