using FluentValidation.TestHelper;
using SAASLogic.Queries;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SAASTests.Logic.Queries
{
    [TraitAttribute("GetUserSubscriptionPackageQueryValidatorTests", "Validation Tests for Get Subscription Package Endpoint")]
    public class GetUserSubscriptionPackageQueryValidatorTests
    {
        private readonly GetUserSubscriptionPackageQueryValidator handlerValidator;

        public GetUserSubscriptionPackageQueryValidatorTests()
        {
            handlerValidator = new GetUserSubscriptionPackageQueryValidator();
        }

        [Fact(DisplayName = "user code input validation")]
        public async Task Return_Validation_Error_If_User_Code_Is_Not_Valid()
        {
            var query = new GetUserSubscriptionPackageQuery() {  };

            var result = await handlerValidator.TestValidateAsync(query);

            result.ShouldHaveValidationErrorFor(x => x.UserCode)
                .WithErrorMessage("UserCode cannot be null");
        }
        [Fact(DisplayName = "user code input validation")]
        public async Task Validation_Pass_If_User_Code_Is_Valid()
        {
            var query = new GetUserSubscriptionPackageQuery() { UserCode = new Guid("d194bda8-1ef1-4c7b-bfff-18bb30fd5eec") };

            var result = await handlerValidator.TestValidateAsync(query);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
