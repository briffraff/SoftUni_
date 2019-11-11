﻿using System;
using System.Collections.Generic;
using System.Text;
using BillsPaymentSystem.Data;

namespace BillsPaymentSystem.App.Core.Contracts
{
    public interface ICommandInterpreteur
    {
        string Read(string[] args,BillsPaymentSystemContext context);
    }
}
