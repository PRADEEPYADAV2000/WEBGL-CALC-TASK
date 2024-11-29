using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Calc : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    private string currentExpression = ""; 

    
    public void OnButtonClick(string input)
    {
        if (input == "=")
        {
            CalculateResult(); 
        }
        else if (input == "C")
        {
            ClearLastCharacter(); 
        }
        else if (input == "AC")
        {
            ClearAll(); 
        }
        else
        {
            AddToExpression(input); 
        }

        UpdateDisplay();
    }

   
    private void AddToExpression(string input)
    {
        currentExpression += input;
    }

    
    private void ClearLastCharacter()
    {
        if (currentExpression.Length > 0)
        {
            currentExpression = currentExpression.Substring(0, currentExpression.Length - 1);
        }
    }

    
    private void ClearAll()
    {
        currentExpression = "";
    }

    
    private void UpdateDisplay()
    {
        if (string.IsNullOrEmpty(currentExpression))
        {
            displayText.text = "0"; 
        }
        else
        {
            displayText.text = currentExpression;
        }
    }

   
    private void CalculateResult()
    {
        try
        {
            float result = SolveExpression(currentExpression);
            currentExpression = result.ToString(); 
        }
        catch
        {
            currentExpression = "Error"; 
        }
    }

   
    private float SolveExpression(string expression)
    {
        char[] operators = { '+', '-', '*', '/' }; 
        float result = 0;
        string[] parts;

        
        if (expression.Contains("+"))
        {
            parts = expression.Split('+');
            result = float.Parse(parts[0]) + float.Parse(parts[1]);
        }
        else if (expression.Contains("-"))
        {
            parts = expression.Split('-');
            result = float.Parse(parts[0]) - float.Parse(parts[1]);
        }
        else if (expression.Contains("*"))
        {
            parts = expression.Split('*');
            result = float.Parse(parts[0]) * float.Parse(parts[1]);
        }
        else if (expression.Contains("/"))
        {
            parts = expression.Split('/');
            result = float.Parse(parts[0]) / float.Parse(parts[1]);
        }

        return result;
    }
}
