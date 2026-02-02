using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Ui.Validators;


public static class ValidationFilter
{
    public static RouteHandlerBuilder AddFluentValidation(this RouteHandlerBuilder builder)
    {
        return builder.AddEndpointFilter(async (context, next) =>
        {
            // اسکن کردن تمام آرگومان‌های متد ورودی
            foreach (var argument in context.Arguments)
            {
                if (argument is null) continue;

                // پیدا کردن ولیدیتور برای تایپ این آرگومان از طریق DI
                var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
                var validator = context.HttpContext.RequestServices.GetService(validatorType) as IValidator;

                if (validator is not null)
                {
                    // اجرای ولیدیشن
                    var validationContext = new ValidationContext<object>(argument);
                    var results = await validator.ValidateAsync(validationContext);

                    if (!results.IsValid)
                    {
                        return Results.ValidationProblem(results.ToDictionary());
                    }
                }
            }

            return await next(context);
        });
    }
}