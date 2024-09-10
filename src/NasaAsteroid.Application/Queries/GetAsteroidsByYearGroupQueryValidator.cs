using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Queries
{
    public class GetAsteroidsByYearGroupQueryValidator : AbstractValidator<GetAsteroidsByYearGroupQuery>
    {
        public GetAsteroidsByYearGroupQueryValidator()
        {
            RuleFor(v => v.Specification)
                .Must(s =>
                {
                    int currentYear = DateTime.UtcNow.Year;

                    return (s.FilterMaxYear.HasValue == false || s.FilterMaxYear < currentYear)
                        && (s.FilterMinYear.HasValue == false || s.FilterMinYear < currentYear);
                })
                .WithMessage("The selected year is greater than the current year.");
        }
    }
}
