﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Providers.Delegates
{
    public class DelegateConversionRule
    {
        private readonly Predicate<ParameterInfo> _canHandle;
        private readonly Func<ParameterInfo, ParameterConversion> _handle;

        public DelegateConversionRule(Predicate<ParameterInfo> canHandle, Func<ParameterInfo, ParameterConversion> handle)
        {
            if (canHandle == null)
            {
                throw new ArgumentNullException(nameof(canHandle));
            }

            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            _canHandle = canHandle;
            _handle = handle;
        }
        public bool CanHandle(ParameterInfo parameterInfo)
        {
            return _canHandle(parameterInfo);
        }
        public ParameterConversion Handle(ParameterInfo parameterInfo)
        {
            return _handle(parameterInfo);
        }
    }
}
