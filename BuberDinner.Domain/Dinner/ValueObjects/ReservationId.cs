using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public sealed class ReservationId : ValueObject
{
    public string Value { get; }

    private ReservationId(DinnerId dinnerId, GuestId guestId)
    {
        Value = $"Reservation_{dinnerId.Value}_{guestId.Value}";
    }

    private ReservationId(string value)
    {
        Value = value;
    }

    public static ReservationId Create(DinnerId dinnerId, GuestId guestId)
    {
        return new ReservationId(dinnerId, guestId);
    }

    public static ReservationId Create(string value)
    {
        return new ReservationId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}