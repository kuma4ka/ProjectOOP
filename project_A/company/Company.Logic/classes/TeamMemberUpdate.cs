using Company.Logic.classes;

public class TeamMemberUpdate : EventArgs
{
    public Employee UpdatedMember { get; }

    public TeamMemberUpdate(Employee updatedMember)
    {
        UpdatedMember = updatedMember;
    }
}