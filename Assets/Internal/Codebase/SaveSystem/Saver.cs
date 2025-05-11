using Internal.Codebase;
using Internal.Codebase.Infrastructure;
using UnityEngine;

public class Saver : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private PlayerComponent player;

    private SaveData saveData;
    private Wallet wallet;
    private bool isInitialized = false;

    private void OnEnable() => 
        GameEventBus.SaveGame += Save;

    private void OnDisable() => 
        GameEventBus.SaveGame -= Save;

    private void Awake() => 
        Initialize();

    public void Save()
    {
        if (!isInitialized)
        {
            Debug.LogWarning("Attempted to save before initialization!");
            return;
        }

        UpdateSaveData();
        
        try
        {
            PlayerDataSave.Save(saveData);
            Debug.Log("Game saved successfully");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to save game: {e.Message}");
        }
    }

    private void Initialize()
    {
        if (isInitialized) return;

        if (player == null)
        {
            Debug.LogError("PlayerComponent reference is missing in Saver!");
            return;
        }

        wallet = player.Wallet;
        if (wallet == null)
        {
            Debug.LogError("Wallet component is missing on player!");
            return;
        }

        if (dialogueManager == null)
        {
            Debug.LogError("DialogueManager reference is missing in Saver!");
            return;
        }

        LoadData();
        ApplyLoadedData();
        
        isInitialized = true;
    }

    private void LoadData()
    {
        try
        {
            saveData = PlayerDataSave.Load<SaveData>();
            if (saveData == null)
            {
                Debug.Log("No save data found, creating new...");
                saveData = new SaveData();
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to load save data: {e.Message}");
            saveData = new SaveData();
        }
    }

    private void ApplyLoadedData()
    {
        wallet.SetSavedBalance(saveData.PlayerBalance);
        dialogueManager.SetIsTutorialCompleted(saveData.IsTutorialCompleted);
    }

    private void UpdateSaveData()
    {
        saveData.IsTutorialCompleted = dialogueManager.IsTutorialCompleted;
        saveData.PlayerBalance = wallet.PlayerBalance;
        Debug.Log($"Saving IsTutorialCompleted: {dialogueManager.IsTutorialCompleted}");
    }
}