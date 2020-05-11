using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SSar.BC.MemberMgmt.Application.Members.Commands.UpdateMemberCommand
{
    public class UpdateMemberCommandValidator : AbstractValidator<UpdateMemberCommand>
    {
        public UpdateMemberCommandValidator()
        {
            RuleFor(r => r.FirstName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(r => r.MiddleName)
                .MaximumLength(50);

            RuleFor(r => r.LastName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(r => r.Nickname)
                .MaximumLength(50);
        }
    }
}
