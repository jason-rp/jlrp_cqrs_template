using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JLRP.Data.IRepositories;
using JLRP.Domain.Dtos;
using JLRP.Domain.Queries;
using MediatR;

namespace JLRP.Service.Services
{
    public class GetUserHandler : IRequestHandler<GetUserQuery,UserDto>, IRequest<UserDto>
    {
        private IUserRepository _userRepository;
        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAsync(n => n.Id == request.UserId);

            return null;
        }
    }
}
