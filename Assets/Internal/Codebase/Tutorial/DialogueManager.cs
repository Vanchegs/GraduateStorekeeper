using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using Internal.Codebase.Infrastructure;
using TMPro;

namespace Internal.Codebase
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private TMP_Text dialogueText;
        [SerializeField] private List<string> dialogues;
        [SerializeField] private RectTransform startPosition;
        [SerializeField] private RectTransform finalPosition;
        
        private int currentLine;
        private bool isPanelActivate;

        public bool IsTutorialCompleted { get; private set; }

        private void Start()
        {
            StartDialogue(dialogues);
        }

        public void StartDialogue(List<string> lines)
        {
            if (IsTutorialCompleted)
                return;
            
            MovePanel();
            
            dialogues = lines;
            currentLine = 0;
            ShowNextLine();
        }
        
        public void ShowNextLine()
        {
            if (currentLine < dialogues.Count)
            {
                dialogueText.text = dialogues[currentLine];
                currentLine++;
            }
            else
            {
                EndDialogue();
                CompleteTutorial();
            }
        }
        
        public void MovePanel()
        {
            if (isPanelActivate == false)
            {
                dialoguePanel.transform.DOMoveY(finalPosition.position.y, 1f, false);
                isPanelActivate = true;
                dialoguePanel.SetActive(isPanelActivate);
            }
            else
            {
                dialoguePanel.transform.DOMoveY(startPosition.position.y, 1f)
                    .SetUpdate(true)
                    .OnComplete(() => 
                    {
                        isPanelActivate = false;
                        dialoguePanel.SetActive(isPanelActivate);
                    });
            }
        }

        public void SetIsTutorialCompleted(bool isCompleted) => 
            IsTutorialCompleted = isCompleted;

        private void EndDialogue() =>
            dialoguePanel.SetActive(false);

        private void CompleteTutorial()
        {
            IsTutorialCompleted = true;
            GameEventBus.SaveGame?.Invoke();
        }
    }
}
