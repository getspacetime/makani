using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makani;
public enum EntryMode
{
    Default,

    /// <summary>
    /// Receive model updates immediately, as the user types.
    /// </summary>
    Immediate,

    /// <summary>
    /// Receive model updates when the input loses focus.
    /// </summary>
    Blur
}