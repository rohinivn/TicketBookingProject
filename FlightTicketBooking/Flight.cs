namespace FlightTicketBooking
{
    class Flight
    {
        public string FlightName { set; get; }
        public float TicketPrice { set; get; }
        public string StartLocation { set; get; }
        public string TargetLocation { set; get; }
        public byte AvailableTickets { set; get; }


        //Parameterized Constructor
        public Flight(string name, string start, string target, byte availableTickets,float pricePerTicket)
        {
            FlightName = name;
            StartLocation = start;
            TargetLocation = target;
            AvailableTickets = availableTickets;
            TicketPrice = pricePerTicket;
        }
        public Flight()
        {

        }
    }
}
