﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WFCLogicaCoches.Models;

namespace WFCLogicaCoches
{
    [ServiceContract]
    public interface ICochesContract
    {
        [OperationContract]
        List<Coche> GetCoches();
        [OperationContract]
        Coche FindCoche(int idcoche);
    }
}
