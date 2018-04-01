using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SubtitleSplitterManager
{
    public class StringManipulations : IStringSplitRules, IBeautifier
    {
        public string Beautify(string paramInputString)
        {
            try
            {
                string spacePattern = "\\s+";
                string replacementText = " ";
                Regex regularExpressoinForSpaces = new Regex(spacePattern);
                string beautifiedString = regularExpressoinForSpaces.Replace(paramInputString, replacementText);
                beautifiedString = beautifiedString.Trim();
                return beautifiedString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> ApplyStringSplitRules(string paramCleancedString)
        {
            try
            {
                StringBuilder sb = new StringBuilder(paramCleancedString);
                string[] arraySplittedStrings = paramCleancedString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> lstSplittedStrings = new List<string>();

                // Split the Text
                int maxNumberOfCharsInALine = 25;
                int minNumberOfCharsToEscapeToNewLine = 5;
                int minNumberOfCharsToEscapeException = 5;

                // 
                string lineItem = string.Empty;
                for (int i = 0; i < arraySplittedStrings.Length; i++)
                {
                    string currentItem = arraySplittedStrings[i];
                    string prevItem = string.Empty;
                    if (i > 0)
                        prevItem = arraySplittedStrings[i - 1];

                    if (lineItem.Length < maxNumberOfCharsInALine && lineItem.Length + currentItem.Length <= maxNumberOfCharsInALine)
                    {
                        lineItem += currentItem + " ";
                    }
                    else
                    {
                        int index = -1;
                        lineItem = lineItem.TrimEnd();
                        if (lineItem.Contains(",") && lineItem.Contains("."))
                            index = Math.Max(lineItem.IndexOf(','), lineItem.IndexOf('.'));
                        else if (lineItem.Contains(","))
                            index = lineItem.IndexOf(',');
                        else if (lineItem.Contains("."))
                            index = lineItem.IndexOf('.');

                        if (index > 0)
                        {
                            if (index + 1 > (maxNumberOfCharsInALine - minNumberOfCharsToEscapeToNewLine))
                            {
                                string newLineItem = lineItem.Substring(index + 1).Trim();
                                if (newLineItem.Length > minNumberOfCharsToEscapeException)
                                    lstSplittedStrings.Add(lineItem.Trim());
                                else
                                {
                                    lstSplittedStrings.Add(lineItem.Substring(0, (lineItem.Length - newLineItem.Length)));
                                    lineItem = newLineItem + " ";
                                }
                            }
                            else
                            {
                                string newLineItem = lineItem.Substring(index + 1).Trim();
                                if (newLineItem.Length <= minNumberOfCharsToEscapeException)
                                {
                                    lstSplittedStrings.Add(lineItem.Substring(0, (lineItem.Length - newLineItem.Length)).Trim());
                                    lineItem = String.Format("{0} {1} ", newLineItem, currentItem);
                                }
                                else
                                {
                                    lstSplittedStrings.Add(lineItem.Trim());
                                    lineItem = currentItem + " ";
                                }

                            }
                        }
                        else
                        {
                            lstSplittedStrings.Add(lineItem.Trim());
                            lineItem = currentItem + " ";
                        }

                    }

                    if (i == arraySplittedStrings.Length - 1)
                    {
                        if (!String.IsNullOrEmpty(lineItem.Trim()))
                        {
                            lstSplittedStrings.Add(lineItem.Trim());
                        }

                    }

                }
                return lstSplittedStrings;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
