﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carter.Framework.Data;
using Carter.Framework.Data.DataTransformation;
using Carter.NewHire.Model.Interface;

namespace Carter.NewHire.Repository.Interfaces
{
    public interface IStatusRepository
    {
        IEnumerable<IStatus> GetStatuses();
    }
}
