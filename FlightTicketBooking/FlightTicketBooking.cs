namespace FlightTicketBooking
{
    class FlightTicketBooking
    {
        static void Main()
        {
            FlightAdmin flightAdmin = new FlightAdmin();
            System.Console.WriteLine("\t\t\tWelcome to Flight Ticket Booking");
            FlightAdmin.flightCollection.ViewAvailableFlightDetails();
            flightAdmin.GetUserRole();
        }
    }
}
