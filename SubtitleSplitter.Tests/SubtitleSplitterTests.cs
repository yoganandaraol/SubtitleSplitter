using System;
using NUnit.Framework;
using SubtitleSplitterManager;
using Moq;
using System.Collections.Generic;

namespace SubtitleSplitter.Tests
{
    [TestFixture]
    public class SubtitleSplitterNTests
    {
        private StringManipulations _objStringManipulations;

        [SetUp]
        public void TestSetup()
        {
            _objStringManipulations = new StringManipulations();
        }

        [TearDown]
        public void TestTearDown()
        {
            _objStringManipulations = null;
        }

        /*
         *  
            1. The given long text is to be broken into smaller parts.

            2. Each part should have a maximum length of 25 characters.

            3. If a comma or a sentence break occurs within 5 characters of the max line length, the line should be broken early.

            4. The exception to the rule #3 is when the next line will only contain 5 (or less) characters.

            5. Redundant whitespace (i.e. double whitespace - " ") should not be counted between lines and any duplicate spaces should be removed.
         * 
         */

      /// <summary>
      /// 
      /// </summary>
      /// <param name="paramTestInputString"></param>
      /// <param name="paramTestExpectedResult"></param>


        [TestCase("This is test   example to          check the      unwanted spaces are trimmed or not..!", "This is test example to check the unwanted spaces are trimmed or not..!")]
        [TestCase("This is test   example to   check the      unwanted spaces are trimmed or not..!          ", "This is test example to check the unwanted spaces are trimmed or not..!")]
        [TestCase("  This is test   example to          check the      unwanted spaces are trimmed or not..!          ", "This is test example to check the unwanted spaces are trimmed or not..!")]
        public void Returns_Beutified_String_From_Text(string paramTestInputString, string paramTestExpectedResult)
        {
            Assert.That(_objStringManipulations.Beautify(paramTestInputString), Is.EqualTo(paramTestExpectedResult));
        }

        [TestCase("This is test   example to          check the                                unwanted spaces are trimmed or not..!", 3)]
        [TestCase("This is test   example to          check the unwanted spaces are trimmed or not..!", 3)]
        [TestCase("             This is test   example to          check the                                unwanted spaces are trimmed or not..!", 3)]
        public void Return_StringList_From_ApplyStringSplitRules(string paramInputString, int paramLineCount)
        {
            List<string> lstSplittedStrings = _objStringManipulations.ApplyStringSplitRules(paramInputString);
            Assert.AreEqual(lstSplittedStrings.Count, paramLineCount);
        }

        [TestCase("This is test example to.", 1)]
        [TestCase("This is test example. to", 1)]
        [TestCase("Please write a program that breaks this text into small chucks. Each chunk should have a maximum length of 25 ", 5)]
        public void Return_SplitRuleCount_From_ApplyStringSplitRules(string paramInputString, int paramLineCount)
        {
            
            List<string> lstSplittedStrings = _objStringManipulations.ApplyStringSplitRules(paramInputString);
            Assert.AreEqual(lstSplittedStrings.Count, paramLineCount);
        }

        [TestCase("Please write a program that breaks this text into small chucks. Each chunk should have a maximum length of 25 ", "Please write a program")]
        public void Return_SplitRuleFirstItem_From_ApplyStringSplitRules(string paramInputString, string paramFirstLineItem)
        {
            
            List<string> lstSplittedStrings = _objStringManipulations.ApplyStringSplitRules(paramInputString);
            Assert.AreEqual(lstSplittedStrings[0], paramFirstLineItem);
        }

        [TestCase("Please write a program that breaks this text into small chucks. Each chunk should have a maximum length of 25 ", "that breaks this text")]
        public void Return_SplitRuleSecondItem_From_ApplyStringSplitRules(string paramInputString, string paramFirstLineItem)
        {
            
            List<string> lstSplittedStrings = _objStringManipulations.ApplyStringSplitRules(paramInputString);
            Assert.AreEqual(lstSplittedStrings[1], paramFirstLineItem);
        }

        [TestCase("Please write a program that breaks this text into small chucks. Each chunk should have a maximum length of 25 ", "into small chucks.")]
        public void Return_SplitRuleThirdItem_From_ApplyStringSplitRules(string paramInputString, string paramFirstLineItem)
        {
            
            List<string> lstSplittedStrings = _objStringManipulations.ApplyStringSplitRules(paramInputString);
            Assert.AreEqual(lstSplittedStrings[2], paramFirstLineItem);
        }

        [TestCase("Please write a program that breaks this text into small chucks. Each chunk should have a maximum length of 25 ", "Each chunk should have a")]
        public void Return_SplitRuleFourthItem_From_ApplyStringSplitRules(string paramInputString, string paramFirstLineItem)
        {
            
            List<string> lstSplittedStrings = _objStringManipulations.ApplyStringSplitRules(paramInputString);
            Assert.AreEqual(lstSplittedStrings[3], paramFirstLineItem);
        }

        [TestCase("Please write a program that breaks this text into small chucks. Each chunk should have a maximum length of 25 ", "maximum length of 25")]
        public void Return_SplitRuleFifthItem_From_ApplyStringSplitRules(string paramInputString, string paramFirstLineItem)
        {
            
            List<string> lstSplittedStrings = _objStringManipulations.ApplyStringSplitRules(paramInputString);
            Assert.AreEqual(lstSplittedStrings[4], paramFirstLineItem);
        }

    }
}
