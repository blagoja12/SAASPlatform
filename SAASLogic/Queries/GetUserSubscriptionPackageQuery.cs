using AS.eJP.Domain;
using MediatR;
using SAASPersistence.DataContracts;
using System;

namespace SAASLogic.Queries
{
    public class GetUserSubscriptionPackageQuery : IRequest<RequestResult<RecommendedSubscription>>
    {
        public Guid UserCode { get; set; }
    }
}
