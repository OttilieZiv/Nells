using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NailSalon
{
   public static class StashEvents
    {
        public delegate void CancelHandler();

        public delegate void ManiEventHandler(Models.Manicure mani);
    }
}
