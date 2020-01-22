using System.Text.RegularExpressions;

namespace FlightTicketBooking
{
    internal static class Validator
    {
        internal static bool PasswordValidator(string password)
        {
            Regex passwordValidator = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,10}");
            return passwordValidator.IsMatch(password) ? false : true;
        }
        internal static bool PhoneNumberValidator(string phoneNumber)
        {
            Regex phoneNumberValidator = new Regex("^[0-9]{10}$");
            return phoneNumberValidator.IsMatch(phoneNumber) ? false : true;
        }
        internal static bool UserNameValidator(string name)
        {
            Regex userNameValidator = new Regex("^[a-zA-Z]*$");
            return userNameValidator.IsMatch(name) ? false : true;
        }
        internal static bool EmailIdValidator(string email)
        {
            Regex emailIdValidator = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return emailIdValidator.IsMatch(email) ? false : true;
        }


    }
}
