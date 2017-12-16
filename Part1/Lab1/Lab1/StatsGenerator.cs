using System;
namespace Lab1
{
    public interface StatsGenerator
    {
        int getWordCount(); // – gets the total number of words 
        int getCharacterCount(); // –gets the total number of chracters 
        int getLineCount(); // – gets the number of lines 
        string getFirstLetter(); // – gets the first letter of every word 
        string getFirstWord(); // – gets the first word of every line 
        string getEndLine(); // – gets the last character of every line
    }
}
