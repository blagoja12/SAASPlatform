using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAASLogic.Queries
{
    public class GetUserSubscriptionPackageQueryValidator : AbstractValidator<GetUserSubscriptionPackageQuery>
    {
        public GetUserSubscriptionPackageQueryValidator()
        {
            this.RuleFor(x => x.UserCode)
               .NotNull()
               .NotEmpty()
               .WithMessage("UserCode cannot be null");
        }
    }
}
