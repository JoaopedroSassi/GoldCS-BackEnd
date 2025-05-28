using GoldCS.Domain.Interfaces;
using GoldCS.Domain.Models;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GoldCS.Domain.Services
{
    public class CreateUserService : BaseValidationService<IdentityResult, CreateUserRequest>, ICreateUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;

        public CreateUserService(UserManager<ApplicationUser> userManager, 
            INotificationService notificationService,
            IUserRepository userRepository) : base(notificationService) 
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public override async Task<IdentityResult> Process(CreateUserRequest request)
        {
            if(!await ExecuteValidationsAsync(new CreateUserValidations(), request))
            {
                return null;
            }

            var userIdentity = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                EmailConfirmed = true
            };

            var resultIdentity = await _userManager.CreateAsync(userIdentity, request.Password);

            if (!resultIdentity.Succeeded)
            {
                foreach (var item in resultIdentity.Errors)
                {
                    AddMessage($"{item.Code} - {item.Description}");
                }

                return resultIdentity;
            }

            _userRepository.Detached(userIdentity);
            
            return resultIdentity;
        }
    }
}
