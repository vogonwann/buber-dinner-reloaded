using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate;

public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();

    public string FirstName { get; }
    public string LastName { get; }
    public Uri ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        Uri profileImage,
        UserId userId,
        AverageRating averageRating)
        : base(hostId ?? HostId.Create(userId))
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        AverageRating = averageRating;
    }

    public static Host Create(
        string firstName,
        string lastName,
        Uri profileImage,
        UserId userId)
    {
        // TODO: enforce invariants
        return new Host(
            HostId.Create(userId),
            firstName,
            lastName,
            profileImage,
            userId,
            AverageRating.CreateNew());
    }
}