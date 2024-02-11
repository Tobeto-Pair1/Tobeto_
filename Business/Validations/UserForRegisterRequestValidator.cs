using Business.DTOs.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;

public class UserForRegisterRequestValidator : AbstractValidator<UserForRegisterRequest>
{

    public UserForRegisterRequestValidator()
    {
        RuleFor(u => u.Email).NotEmpty();
        RuleFor(u => u.Email).EmailAddress();
        //RuleFor(u => u.Email).u
        //RuleFor(u => u.Email).MustAsync(BeUnique);
        RuleFor(u => u.Password).NotEmpty();
        RuleFor(u => u.PhoneNumber).Length(11);

    }
    //private async Task<bool> BeUnique(int id)
    //{
    //    // Burada, veritabanında Id'nin benzersiz olup olmadığını kontrol edebilirsiniz
    //    // Örneğin, Entity Framework kullanıyorsanız, bu id ile başka bir kayıt var mı diye sorgu yapabilirsiniz
    //    // Veya daha karmaşık senaryolarda, bir servisi çağırarak kontrol edebilirsiniz

    //    // Örnek olarak, bir Entity Framework DbContext'i kullanılarak kontrol edilmesi:
    //    using (var dbContext = new YourDbContext())
    //    {
    //        return !dbContext.Blogs.Any(b => b.Id == id);
    //    }
    //}
}
