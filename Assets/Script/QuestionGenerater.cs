using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestionGenerater : MonoBehaviour
{
    public int NumberToFindRandomNumber;
    public string Ans;
   
    string RandomNumber1;
    string RandomNumber2;

    public TMP_Text DisplayOutPut;
    public TMP_Text RightOrWrong;

    public TMP_Text UserEnterFiled;

    [SerializeField] private List<string> Signs = new List<string>();
    public string signs;
    public Animator animator;


    private void Start()
    {
        RandomNumberGenerater();
    }
    


    public void RandomNumberGenerater()
    {
       
        RightOrWrong.text = " Please answer the question below to continue.";
        RightOrWrong.color = Color.white;
        RandomNumber1 = Random.Range(0, NumberToFindRandomNumber).ToString("0");
        RandomNumber2 = Random.Range(0, NumberToFindRandomNumber).ToString("0");



        int sign = Random.Range(0, Signs.Count);
        signs = Signs[sign];

        DisplayOutPut.text = ("What is " + RandomNumber1 + "" + signs + "" + RandomNumber2 + " ?");
        CheckSum();
      
    }



    public void CheckSum()
    {
        int TempNumber1 = int.Parse(RandomNumber1);
        int TempNumber2 = int.Parse(RandomNumber2);


        if (signs == '*'.ToString())
        {
            Ans = (TempNumber1 * TempNumber2).ToString();
        }
        else if (signs == '+'.ToString())
        {
            Ans = (TempNumber1 + TempNumber2).ToString();
        }
        else if (signs == '-'.ToString())
        {
            Ans = (TempNumber1 - TempNumber2).ToString();
        }
        else if (signs == '/'.ToString())
        {
            Ans = (TempNumber1 / TempNumber2).ToString();
        }
        else if (signs == '%'.ToString())
        {
            Ans = (TempNumber1 / TempNumber2).ToString();
        }
    }


    public void Button(string value)
    {
       var Checker = (UserEnterFiled.text += value.ToString());
          
        if (Checker.Length == Ans.Length)
        {
            if (Checker == Ans)
            {
                RandomNumberGenerater();
                StartCoroutine(ResertInputField1());

            }
            else
            {
                RightOrWrong.text = " Please Enter Correct Ans";
                RightOrWrong.color = Color.red;
                animator.SetTrigger("Ans");
                StartCoroutine(ResertInputField());

            }
            
                
        }

    }


    IEnumerator ResertInputField()
    {
        yield return new WaitForSeconds(1.5f);
        UserEnterFiled.text = "";

    }
    IEnumerator ResertInputField1()
    {
        yield return new WaitForSeconds(.5f);
        UserEnterFiled.text = "";

    }

    public void OnReset()
    {
        UserEnterFiled.text = "";
        RandomNumberGenerater();

    }



}
