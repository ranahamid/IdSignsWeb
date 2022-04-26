using Autofac;
using FluentValidation;
using System;

namespace Web.Extends.DI
{
    /// <summary>
    /// 
    /// </summary>
    public class AutofacValidatorFactory : ValidatorFactoryBase
    {
        private readonly IComponentContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AutofacValidatorFactory(IComponentContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validatorType"></param>
        /// <returns></returns>
        public override IValidator CreateInstance(Type validatorType)
        {
            if (_context.TryResolve(validatorType, out object instance))
            {
                var validator = instance as IValidator;
                return validator;
            }

            return null;
        }
    }
}