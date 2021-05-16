using AS.eJP.Data;
using Moq;
using SAASDomain.Entities;
using SAASLogic.Queries;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SAASTests.Logic.Queries
{
    [TraitAttribute("GetUserSubscriptionPackageQueryHandler", "Handler Tests for Get Subscription Package Endpoint")]
    public class GetSubscriptionPackageQueryTest
    {
        private readonly Mock<IUnitOfWork> unitOfWork;
        private readonly GetUserSubscriptionPackageQueryHandler getUserSubscriptionPackageQueryHandler;

        public GetSubscriptionPackageQueryTest()
        {
            unitOfWork = new Mock<IUnitOfWork>();
            getUserSubscriptionPackageQueryHandler = new GetUserSubscriptionPackageQueryHandler(unitOfWork.Object);
        }

        [Fact(DisplayName = "Return EU Subscription Package")]
        public async Task Should_Return_EU_SubscriptionPackage()
        {
            // arrange
            var query = new GetUserSubscriptionPackageQuery() { UserCode = new Guid("d194bda8-1ef1-4c7b-bfff-18bb30fd5eec") };
            unitOfWork.Setup(x => x.Repository<User>().FindByInclude(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<Expression<Func<User, object>>[]>())).Returns(TestSetup.GetEuUserMockData());

            unitOfWork.Setup(x => x.Repository<SubscriptionPackage>().FindBy(It.IsAny<Expression<Func<SubscriptionPackage, bool>>>())).Returns(TestSetup.GetEuSubscriptionPackageMockData());

            // act
            var result = getUserSubscriptionPackageQueryHandler.Handle(query, CancellationToken.None).Result;

            // assert
            Assert.True(result.IsSuccess);
            Assert.Equal("EU package", result.Payload.Name);
            Assert.Equal(10000, result.Payload.YearlyPrice);
            Assert.Equal(100, result.Payload.MonthlyPrice);
            Assert.Equal(11800, result.Payload.YearlyPriceWithVat);
            Assert.Equal(118, result.Payload.MonthlyPriceWithVat);

        }

        [Fact(DisplayName = "Return Enterprise Subscription Package")]
        public async Task Should_Return_Enterprise_SubscriptionPackage()
        {
            // arrange
            var query = new GetUserSubscriptionPackageQuery() { UserCode = new Guid("d194bda8-1ef1-4c7b-bfff-18bb30fd5eec") };
            unitOfWork.Setup(x => x.Repository<User>().FindByInclude(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<Expression<Func<User, object>>[]>())).Returns(TestSetup.GetUSAUserMockData());

            unitOfWork.Setup(x => x.Repository<SubscriptionPackage>().FindBy(It.IsAny<Expression<Func<SubscriptionPackage, bool>>>())).Returns(TestSetup.GetUASSubscriptionPackageMockData());

            // act
            var result = getUserSubscriptionPackageQueryHandler.Handle(query, CancellationToken.None).Result;

            // assert
            Assert.True(result.IsSuccess);
            Assert.Equal("Enterprise package", result.Payload.Name);
            Assert.Equal(13000, result.Payload.YearlyPrice);
            Assert.Equal(130, result.Payload.MonthlyPrice);
            Assert.Equal(13000, result.Payload.YearlyPriceWithVat);
            Assert.Equal(130, result.Payload.MonthlyPriceWithVat);

        }

        [Fact(DisplayName = "Return message user does not exists")]
        public async Task Should_Return_Massage_User_Does_Not_Exist()
        {
            // arrange
            var query = new GetUserSubscriptionPackageQuery() { UserCode = new Guid("d194bda8-1ef1-4c7b-bfff-18bb30fd5eec") };
            unitOfWork.Setup(x => x.Repository<User>().FindByInclude(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<Expression<Func<User, object>>[]>())).Returns(new List<User> { });

            unitOfWork.Setup(x => x.Repository<SubscriptionPackage>().FindBy(It.IsAny<Expression<Func<SubscriptionPackage, bool>>>())).Returns(new List<SubscriptionPackage> { });

            // act
            var result = getUserSubscriptionPackageQueryHandler.Handle(query, CancellationToken.None).Result;

            // assert
            Assert.False(result.IsSuccess);
            Assert.Equal("User does not exist", result.Message);
        }

        [Fact(DisplayName = "Returs Message Subscription for the given user does not exist")]
        public async Task Should_Return_IsSucces_False_With_Message_For_Sub_null()
        {
            // arrange
            var query = new GetUserSubscriptionPackageQuery() { UserCode = new Guid("d194bda8-1ef1-4c7b-bfff-18bb30fd5eec") };
            unitOfWork.Setup(x => x.Repository<User>().FindByInclude(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<Expression<Func<User, object>>[]>())).Returns(TestSetup.GetUSAUserMockData());

            unitOfWork.Setup(x => x.Repository<SubscriptionPackage>().FindBy(It.IsAny<Expression<Func<SubscriptionPackage, bool>>>())).Returns(new List<SubscriptionPackage> { });

            // act
            var result = getUserSubscriptionPackageQueryHandler.Handle(query, CancellationToken.None).Result;

            // assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Subscription for the given user does not exist", result.Message);
        }

    }
}
