using CustomMediator.Library.Abstractions;

namespace CustomMediator.Api.Example;

public class GetUserByIdQuery : IRequest<UserViewModel>
{
    public GetUserByIdQuery(int id)
    {
        Id = id;
    }

    public GetUserByIdQuery()
    {
        
    }

    public int Id { get; set; }
}

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
{
    public Task<UserViewModel> Handle(GetUserByIdQuery request)
    {
        return Task.FromResult(new UserViewModel(
                )
            {
                FirstName = "first"
            }
        );
    }
}