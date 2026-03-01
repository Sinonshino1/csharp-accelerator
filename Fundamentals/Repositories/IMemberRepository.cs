using GymMemberManager.Models;

using GymMemberManager.Repositories;

public interface IMemberRepository
{
    IReadOnlyList<Member> Load();
    void Save(IReadOnlyList<Member> members);
}