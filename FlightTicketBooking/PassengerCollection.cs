using System;
using System.Collections.Generic;

namespace FlightTicketBooking
{
    class PassengerCollection
    {
        internal static Dictionary<int, Passenger> passengerList = new Dictionary<int, Passenger>();
        bool status;
        byte check;

        static PassengerCollection()
        {
            passengerList.Add(1,new Passenger("Rohini","rohini@gmail.com",20, 'f',"Rohini!1","9894692925"));
            passengerList.Add(2,new Passenger("varshini", "varshini@gmail.com",21, 'f',"Varshini!2","9344800872"));
            passengerList.Add(3,new Passenger("adhav", "adhav@gmail.com", 3, 'm',"Adhav!!23","124567789"));
        }
        internal void BindingUserAccessability()
        {
            try
            {
                Console.WriteLine("Select 1 for DisplayAvailableFlights, 2 for BookTicket, 3 for UpdatingPassengerDetails, 4 for CancelingTicket, 5 for PreviewDetails");
                status = byte.TryParse(Console.ReadLine(), out byte choice);
                if (status)
                {
                    do
                    {
                        switch (choice)
                        {
                            case (byte)(UserChoice.DisplayAvailableFlights):
                                FlightAdmin.flightCollection.ViewAvailableFlightDetails();
                                break;
                            case (byte)(UserChoice.BookTicket):
                                FlightAdmin.bookTicket.TicketReservation();
                                break;
                            case (byte)(UserChoice.UpdatingPassengerDetails):
                                FlightAdmin.passengerCollection.ModifyPassengerDetails();
                                break;
                            case (byte)(UserChoice.CancelingTicket):
                                FlightAdmin.bookTicket.CancelTicket();
                                break;
                            case (byte)(UserChoice.PreviewDetails):
                                FlightAdmin.bookTicket.PreviewTicketDetails();
                                break;
                            case (byte)(UserChoice.DeletePassengerDetails):
                                FlightAdmin.passengerCollection.RemovePassengerDetails();
                                break;
                            case (byte)(UserChoice.SearchingFlightsByLocation):
                                string source = Console.ReadLine();
                                string target = Console.ReadLine();
                                FlightAdmin.bookTicket.SearchByLocation(source, target);
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
            catch (FormatException exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }

        private void ModifyPassengerDetails()
        {
            try
            {
                Console.Write("Enter the passenger id you want to modify : ");
                status = int.TryParse(Console.ReadLine(), out int index);
                if (status)
                {
                    do
                    {
                        Console.WriteLine("Select 1 for PassengerName,2 for Age,3 for Gender,4 for Password,5 for PhoneNumber, 6 for EmailId");
                        status = byte.TryParse(Console.ReadLine(), out byte choice);
                        if (status)
                        {
                            switch (choice)
                            {
                                case (byte)(UpdatePassengerChoice.PassengerName):
                                    PassengerCollection.passengerList[index].PassengerName = Console.ReadLine();
                                    break;
                                case (byte)(UpdatePassengerChoice.Age):
                                    PassengerCollection.passengerList[index].Age = byte.Parse(Console.ReadLine());
                                    break;
                                case (byte)(UpdatePassengerChoice.Gender):
                                    PassengerCollection.passengerList[index].Gender = char.Parse(Console.ReadLine());
                                    break;
                                case (byte)(UpdatePassengerChoice.Password):
                                    PassengerCollection.passengerList[index].Password = Console.ReadLine();
                                    break;
                                case (byte)(UpdatePassengerChoice.PhoneNumber):
                                    PassengerCollection.passengerList[index].PhoneNo = Console.ReadLine();
                                    break;
                                case (byte)(UpdatePassengerChoice.EmailId):
                                    PassengerCollection.passengerList[index].EmailId = Console.ReadLine();
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

        

        private void RemovePassengerDetails()
        {
            try
            {
                Console.Write("Enter the Passenger id you want to remove : ");
                status = int.TryParse(Console.ReadLine(), out int index);
                if (status)
                {
                    PassengerCollection.passengerList.Remove(index);
                }
                else
                    Console.WriteLine("Please enter valid Id!!");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong", exception.Message);
            }
        }
    }
}
