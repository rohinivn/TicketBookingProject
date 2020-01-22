namespace FlightTicketBooking
{
    public enum UserType
    {
        Admin=1,
        User=2
    }

    public enum AdminChoice
    {
        AddingFlightDetails=1,
        DisplayingFlightDetails,
        DeletingFlightDetails,
        UpdatingFlightDetails,
        ViewPassengerDetails,
    }
    public enum UserChoice
    {
        DisplayAvailableFlights=1,
        BookTicket,
        UpdatingPassengerDetails,
        CancelingTicket,
        PreviewDetails,
        DeletePassengerDetails,
        SearchingFlightsByLocation
    }

    public enum RepeatCheck
    {
        No,
        Yes
    }
    public enum UpdateFlightChoice
    {
        FlightName=1,
        StartLocation,
        TargetLocation,
        AvailableTickets,
        TicketPrice
    }
    public enum UpdatePassengerChoice
    {
        PassengerName=1,
        Age,
        Gender,
        Password,
        PhoneNumber,
        EmailId
    }

    public enum SeatType
    {
        FirstClass=1,
        BusinessClass,
        Economy
    }
}
