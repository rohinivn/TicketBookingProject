using System;
using System.Collections.Generic;

namespace FlightTicketBooking
{
    class FlightCollection
    {
        internal static Dictionary<int, Flight> flightList = new Dictionary<int, Flight>();
        public static int Id;
        Flight flight = new Flight();
        byte check;
        bool status;
        internal static bool displayFlag;
        static FlightCollection()
        {
            flightList.Add(1, new Flight("King", "Cbe", "Chennai", 70, 1000));
            flightList.Add(2, new Flight("Kingfisher", "Chennai", "cbe", 70, 1400));
            flightList.Add(3, new Flight("Boat", "Cbe", "Chennai", 70, 1020));
            Id = flightList.Count;
        }
        internal void BindingAdminAccessability()
        {
            try
            {
                Console.WriteLine("Select 1 for AddingFlight,2 for DisplayingFlights, 3 for DeletingFlightDetails 4 for UpdatingFlightDetails");
                status = byte.TryParse(Console.ReadLine(), out byte choice);
                if (status)
                {
                    do
                    {
                        switch (choice)
                        {
                            case (byte)(AdminChoice.AddingFlightDetails):
                                FlightAdmin.flightCollection.AddFlightDetails();
                                break;
                            case (byte)(AdminChoice.DisplayingFlightDetails):
                                FlightAdmin.flightCollection.ViewAvailableFlightDetails();
                                displayFlag = true;
                                break;
                            case (byte)(AdminChoice.DeletingFlightDetails):
                                FlightAdmin.flightCollection.RemoveFlightDetails();
                                break;
                            case (byte)(AdminChoice.UpdatingFlightDetails):
                                FlightAdmin.flightCollection.ModifyFlightDetails();
                                break;
                            case (byte)(AdminChoice.ViewPassengerDetails):
                                FlightAdmin.flightCollection.ViewPassengerDetails();
                                break;
                            default:
                                Console.WriteLine("Please enter valid choice!!");
                                break;
                        }
                        Console.WriteLine("Do you want to continue 1 for yes, 0 for no ?? ");
                        check = byte.Parse(Console.ReadLine());
                    } while (check == (byte)RepeatCheck.Yes);
                }
                else
                    Console.WriteLine("Please enter valid number!!");
            }
            catch(FormatException exception)
            {
                Console.WriteLine("Something went wrong",exception.Message);
            }
            catch(Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }
        private void AddFlightDetails()
        {
            try
            {
                Console.Write("Enter Flight Name : ");
                flight.FlightName = Console.ReadLine();
                //string name = passenger.PassengerName;
                while (Validator.UserNameValidator(flight.FlightName))
                {
                    Console.WriteLine("Invalid name");
                    flight.FlightName = Console.ReadLine();
                }

                Console.Write("Enter StartLocation : ");
                flight.StartLocation = Console.ReadLine();
                while (Validator.UserNameValidator(flight.StartLocation))
                {
                    Console.WriteLine("Invalid name");
                    flight.StartLocation = Console.ReadLine();
                }

                Console.Write("Enter TargetLocation : ");
                flight.TargetLocation = Console.ReadLine();
                while (Validator.UserNameValidator(flight.TargetLocation))
                {
                    Console.WriteLine("Invalid name");
                    flight.TargetLocation = Console.ReadLine();
                }

                Console.Write("Enter Total Available Ticket : ");
                status = byte.TryParse(Console.ReadLine(), out byte availableTicket);
                if (status)
                    flight.AvailableTickets = availableTicket;
                else
                {
                    Console.WriteLine("Not an valid!!");
                    flight.AvailableTickets = byte.Parse(Console.ReadLine());
                }

                Console.Write("Enter the Price per Ticket : ");
                status = float.TryParse(Console.ReadLine(), out float price);
                if (status)
                    flight.TicketPrice = price;
                else
                {
                    Console.WriteLine("Not an valid!!");
                    flight.TicketPrice = byte.Parse(Console.ReadLine());
                }


               FlightCollection.flightList.Add(++Id, new Flight(flight.FlightName, flight.StartLocation,flight.TargetLocation,flight.AvailableTickets,flight.TicketPrice));
            }
            catch (FormatException exception)
            {
                Console.WriteLine("Please enter valid Format", exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        internal void ViewAvailableFlightDetails()
        {
            try
            {
                Console.WriteLine("\t\tAvailable Flights");
                foreach (KeyValuePair<int, Flight> keyValuePair in FlightCollection.flightList)
                {
                    Flight flight = keyValuePair.Value;
                    Console.WriteLine("Flight Id : {0} , Flight Name : {1} , StartLocation : {2} , TargetLocation : {3} , Available Tickets : {4} , Ticket Cost : {5}", keyValuePair.Key, flight.FlightName, flight.StartLocation, flight.TargetLocation, flight.AvailableTickets, flight.TicketPrice);
                    displayFlag = true;
                }
            }
            catch(NullReferenceException exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }

        private void RemoveFlightDetails()
        {
            try
            {
                Console.Write("Enter the flight id you want to remove : ");
                status = int.TryParse(Console.ReadLine(), out int index);
                if (status)
                {
                    FlightCollection.flightList.Remove(index);
                }
                else
                    Console.WriteLine("Please enter valid index!!");
            }
            catch(Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }

        private void ModifyFlightDetails()
        {
            try
            {
                Console.Write("Enter the flight id you want to modify : ");
                status = int.TryParse(Console.ReadLine(), out int index);
                if (status)
                {
                    do
                    {
                        Console.WriteLine("Select 1 for FlightName,2 for StartLocation,3 for TargetLocation,4 for AvailableTickets,5 for TicketPrice");
                        status = byte.TryParse(Console.ReadLine(), out byte choice);
                        if (status)
                        {
                            switch (choice)
                            {
                                case (byte)(UpdateFlightChoice.FlightName):
                                    FlightCollection.flightList[index].FlightName = Console.ReadLine();
                                    break;
                                case (byte)(UpdateFlightChoice.StartLocation):
                                    FlightCollection.flightList[index].StartLocation = Console.ReadLine();
                                    break;
                                case (byte)(UpdateFlightChoice.TargetLocation):
                                    FlightCollection.flightList[index].TargetLocation = Console.ReadLine();
                                    break;
                                case (byte)(UpdateFlightChoice.AvailableTickets):
                                    FlightCollection.flightList[index].AvailableTickets = byte.Parse(Console.ReadLine());
                                    break;
                                case (byte)(UpdateFlightChoice.TicketPrice):
                                    FlightCollection.flightList[index].TicketPrice = float.Parse(Console.ReadLine());
                                    break;
                                default:
                                    Console.WriteLine("Please enter valid choice!!");
                                    break;
                            }
                            Console.WriteLine("Do you want to continue 1 for yes, 0 for no ?? ");
                            check = byte.Parse(Console.ReadLine());
                        }
                        else
                            Console.WriteLine("Please enter valid integer!!");
                    } while (check == (byte)RepeatCheck.Yes);
                }
                else
                    Console.WriteLine("Please enter valid index!!");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }

        internal void ViewPassengerDetails()
        {
            try
            {
                foreach (KeyValuePair<int, Passenger> keyValuePair in PassengerCollection.passengerList)
                {
                    Passenger passenger = keyValuePair.Value;
                    Console.WriteLine("Passenger Id : {0} , Passenger Name : {1} , Passenger Age : {2} , Gender : {3} , EmailID : {4} , PhoneNumber: {5}", keyValuePair.Key, passenger.PassengerName, passenger.Age, passenger.Gender, passenger.EmailId, passenger.PhoneNo);
                }
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }
    }
}
