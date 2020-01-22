using System;

namespace FlightTicketBooking
{
    class BookTicket
    {
        Flight flight;
        FlightAdmin flightAdmin = new FlightAdmin();
        byte noOfSeats;
        int flightId;
        static bool bookFlag,cancelFlag;
        internal void TicketReservation()
        {
            if (FlightCollection.displayFlag)
            {
                Console.WriteLine("Enter the Flight Id You Want Book");
                bool status = int.TryParse(Console.ReadLine(), out flightId);
                if (status)
                {
                    Console.WriteLine("Enter no of tickets");
                    status = byte.TryParse(Console.ReadLine(), out noOfSeats);
                    if (status)
                    {
                        if (FlightCollection.flightList.ContainsKey(flightId))
                        {
                            flight = FlightCollection.flightList[flightId];
                            if (FlightAdmin.bookTicket.CheckTicketAvailability())
                            {
                                flight.AvailableTickets -= noOfSeats;
                                Console.WriteLine("Ticket Booked Successfully!!");
                            }
                            else
                                Console.WriteLine("No Tickets Available");
                        }
                        else
                            Console.WriteLine("Please enter valid flight detail");
                    }
                    else
                        Console.WriteLine("Not an valid Integer");
                }
                else
                    Console.WriteLine("Not an valid Integer");
                bookFlag = true;
            }
            else
                Console.WriteLine("Please View the Available Flight Details");
        }
        private bool CheckTicketAvailability()
        {
            if (flight.AvailableTickets > 0 && noOfSeats > 0 && noOfSeats < flight.AvailableTickets)
                return true;
            else
                return false;
        }
        internal void CancelTicket()
        {
            if(bookFlag)
            {
                flight = FlightCollection.flightList[flightId];
                flight.AvailableTickets += noOfSeats;
                cancelFlag = true;
                Console.WriteLine("Ticket Cancelled Successfully");
            }
            else
                Console.WriteLine("Please check have you booked the ticket");
        }
        internal void PreviewTicketDetails()
        {
            if (!cancelFlag)
            {
                flight = FlightCollection.flightList[flightId];
                Console.WriteLine("Flight Id : {0} , Flight Name : {1} , StartLocation : {2} , TargetLocation : {3}", flightId, flight.FlightName, flight.StartLocation, flight.TargetLocation, flight.AvailableTickets, flight.TicketPrice);
                foreach (var passengers in PassengerCollection.passengerList)
                {
                    Passenger user = passengers.Value;
                    if (user.PassengerName.Equals(flightAdmin.Name))
                        Console.WriteLine("PassengerName : {0}", user.PassengerName);
                }
            }
            else
                Console.WriteLine("Your Ticket has been Cancelled!!!");
        }
        internal void SearchByLocation(string sourceLocation,string targetLocation )
        {
            if(FlightCollection.displayFlag)
            {
                foreach(var flights in FlightCollection.flightList)
                {
                    Flight flight = flights.Value;
                    if(flight.StartLocation.Equals(sourceLocation) && flight.TargetLocation.Equals(targetLocation))
                        Console.WriteLine("Flight Id : {0} , Flight Name : {1} , StartLocation : {2} , TargetLocation : {3} , Available Tickets : {4} , Ticket Cost : {5}", flight.FlightName, flight.StartLocation, flight.TargetLocation, flight.AvailableTickets, flight.TicketPrice);
                }
            }
        }
    }
}
