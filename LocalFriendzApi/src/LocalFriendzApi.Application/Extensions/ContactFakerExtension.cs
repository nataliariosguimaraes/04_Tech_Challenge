using Bogus;

namespace LocalFriendzApi.Application.Extensions
{
    public static class ContactFakerExtension
    {
        public static string GenerateBrazilianPhoneNumber(this Faker f)
        {
            bool isNineDigit = f.Random.Bool(0.8f);
            string phoneNumber = isNineDigit ? f.Phone.PhoneNumber("9########") : f.Phone.PhoneNumber("########");

            return phoneNumber;
        }
        public static List<string> GetValidDDDs(this Faker f)
        {
            return new List<string>
            {
                "11", "12", "13", "14", "15", "16", "17", "18", "19", // SP
                "21", "22", "24", // RJ
                "27", "28", // ES
                "31", "32", "33", "34", "35", "37", "38", // MG
                "41", "42", "43", "44", "45", "46", // PR
                "47", "48", "49", // SC
                "51", "53", "54", "55", // RS
                "61", // DF
                "62", "64", // GO
                "63", // TO
                "65", "66", // MT
                "67", // MS
                "68", // AC
                "69", // RO
                "71", "73", "74", "75", "77", // BA
                "79", // SE
                "81", "82", "83", "84", "85", "86", "87", "88", "89", // NE
                "91", "92", "93", "94", "95", "96", "97", "98", "99" // N
            };
        }
    }
}
