namespace Pazar.Ads.Data
{
    public class DataConstants
    {
        public class Customers
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 30;

            public const int PhoneNumberMinLength = 5;
            public const int PhoneNumberMaxLength = 20;
            public const string ValidPhoneNumber = @"\+[0-9]*";
        }

        public class Ads
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const decimal MinPrice = 0.1M;
            public const decimal MaxPrice = 500000000.0M;

            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 200;
        }

        public class Categories
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;
        }

        public class Image
        {
            public const int ImageUrlMinLength = 4;
            public const int ImageUrlMaxLength = 2048;
        }

    }
}
