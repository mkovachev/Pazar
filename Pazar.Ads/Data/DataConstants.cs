namespace Pazar.Ads.Data
{
    public class DataConstants
    {
        public class Ads
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const decimal MinPrice = 0.1M;
            public const decimal MaxPrice = 9999999999999999.99M;

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
