using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Hababk.BuildingBlocks.Application;

    public abstract class CustomAbstractValidator<T> :AbstractValidator<T> where T:class
    {
        
    }
