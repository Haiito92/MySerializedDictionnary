using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class ArrayAndStringExercice : MonoBehaviour
{
    #region Ex 1

    [Header("Exercice 1")]
    [SerializeField] private string _myString;
    
    private bool AllUnique(string stringToTest)
    {
        if (stringToTest.Length > 128) return false;

        bool[] characters = new bool[128];
        for (int i = 0; i < stringToTest.Length; i++)
        {
            int charValue = stringToTest[i];
            if (characters[charValue] == true) return false;
            characters[charValue] = true;
        }
        
        return true;
    }

    [Button]
    void AllUnique() => Debug.Log(AllUnique(_myString));
    

    #endregion

    #region Ex 2

    [Header("Exercice 2")]

    [SerializeField] private string _permut1;
    [SerializeField] private string _permut2;

    bool CheckPermutation(string a, string b)
    {
        if(a.Length != b.Length) return false;

        bool[] check = new bool[b.Length];
        int checks = 0;

        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < b.Length; j++)
            {
                if (a[i] != b[j] || check[j]) continue;
                
                check[j] = true;
                checks += 1;
            }
        }
        Debug.Log(checks);
        Debug.Log(a.Length);
        
        return checks == a.Length;
    }

    [Button] private void CheckPermutation() => Debug.Log(CheckPermutation(_permut1, _permut2));

    #endregion

    #region Ex 3

    [Header("Exercice 3")] 
    [SerializeField] private string _URLifyString;
    [SerializeField] private int _trueLength;
    
    string URLify(string s, int trueLength)
    {
        char[] sArray = s.ToCharArray();
        
        int numberOfSpaces = CountCharacter(s, 0, trueLength, ' ');
        int newIndex = trueLength - 1 + numberOfSpaces * 2;

        for (int oldIndex = trueLength - 1; oldIndex >= 0; oldIndex--)
        {
            if (sArray[oldIndex] == ' ')
            {
                sArray[newIndex] = '0';
                sArray[newIndex - 1] = '2';
                sArray[newIndex - 2] = '%';
                newIndex -= 3;
            }
            else
            {
                sArray[newIndex] = sArray[oldIndex];
                newIndex -= 1;
            }
        }

        StringBuilder outString = new StringBuilder();

        foreach (char c in sArray)
        {
            outString.Append(c);
        }

        return outString.ToString();
    }

    int CountCharacter(string s, int start, int end, int target)
    {
        int count = 0;   
        for (int i = start; i < end; i++)
        {
            if (s[i] == target) count++;
        }
        
        return count;
    }
    
    [Button] private void UURLify() => Debug.Log(URLify(_URLifyString, _trueLength));
    #endregion
    
    #region Ex 4

    [Header("Exercice 4")]
    [SerializeField] private string _palindromeA;
    [SerializeField] private string _palindromeB;

    bool PalindromePermutation(string a, string b)
    {
        if(!IsPalindrome(a) || !IsPalindrome(b)) return false;

        string sortedA = SortString(a);
        string sortedB = SortString(b);

        if (sortedA == sortedB) return true;
        else return false;
    }

    bool IsPalindrome(string s)
    {
        for (int i = 0; i <= s.Length/2; i++)
        {
            if (s[i] != s[s.Length - 1 - i]) return false;
        }

        return true;
    }

    [Button]
    void PalindromePermutation() => Debug.Log(PalindromePermutation(_palindromeA, _palindromeB));
    #endregion

    #region Ex 6

    [Header("Exercice 6")]
    [SerializeField] private string _stringToCompress;
    
    string StringCompression(string s)
    {
        StringBuilder compressedString = new StringBuilder();
        int c = 0;
        int count = 1;
        
        for (int i = 0; i < s.Length; i++)
        {
            if (i == 0)
            {
                c = s[i];
                compressedString.Append(s[i]);
                continue;
            }

            if (c != s[i])
            {
                compressedString.Append(count);
                c = s[i];
                compressedString.Append(s[i]);
                count = 1;
            }
            else
            {
                count++;
            }
        }

        compressedString.Append(count);

        return compressedString.Length >= s.Length ? s : compressedString.ToString();
    }

    [Button]
    void StringCompression() => Debug.Log(StringCompression(_stringToCompress));
    #endregion

    #region Ex 7

    bool NxNMatrix90degreeRot(int[][] matrix)
    {
        if (matrix.Length == 0 || matrix.Length != matrix[0].Length) return false;
        int n = matrix.Length;

        for (int layer = 0; layer < n / 2; layer++)
        {
            int first = layer;
            int last = n - 1 - layer;
            for (int i = first; i < last; i++)
            {
                int offset = i - first;
                int top = matrix[first][i];
                
                //left to top
                matrix[first][i] = matrix[last - offset][first];
                
                // bottom to left
                matrix[last - offset][first] = matrix[last][last - offset];
                
                //right to bottom
                matrix[last][last - offset] = matrix[i][last];
                
                //top to right
                matrix[i][last] = top;
            }
        }

        return true;
    }

    #endregion
    
    #region Utils

    string SortString(string s)
    {
        char[] sArray = s.ToCharArray();
        Array.Sort(sArray);
        return new string(sArray);
    }
    #endregion
}
