namespace FlightTicketBooking
{
    class Passenger
    {
        public string PassengerName { set; get; }
        public byte Age { set; get; }
        public char Gender { set; get; }
        public string Password { set; get; }
        public string PhoneNo { set; get; }
        public string EmailId { set; get; }

        //Parameterized Constructor
        public Passenger(string name, string email, byte age, char gender,string password,string phoneno)
        {
            PassengerName = name;
            EmailId = email;
            Age = age;
            Gender = gender;
            Password = password;
            PhoneNo = phoneno;
        }
        public Passenger()
        {

        }
    }
}
