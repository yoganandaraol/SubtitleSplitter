using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubtitleSplitterManager
{
    public interface IStringSplitRules
    {
        List<string> ApplyStringSplitRules(string paramCleancedString);
    }
}
