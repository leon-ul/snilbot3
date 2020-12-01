using SnilBot.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnilBot.Shared.models
{
    public class Cell
    {
        public ObjectMap typeObject;

        public Cell(ObjectMap inputObject)
        {
            typeObject = inputObject;
        }

    }
}
