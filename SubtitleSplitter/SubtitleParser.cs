using SubtitleSplitterManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace SubtitleSplitter
{
    public class SubtitleParser
    {
        public string Parse(string input)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(input))
                {
                    throw new Exception("Invalid input or input is missing");
                }

                StringManipulations objStringManipulations = new StringManipulations();
                List<string> lstSplitStrings = objStringManipulations.ApplyStringSplitRules(input);

                foreach (string splitItem in lstSplitStrings)
                {
                    sb.AppendFormat("{0}{1}", splitItem, Environment.NewLine);
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }

    
}
