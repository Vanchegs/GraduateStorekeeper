using UnityEngine;
using System.Collections.Generic;
using TMPro;

namespace Internal.Codebase
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private TMP_Text dialogueText;
        [SerializeField] private List<string> dialogues;
        
        private int currentLine; 
    
        void Start() => 
            StartDialogue(dialogues);

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
    
        void EndDialogue()
        {
            dialoguePanel.SetActive(false);
        }
    }
}
