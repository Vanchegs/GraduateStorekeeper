using UnityEngine;
using System.Collections.Generic;
using Internal.Codebase.Infrastructure;
using TMPro;

namespace Internal.Codebase
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private TMP_Text dialogueText;
        [SerializeField] private List<string> dialogues;
        
        private int currentLine;

        public bool IsTutorialCompleted;
        
        void Start()
        {
            if (IsTutorialCompleted == false)
                StartDialogue(dialogues);
        }

        public void StartDialogue(List<string> lines)
        {
            dialogues = lines;
            currentLine = 0;
            dialoguePanel.SetActive(true);
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
                EndDialogue();
        }

        private void EndDialogue() =>
            dialoguePanel.SetActive(false);

        private void CompleteTutorial() => 
            IsTutorialCompleted = true;
    }
}
