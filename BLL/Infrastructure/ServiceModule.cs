﻿using Data.Interfaces;
using Data.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    //public class ServiceModule : NinjectModule
    //{
    //    private string connectionString;

    //    public ServiceModule(string connection)
    //    {
    //        connectionString = connection;
    //    }
    //    public override void Load()
    //    {
    //        Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
    //    }
    //}
}
