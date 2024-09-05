using FluentValidation;

namespace FluentValidationAPIDemo.Models
{
    public class TaskItem
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool RemindMe { get; set; }
        public int? RemindMinutesBeforeDue { get; set; }
        public List<string> SubItems { get; set;}
    }
    public class TaskItemValidator : AbstractValidator<TaskItem>
    {
        public TaskItemValidator() 
        {
            RuleFor(t => t.Description).NotEmpty();
            RuleFor(t => t.DueDate).
                GreaterThanOrEqualTo(DateTime.Today).
                WithMessage("Due Date must be in the future");
            When(t => t.RemindMe == true, () =>
            {
                RuleFor(t => t.RemindMinutesBeforeDue)
                .NotNull()
                .WithMessage("RemindMinutesBeforeDue must be set")
                .GreaterThan(0)
                .WithMessage("RemindMinutesBeforeDue must be greater than 0")
                .Must(value => value % 15 == 0)
                .WithMessage("RemindMinutesBeforeDue must be multiple of 15");
            });

            RuleForEach(t => t.SubItems)
                .NotEmpty()
                .WithMessage("Value not be Empty");
        }
    }
}
