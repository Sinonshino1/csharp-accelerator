using GymMemberManager.Models;
using GymMemberManager.Repositories;

namespace GymMemberManager.Tests;

public sealed class InMemoryMemberRepository : IMemberRepository
{
    private List<Member> _store = new();

    public IReadOnlyList<Member> Load() => _store;

    public void Save(IReadOnlyList<Member> members)
    {
        _store = members.ToList();
    }
}