using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour {
    //ctrl K + crtl f indent
    public Text dialogText;//Diálogo 
    public Text nameText;//Nome de quem fala
    public GameObject dialogBox;//para saber se deve mostar ou não na UI
    public GameObject nameBox;

    public static DialogManager instance;

    //string[] declarando um array do tipo String
    public string[] dialogLines;

    public int currentLine;

    private bool justStarted;
	
	void Start () {
        //Dentro do dialog box eu tenho o objeto Text e dentro dele eu acesso a variável text, por isso é dialogText.text
       // dialogText.text = dialogLines[currentLine];//current Line tem 0 como default, vai incrementando. para teste apenas
        instance = this;
    }

    void Update()
    {

        //we can only do this if the dialog box is open
        if (dialogBox.activeInHierarchy)    //is this active at the scene at the moment?

        //--------------além do getAxisRaw eu tenho tambem o metodo getbutton disponiveis pela classe Input------------------------
        //-------------GetButton significa: o botão está sendo apertado? se o player segurar o botão ele skipa todo o diálogo de uma vez---------------------


        {//GetButtonUp só pega quando aperta
            if (Input.GetButtonUp("Fire1"))//Edit-ProjectSettings-Input(menu com os botoes para mapeamento, estou usando o Fire1 aqui(olhar classe playerController)
            {
                if (!justStarted)
                {
                    currentLine++;

                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);

                        PlayerController.instance.canMove = true;
                    }
                    else
                    {
                        CheckIfName();
                        dialogText.text = dialogLines[currentLine];
                    }
                                    }
                else
                {
                    justStarted = false;
                }
            }
        }

    }
    public void ShowDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;

        currentLine = 0;
        //de 0 para currentLine
        CheckIfName();
        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);

        justStarted = true;

        nameBox.SetActive(isPerson);


        PlayerController.instance.canMove = false;
    }

    //check if the current line is a name that we want to use
    public void CheckIfName()
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }

}

