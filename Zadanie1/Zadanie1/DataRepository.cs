﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class DataRepository
    {
        private DataContext dataContext;

        public DataRepository(WypelnianieStalymi ws)
        {
            ws.wypelnij(dataContext);
        }
    }
}
