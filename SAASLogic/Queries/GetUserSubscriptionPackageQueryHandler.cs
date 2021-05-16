using AS.eJP.Data;
using AS.eJP.Domain;
using MediatR;
using SAASDomain.Entities;
using SAASPersistence.DataContracts;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace SAASLogic.Queries
{
    public class GetUserSubscriptionPackageQueryHandler : IRequestHandler<GetUserSubscriptionPackageQuery, RequestResult<RecommendedSubscription>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetUserSubscriptionPackageQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<RequestResult<RecommendedSubscription>> Handle(GetUserSubscriptionPackageQuery request, CancellationToken cancellationToken)
        {
            var user = this.unitOfWork.Repository<User>().FindByInclude(x => x.Id == request.UserCode, x=> x.Country.Region).FirstOrDefault();
           

            if (user == null)
            {
                return Task.FromResult(new RequestResult<RecommendedSubscription>
                {
                    IsSuccess = false,
                    Message = "User does not exist"
                });
            }
            var region = user.Country.Region;

            var subscriptionPackage = this.unitOfWork.Repository<SubscriptionPackage>().FindBy(x => x.GeographicalZoneId == region.GeographicalZoneId).FirstOrDefault();
            if (subscriptionPackage == null)
            {
                return Task.FromResult(new RequestResult<RecommendedSubscription>
                {
                    IsSuccess = false,
                    Message = "Subscription for the given user does not exist"
                });
            }

            var result = new RecommendedSubscription();

            result.Id = subscriptionPackage.Id;
            result.Name = subscriptionPackage.Name;
            result.MonthlyPrice = subscriptionPackage.MonthlyPrice;
            result.YearlyPrice = subscriptionPackage.YearlyPrice;
            result.MonthlyPriceWithVat = (decimal)System.Math.Round((region.Vat / 100 * subscriptionPackage.MonthlyPrice) + subscriptionPackage.MonthlyPrice, 2);
            result.YearlyPriceWithVat = (decimal)System.Math.Round((region.Vat / 100 * subscriptionPackage.YearlyPrice) + subscriptionPackage.YearlyPrice, 2);

            return Task.FromResult(new RequestResult<RecommendedSubscription>
            {
                IsSuccess = true,
                Payload = result
            });
        }

    }
}
