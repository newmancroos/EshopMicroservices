using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System.ComponentModel.Design;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

internal class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(p => p.Id)
            .NotNull()
            .WithMessage("{PropertyName} is required");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

        RuleFor(p => p.DefaultDays)
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1")
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100");

        RuleFor(q => q)
            .MustAsync(LeaveTypeMustExist)
            .WithMessage("Leave type already exists");


        _leaveTypeRepository = leaveTypeRepository;
    }

    private async Task<bool> LeaveTypeMustExist(UpdateLeaveTypeCommand commond, CancellationToken arg2)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(commond.Id);
        return leaveType != null;
    }

    //private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
    //{
    //    return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    //}
}