using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Queries
{
    public class GetAsteroidsQueryValidator : AbstractValidator<GetAsteroidsQuery>
    {
        public GetAsteroidsQueryValidator()
        {
            RuleFor(v => v.Specification)
                .Must(s=>
                {
                    int currentYear = DateTime.UtcNow.Year;

                    return (s.FilterMaxYear.HasValue == false || s.FilterMaxYear < currentYear)
                        && (s.FilterMinYear.HasValue == false || s.FilterMinYear < currentYear);
                })
                .WithErrorCode("The selected year is greater than the current year.");
        }
    }
}
